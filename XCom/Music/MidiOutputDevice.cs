using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace XCom.Music
{
	public class MidiOutputDevice
	{
		private readonly IntPtr handle;

		private MidiFile[] files;
		private int fileIndex;
		private readonly Stopwatch stopwatch = new Stopwatch();
		private const uint defaultTempo = 500000;
		private uint microsecondsPerBeat;
		private List<int> trackEventIndices;
		private List<long> trackEventElapsed;

		public MidiOutputDevice()
		{
			handle = MidiApi.OpenOutputDevice(0, IntPtr.Zero, IntPtr.Zero, 0);
			MidiApi.SetOutputDeviceVolume(handle, 0xffffffff);
		}

		private void Write(uint message)
		{
			MidiApi.WriteMessage(handle, message);
		}

		public void Close()
		{
			MidiApi.CloseOutputDevice(handle);
		}

		private MidiFile CurrentFile => files[fileIndex];

		private void PlayFile(int index)
		{
			MidiApi.ResetOutputDevice(handle);
			fileIndex = index % files.Length;
			Console.WriteLine($"Playing {fileIndex}");
			stopwatch.Restart();
			microsecondsPerBeat = defaultTempo;
			trackEventIndices = Enumerable.Repeat(0, CurrentFile.Tracks.Count).ToList();
			trackEventElapsed = Enumerable.Range(0, CurrentFile.Tracks.Count).Select(value => (long)0).ToList();
		}

		public void PlayFiles(params MidiFile[] filesToRepeat)
		{
			files = filesToRepeat;
			PlayFile(0);
		}

		public void OnIdle()
		{
			if (files == null)
				return;
			var elapsedMicroseconds = stopwatch.ElapsedMilliseconds * 1000;
			foreach (var trackIndex in Enumerable.Range(0, CurrentFile.Tracks.Count))
				PlayTrackEvents(trackIndex, elapsedMicroseconds);
			if (IsEndOfFile)
				PlayFile(fileIndex + 1);
		}

		private bool IsEndOfFile => Enumerable.Range(0, CurrentFile.Tracks.Count)
			.All(index => trackEventIndices[index] >= CurrentFile.Tracks[index].Events.Count);

		private void PlayTrackEvents(int trackIndex, long elapsedMicroseconds)
		{
			var track = CurrentFile.Tracks[trackIndex];
			var eventIndex = trackEventIndices[trackIndex];
			if (eventIndex >= track.Events.Count)
				return;
			for (; trackEventIndices[trackIndex] < track.Events.Count; ++trackEventIndices[trackIndex])
			{
				var midiEvent = track.Events[trackEventIndices[trackIndex]];
				var deltaTime = (elapsedMicroseconds - trackEventElapsed[trackIndex]) * CurrentFile.TicksPerBeat / microsecondsPerBeat;
				if (midiEvent.DeltaTime > deltaTime)
					return;
				var duration = midiEvent.DeltaTime * microsecondsPerBeat / CurrentFile.TicksPerBeat;
				PlayMidiEvent(midiEvent);
				trackEventElapsed[trackIndex] += duration;
			}
		}

		private void PlayMidiEvent(MidiEvent midiEvent)
		{
			if (midiEvent.IsMetaEvent)
			{
				switch (midiEvent.MetaEvent)
				{
				case MetaEvent.SetTempo:
					microsecondsPerBeat = midiEvent.Tempo;
					break;
				case MetaEvent.EndOfTrack:
					break;
				}
			}
			else
			{
				Write(midiEvent.Message);
			}
		}
	}
}

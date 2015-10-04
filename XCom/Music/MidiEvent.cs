using System;
using System.Linq;

namespace XCom.Music
{
	public class MidiEvent
	{
		public uint DeltaTime { get; }
		public bool IsMetaEvent { get; private set; }
		public MetaEvent MetaEvent { get; private set; }
		public uint Tempo { get; private set; }
		public uint Message { get; private set; }

		public MidiEvent(ref byte lastStatus, byte[] data, ref int offset)
		{
			DeltaTime = data.ReadVariableLengthNumber(ref offset);
			var eventCode = data[offset++];
			switch (eventCode)
			{
			case 0xf0:
				throw new InvalidOperationException("Start-of-exclusive message unsupported.");
			case 0xf7:
				throw new InvalidOperationException("System exclusive message unsupported.");
			case 0xff:
				LoadMetaData(data, ref offset);
				break;
			default:
				if ((eventCode & 0x80) == 0)
				{
					var length = GetVoiceDataLength(lastStatus);
					LoadMessage(data, offset - 1, length);
					offset += length - 1;
				}
				else
				{
					lastStatus = eventCode;
					var length = GetVoiceDataLength(lastStatus);
					LoadMessage(data, offset - 1, length + 1);
					offset += length;
				}
				break;
			}
		}

		private void LoadMessage(byte[] data, int offset, int length)
		{
			if (length < 2 || length > 3)
				throw new InvalidOperationException($"Unsupported message length {length}");
			Message = BitConverter.ToUInt32(data.Skip(offset).Take(length).Concat(new byte[] { 0, 0 }).ToArray(), 0);
		}

		private void LoadMetaData(byte[] data, ref int offset)
		{
			IsMetaEvent = true;
			MetaEvent = (MetaEvent)data[offset++];
			var length = data.ReadVariableLengthNumber(ref offset);
			var metaData = data.Skip(offset).Take((int)length).ToArray();
			offset += (int)length;
			switch (MetaEvent)
			{
			case MetaEvent.SetTempo:
				Tempo = BitConverter.ToUInt32(new byte[] { 0 }.Concat(metaData).Reverse().ToArray(), 0);
				break;
			case MetaEvent.EndOfTrack:
				break;
			default:
				throw new InvalidOperationException($"Unsupported meta-event {MetaEvent}");
			}
		}

		private static int GetVoiceDataLength(byte status)
		{
			switch ((VoiceEvent)(status & 0xf0))
			{
			case VoiceEvent.NoteOff:
				return 2;
			case VoiceEvent.NoteOn:
				return 2;
			case VoiceEvent.PolyphonicKeyPressure:
				return 2;
			case VoiceEvent.ControllerChange:
				return 2;
			case VoiceEvent.ProgramChange:
				return 1;
			case VoiceEvent.ChannelKeyPressure:
				return 1;
			case VoiceEvent.PitchBend:
				return 2;
			default:
				throw new InvalidOperationException($"Invalid voice event {status}");
			}
		}
	}
}

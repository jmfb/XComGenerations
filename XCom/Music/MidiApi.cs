using System;
using System.Runtime.InteropServices;
using System.Text;

namespace XCom.Music
{
	public static class MidiApi
	{
		private enum MMRESULT : uint
		{
			MMSYSERR_NOERROR = 0,
			MMSYSERR_ERROR = 1,
			MMSYSERR_BADDEVICEID = 2,
			MMSYSERR_NOTENABLED = 3,
			MMSYSERR_ALLOCATED = 4,
			MMSYSERR_INVALHANDLE = 5,
			MMSYSERR_NODRIVER = 6,
			MMSYSERR_NOMEM = 7,
			MMSYSERR_NOTSUPPORTED = 8,
			MMSYSERR_BADERRNUM = 9,
			MMSYSERR_INVALFLAG = 10,
			MMSYSERR_INVALPARAM = 11,
			MMSYSERR_HANDLEBUSY = 12,
			MMSYSERR_INVALIDALIAS = 13,
			MMSYSERR_BADDB = 14,
			MMSYSERR_KEYNOTFOUND = 15,
			MMSYSERR_READERROR = 16,
			MMSYSERR_WRITEERROR = 17,
			MMSYSERR_DELETEERROR = 18,
			MMSYSERR_VALNOTFOUND = 19,
			MMSYSERR_NODRIVERCB = 20,
			WAVERR_BADFORMAT = 32,
			WAVERR_STILLPLAYING = 33,
			WAVERR_UNPREPARED = 34
		}

		[DllImport("winmm.dll")]
		private static extern MMRESULT midiOutGetErrorText(uint mmrError, StringBuilder pszText, uint cchText);

		[DllImport("winmm.dll")]
		private static extern MMRESULT midiOutOpen(out IntPtr lphMidiOut, uint uDeviceID, IntPtr dwCallback, IntPtr dwInstance, uint dwFlags);

		[DllImport("winmm.dll")]
		private static extern MMRESULT midiOutClose(IntPtr hMidiOut);

		[DllImport("winmm.dll")]
		private static extern MMRESULT midiOutShortMsg(IntPtr hMidiOut, uint dwMsg);

		[DllImport("winmm.dll")]
		private static extern MMRESULT midiOutReset(IntPtr hMidiOut);

		[DllImport("winmm.dll")]
		private static extern MMRESULT midiOutSetVolume(IntPtr hMidiOut, uint dwVolume);

		private static void CheckResult(MMRESULT result, string function, string parameters)
		{
			const uint maxErrorDescriptionLength = 256;
			if (result == MMRESULT.MMSYSERR_NOERROR)
				return;
			var description = new StringBuilder((int)maxErrorDescriptionLength);
			midiOutGetErrorText((uint)result, description, (uint)description.Capacity);
			throw new InvalidOperationException($"{function}({parameters}) returned {result}({(int)result}): {description}");
		}

		public static IntPtr OpenOutputDevice(uint deviceId, IntPtr callback, IntPtr instance, uint flags)
		{
			IntPtr handle;
			var result = midiOutOpen(out handle, deviceId, callback, instance, flags);
			CheckResult(result, "midiOutOpen", $"deviceId={deviceId}");
			return handle;
		}

		public static void CloseOutputDevice(IntPtr handle)
		{
			var result = midiOutClose(handle);
			CheckResult(result, "midiOutClose", "");
		}

		public static void WriteMessage(IntPtr handle, uint message)
		{
			var result = midiOutShortMsg(handle, message);
			CheckResult(result, "midiOutShortMsg", $"message={message}");
		}

		public static void ResetOutputDevice(IntPtr handle)
		{
			var result = midiOutReset(handle);
			CheckResult(result, "midiOutReset", "");
		}

		public static void SetOutputDeviceVolume(IntPtr handle, uint volume)
		{
			var result = midiOutSetVolume(handle, volume);
			CheckResult(result, "midiOutSetVolume", "");
		}
	}
}

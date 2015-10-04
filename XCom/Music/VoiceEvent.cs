namespace XCom.Music
{
	public enum VoiceEvent : byte
	{
		NoteOff = 0x80,
		NoteOn = 0x90,
		PolyphonicKeyPressure = 0xa0,
		ControllerChange = 0xb0,
		ProgramChange = 0xc0,
		ChannelKeyPressure = 0xd0,
		PitchBend = 0xe0
	}
}

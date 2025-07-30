namespace XCom.Music;

public class MidiTrack
{
	public List<MidiEvent> Events { get; } = new();

	public MidiTrack(byte[] data)
	{
		byte lastStatus = 0;
		for (var offset = 0; offset < data.Length; )
			Events.Add(new MidiEvent(ref lastStatus, data, ref offset));
	}
}

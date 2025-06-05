using DBFileReaderLib.Attributes;

namespace WowPacketParser.DBC.Structures.Legion
{
    [DBFile("Phase")]
    public sealed class PhaseEntry
    {
        [Index(true)]
        public uint ID;
        public short Flags;
    }
}

using DBFileReaderLib.Attributes;

namespace WowPacketParser.DBC.Structures.Legion
{
    [DBFile("Criteria")]
    public sealed class CriteriaEntry
    {
        [Index(true)]
        public uint ID;
        public int Asset;
        public int StartAsset;
        public int FailAsset;
        public uint ModifierTreeId;
        public ushort StartTime;
        public short EligibilityWorldStateID;
        public byte Type;
        public byte StartEvent;
        public byte FailEvent;
        public byte Flags;
        public byte EligibilityWorldStateValue;
    }
}

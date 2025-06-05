using DBFileReaderLib.Attributes;

namespace WowPacketParser.DBC.Structures.Legion
{
    [DBFile("CriteriaTree")]
    public sealed class CriteriaTreeEntry
    {
        [Index(true)]
        public uint ID;
        public string Description;
        public int Amount;
        public short Flags;
        public sbyte Operator;
        public uint CriteriaID;
        public uint Parent;
        public int OrderIndex;
    }
}

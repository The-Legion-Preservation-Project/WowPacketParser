using System.Runtime.InteropServices;
using DBFileReaderLib.Attributes;

namespace WowPacketParser.DBC.Structures.Legion
{
    [DBFile("Creature")]
    public sealed class CreatureEntry
    {
        [Index(true)]
        public uint ID;
        public string Name;
        public string FemaleName;
        public string SubName;
        public string FemaleSubName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public int[] Item;
        public int Mount;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public int[] DisplayID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] DisplayIdProbability;
        public byte Type;
        public byte Family;
        public byte Classification;
        public byte InhabitType;
    }
}

using System.Runtime.InteropServices;
using DBFileReaderLib.Attributes;

namespace WowPacketParser.DBC.Structures.Legion
{
    [DBFile("CreatureDifficulty")]

    public sealed class CreatureDifficultyEntry
    {
        [Index(true)]
        public uint ID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
        public int[] Flags;
        public ushort FactionTemplateID;
        public sbyte Expansion;
        public sbyte MinLevel;
        public sbyte MaxLevel;
        public int CreatureID;
    }
}

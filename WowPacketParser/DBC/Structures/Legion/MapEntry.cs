using System.Runtime.InteropServices;
using DBFileReaderLib.Attributes;

namespace WowPacketParser.DBC.Structures.Legion
{
    [DBFile("Map")]
    public sealed class MapEntry
    {
        [Index(true)]
        public uint ID;
        public string Directory;
        public string MapName;
        public string MapDescription0;
        public string MapDescription1;
        public string PvpShortDescription;
        public string PvpLongDescription;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public int[] Flags;
        public float MinimapIconScale;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public float[] Corpse;
        public ushort AreaTableID;
        public short LoadingScreenID;
        public short CorpseMapID;
        public short TimeOfDayOverride;
        public short ParentMapID;
        public short CosmeticParentMapID;
        public short WindSettingsID;
        public byte InstanceType;
        public byte MapType;
        public byte ExpansionID;
        public byte MaxPlayers;
        public byte TimeOffset;
    }
}

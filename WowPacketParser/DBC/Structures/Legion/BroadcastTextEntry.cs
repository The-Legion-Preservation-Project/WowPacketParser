using System.Runtime.InteropServices;
using DBFileReaderLib.Attributes;

namespace WowPacketParser.DBC.Structures.Legion
{
    [DBFile("BroadcastText")]

    public sealed class BroadcastTextEntry
    {
        [Index(true)]
        public uint ID;
        public string Text;
        public string Text1;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public ushort[] EmoteID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public ushort[] EmoteDelay;
        public ushort EmotesID;
        public byte LanguageID;
        public byte Flags;
        public int ConditionID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public uint[] SoundKitID;
    }
}

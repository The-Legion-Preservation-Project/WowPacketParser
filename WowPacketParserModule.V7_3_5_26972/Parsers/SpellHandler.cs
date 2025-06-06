using WowPacketParser.Enums;
using WowPacketParser.Misc;
using WowPacketParser.Parsing;

namespace WowPacketParserModule.V7_3_5_26972.Parsers
{
    public static class SpellHandler
    {
        [Parser(Opcode.SMSG_SEND_SPELL_CHARGES, ClientVersionBuild.V7_3_5_26972)]
        public static void HandleSendSpellCharges(Packet packet)
        {
            var int4 = packet.ReadInt32("SpellChargeEntryCount");
            for (int i = 0; i < int4; i++)
            {
                packet.ReadUInt32("Category", i);
                packet.ReadUInt32("NextRecoveryTime", i);
                packet.ReadSingle("ChargeModRate", i);
                packet.ReadByte("ConsumedCharges", i);
            }
        }
    }
}

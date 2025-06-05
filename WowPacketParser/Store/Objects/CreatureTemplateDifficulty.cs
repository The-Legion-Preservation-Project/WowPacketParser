using System;
using WowPacketParser.Enums;
using WowPacketParser.Misc;
using WowPacketParser.SQL;

namespace WowPacketParser.Store.Objects
{
    [DBTableName("creature_template_scaling", TargetedDatabaseFlag.TillShadowlandsNoLegion)]
    [DBTableName("creature_template_difficulty", TargetedDatabaseFlag.Legion | TargetedDatabaseFlag.SinceDragonflight | TargetedDatabaseFlag.WotlkClassic | TargetedDatabaseFlag.CataClassic)]
    public sealed record CreatureTemplateDifficultyWDB : IDataModel
    {
        [DBFieldName("Entry", true)]
        public uint? Entry;

        [DBFieldName("DifficultyID", true)]
        public uint? DifficultyID;

        [DBFieldName("HealthScalingExpansion", TargetedDatabaseFlag.Legion | TargetedDatabaseFlag.SinceDragonflight | TargetedDatabaseFlag.WotlkClassic | TargetedDatabaseFlag.CataClassic)]
        public ClientType? HealthScalingExpansion;

        [DBFieldName("HealthModifier", TargetedDatabaseFlag.Legion | TargetedDatabaseFlag.SinceDragonflight | TargetedDatabaseFlag.WotlkClassic | TargetedDatabaseFlag.CataClassic)]
        public float? HealthModifier;

        [DBFieldName("ManaModifier", TargetedDatabaseFlag.Legion | TargetedDatabaseFlag.SinceDragonflight | TargetedDatabaseFlag.WotlkClassic | TargetedDatabaseFlag.CataClassic)]
        public float? ManaModifier;

        [DBFieldName("CreatureDifficultyID", TargetedDatabaseFlag.SinceDragonflight | TargetedDatabaseFlag.WotlkClassic | TargetedDatabaseFlag.CataClassic)]
        public int? CreatureDifficultyID;

        [DBFieldName("TypeFlags", TargetedDatabaseFlag.Legion | TargetedDatabaseFlag.SinceDragonflight | TargetedDatabaseFlag.WotlkClassic | TargetedDatabaseFlag.CataClassic)]
        public CreatureTypeFlag? TypeFlags;

        [DBFieldName("TypeFlags2", TargetedDatabaseFlag.Legion | TargetedDatabaseFlag.SinceDragonflight | TargetedDatabaseFlag.WotlkClassic | TargetedDatabaseFlag.CataClassic)]
        public uint? TypeFlags2;

        public bool WDBEqualsSkipDifficultySkipHealthScalingExpansion(CreatureTemplateDifficultyWDB rhs)
        {
            if (rhs == null)
                return false;

            return Entry == rhs.Entry &&
                Math.Abs(HealthModifier.Value - rhs.HealthModifier.Value) < 0.01f &&
                Math.Abs(ManaModifier.Value - rhs.ManaModifier.Value) < 0.01f &&
                CreatureDifficultyID == rhs.CreatureDifficultyID &&
                TypeFlags == rhs.TypeFlags &&
                TypeFlags2 == rhs.TypeFlags2;
        }
    }

    [DBTableName("creature_template_scaling", TargetedDatabaseFlag.TillShadowlandsNoLegion)]
    [DBTableName("creature_template_difficulty", TargetedDatabaseFlag.Legion | TargetedDatabaseFlag.SinceDragonflight | TargetedDatabaseFlag.WotlkClassic | TargetedDatabaseFlag.CataClassic)]
    public sealed record CreatureTemplateDifficulty : IDataModel
    {
        [DBFieldName("Entry", true)]
        public uint? Entry;

        [DBFieldName("DifficultyID", true)]
        public uint? DifficultyID;

        [DBFieldName("LevelScalingMin", TargetedDatabaseFlag.Legion | TargetedDatabaseFlag.BattleForAzeroth)]
        public uint? LevelScalingMin;

        [DBFieldName("LevelScalingMax", TargetedDatabaseFlag.Legion | TargetedDatabaseFlag.BattleForAzeroth)]
        public uint? LevelScalingMax;

        [DBFieldName("LevelScalingDeltaMin", TargetedDatabaseFlag.AnyRetail)]
        public int? LevelScalingDeltaMin;

        [DBFieldName("LevelScalingDeltaMax", TargetedDatabaseFlag.AnyRetail)]
        public int? LevelScalingDeltaMax;

        [DBFieldName("MinLevel", TargetedDatabaseFlag.Legion | TargetedDatabaseFlag.WotlkClassic | TargetedDatabaseFlag.CataClassic)]
        public int? MinLevel;

        [DBFieldName("MaxLevel", TargetedDatabaseFlag.Legion | TargetedDatabaseFlag.WotlkClassic | TargetedDatabaseFlag.CataClassic)]
        public int? MaxLevel;

        //[DBFieldName("SandboxScalingID", TargetedDatabaseFlag.Legion)]
        [DBFieldName("ContentTuningID", TargetedDatabaseFlag.SinceBattleForAzeroth)]
        public int? ContentTuningID;

        [DBFieldName("StaticFlags1", TargetedDatabaseFlag.Legion | TargetedDatabaseFlag.SinceDragonflight | TargetedDatabaseFlag.WotlkClassic | TargetedDatabaseFlag.CataClassic)]
        public CreatureStaticFlags? StaticFlags1 = 0;

        [DBFieldName("StaticFlags2", TargetedDatabaseFlag.Legion | TargetedDatabaseFlag.SinceDragonflight | TargetedDatabaseFlag.WotlkClassic | TargetedDatabaseFlag.CataClassic)]
        public CreatureStaticFlags2? StaticFlags2 = 0;

        [DBFieldName("StaticFlags3", TargetedDatabaseFlag.Legion | TargetedDatabaseFlag.SinceDragonflight | TargetedDatabaseFlag.WotlkClassic | TargetedDatabaseFlag.CataClassic)]
        public CreatureStaticFlags3? StaticFlags3 = 0;

        [DBFieldName("StaticFlags4", TargetedDatabaseFlag.Legion | TargetedDatabaseFlag.SinceDragonflight | TargetedDatabaseFlag.WotlkClassic | TargetedDatabaseFlag.CataClassic)]
        public CreatureStaticFlags4? StaticFlags4 = 0;

        [DBFieldName("StaticFlags5", TargetedDatabaseFlag.Legion | TargetedDatabaseFlag.SinceDragonflight | TargetedDatabaseFlag.WotlkClassic | TargetedDatabaseFlag.CataClassic)]
        public CreatureStaticFlags5? StaticFlags5 = 0;

        [DBFieldName("StaticFlags6", TargetedDatabaseFlag.Legion | TargetedDatabaseFlag.SinceDragonflight | TargetedDatabaseFlag.WotlkClassic | TargetedDatabaseFlag.CataClassic)]
        public CreatureStaticFlags6? StaticFlags6 = 0;

        [DBFieldName("StaticFlags7", TargetedDatabaseFlag.Legion | TargetedDatabaseFlag.SinceDragonflight | TargetedDatabaseFlag.WotlkClassic | TargetedDatabaseFlag.CataClassic)]
        public CreatureStaticFlags7? StaticFlags7 = 0;

        [DBFieldName("StaticFlags8", TargetedDatabaseFlag.Legion | TargetedDatabaseFlag.SinceDragonflight | TargetedDatabaseFlag.WotlkClassic | TargetedDatabaseFlag.CataClassic)]
        public CreatureStaticFlags8? StaticFlags8 = 0;

        [DBFieldName("VerifiedBuild")]
        public int? VerifiedBuild = ClientVersion.BuildInt;
    }
}

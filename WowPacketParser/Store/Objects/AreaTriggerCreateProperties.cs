﻿using System;
using WowPacketParser.Enums;
using WowPacketParser.Misc;
using WowPacketParser.SQL;
using WowPacketParser.Store.Objects.UpdateFields;
using WowPacketParser.Store.Objects.UpdateFields.LegacyImplementation;

namespace WowPacketParser.Store.Objects
{
    [DBTableName("spell_areatrigger", TargetedDatabaseFlag.TillBattleForAzeroth)]
    [DBTableName("areatrigger_create_properties", TargetedDatabaseFlag.SinceShadowlands | TargetedDatabaseFlag.CataClassic)]
    public sealed record AreaTriggerCreateProperties : WoWObject, IDataModel
    {
        [DBFieldName("SpellMiscId", TargetedDatabaseFlag.TillBattleForAzeroth, true)]
        [DBFieldName("Id", TargetedDatabaseFlag.SinceShadowlands | TargetedDatabaseFlag.CataClassic, true)]
        public uint? AreaTriggerCreatePropertiesId;

        [DBFieldName("IsCustom", TargetedDatabaseFlag.SinceDragonflight | TargetedDatabaseFlag.CataClassic, true)]
        public byte? IsCustom;

        [DBFieldName("AreaTriggerId")]
        public uint? AreaTriggerId;

        [DBFieldName("IsAreatriggerCustom", TargetedDatabaseFlag.SinceDragonflight | TargetedDatabaseFlag.CataClassic)]
        public byte? IsAreatriggerCustom = 0;

        [DBFieldName("Flags", TargetedDatabaseFlag.SinceDragonflight | TargetedDatabaseFlag.CataClassic)]
        public uint? Flags;

        [DBFieldName("MoveCurveId")]
        public int? MoveCurveId = 0;

        [DBFieldName("ScaleCurveId")]
        public int? ScaleCurveId = 0;

        [DBFieldName("MorphCurveId")]
        public int? MorphCurveId = 0;

        [DBFieldName("FacingCurveId")]
        public int? FacingCurveId = 0;

        [DBFieldName("AnimId")]
        public int? AnimId = ClientVersion.AddedInVersion(ClientVersionBuild.V9_1_5_40772) ? -1 : 0;

        [DBFieldName("AnimKitId")]
        public int? AnimKitId = 0;

        [DBFieldName("DecalPropertiesId")]
        public uint? DecalPropertiesId = 0;

        [DBFieldName("SpellForVisuals", TargetedDatabaseFlag.Legion | TargetedDatabaseFlag.SinceDragonflight | TargetedDatabaseFlag.CataClassic, false, false, true)]
        public int? SpellForVisuals;

        [DBFieldName("TimeToTarget", TargetedDatabaseFlag.TillDragonflight)]
        public uint? TimeToTarget = 0;

        [DBFieldName("TimeToTargetScale")]
        public uint? TimeToTargetScale = 0;

        [DBFieldName("Speed", TargetedDatabaseFlag.SinceTheWarWithin)]
        public float? Speed;

        [DBFieldName("Shape", TargetedDatabaseFlag.SinceShadowlands | TargetedDatabaseFlag.CataClassic)]
        public byte? Shape;

        [DBFieldName("ShapeData", TargetedDatabaseFlag.SinceShadowlands | TargetedDatabaseFlag.CataClassic, 8, true)]
        public float?[] ShapeData = { 0, 0, 0, 0, 0, 0, 0, 0 };

        [DBFieldName("VerifiedBuild")]
        public int? VerifiedBuild = ClientVersion.BuildInt;

        // Will be inserted as comment
        public uint spellId = 0;

        public string CustomId;

        public IAreaTriggerData AreaTriggerData;

        public AreaTriggerCreateProperties() : base()
        {
            AreaTriggerData = new AreaTriggerData(this);
        }

        public override void LoadValuesFromUpdateFields()
        {
            spellId             = (uint)AreaTriggerData.SpellID;
            SpellForVisuals     = AreaTriggerData.SpellForVisuals;
            DecalPropertiesId   = AreaTriggerData.DecalPropertiesID;
            TimeToTarget        = AreaTriggerData.TimeToTarget;
            TimeToTargetScale   = AreaTriggerData.TimeToTargetScale;
            AreaTriggerCreatePropertiesId = GetAreaTriggerCreatePropertiesIdFromSpellId(spellId);
            IsCustom = 0;
            if (AreaTriggerCreatePropertiesId == null)
                IsCustom = 1;

            if (ClientVersion.AddedInVersion(ClientVersionBuild.V9_1_5_40772))
            {
                if (AreaTriggerData.VisualAnim != null)
                {
                    if (AreaTriggerData.VisualAnim.AnimationDataID != 0 && AreaTriggerData.VisualAnim.AnimationDataID != uint.MaxValue)
                        AnimId = (int)AreaTriggerData.VisualAnim.AnimationDataID;

                    if (AreaTriggerData.VisualAnim.AnimKitID != 0)
                        AnimKitId = (int)AreaTriggerData.VisualAnim.AnimKitID;
                }
            }
        }

        public static uint? GetAreaTriggerCreatePropertiesIdFromSpellId(uint spellId)
        {
            if (!Settings.UseDBC)
                return null;

            uint? areaTriggerCreatePropertiesId = null;

            for (uint idx = 0; idx < 32; idx++)
            {
                var tuple = Tuple.Create(spellId, idx);
                if (DBC.DBC.SpellEffectStores.TryGetValue(tuple, out var effect))
                {
                    if (effect.Effect == (uint)SpellEffects.SPELL_EFFECT_CREATE_AREATRIGGER ||
                        effect.Effect == (uint)SpellEffects.SPELL_EFFECT_183 ||
                        effect.EffectAura == (uint)AuraTypeLegion.SPELL_AURA_AREA_TRIGGER)
                    {
                        // If we already had a SPELL_EFFECT_CREATE_AREATRIGGER, spell has multiple areatrigger,
                        // so we can't deduce SpellMiscId, return null
                        if (areaTriggerCreatePropertiesId != null)
                            return null;

                        areaTriggerCreatePropertiesId = (uint)effect.EffectMiscValue[0];
                    }
                }
            }

            return areaTriggerCreatePropertiesId;
        }
    }

    [DBTableName("spell_areatrigger", TargetedDatabaseFlag.TillBattleForAzeroth)]
    [DBTableName("areatrigger_create_properties", TargetedDatabaseFlag.SinceShadowlands)]
    public sealed record AreaTriggerCreatePropertiesCustom : IDataModel
    {
        [DBFieldName("SpellMiscId", TargetedDatabaseFlag.TillBattleForAzeroth, true, true)]
        [DBFieldName("Id", TargetedDatabaseFlag.SinceShadowlands, true, true)]
        public string AreaTriggerCreatePropertiesId;

        [DBFieldName("IsCustom", TargetedDatabaseFlag.SinceDragonflight, true)]
        public byte? IsCustom = 1;

        [DBFieldName("AreaTriggerId")]
        public uint? AreaTriggerId;

        [DBFieldName("IsAreatriggerCustom", TargetedDatabaseFlag.SinceDragonflight)]
        public byte? IsAreatriggerCustom;

        [DBFieldName("Flags", TargetedDatabaseFlag.SinceDragonflight)]
        public uint? Flags;

        [DBFieldName("MoveCurveId")]
        public int? MoveCurveId = 0;

        [DBFieldName("ScaleCurveId")]
        public int? ScaleCurveId = 0;

        [DBFieldName("MorphCurveId")]
        public int? MorphCurveId = 0;

        [DBFieldName("FacingCurveId")]
        public int? FacingCurveId = 0;

        [DBFieldName("AnimId")]
        public int? AnimId = ClientVersion.AddedInVersion(ClientVersionBuild.V9_1_5_40772) ? -1 : 0;

        [DBFieldName("AnimKitId")]
        public int? AnimKitId = 0;

        [DBFieldName("DecalPropertiesId")]
        public uint? DecalPropertiesId = 0;

        [DBFieldName("SpellForVisuals", TargetedDatabaseFlag.Legion | TargetedDatabaseFlag.SinceDragonflight | TargetedDatabaseFlag.CataClassic, false, false, true)]
        public int? SpellForVisuals;

        [DBFieldName("TimeToTarget", TargetedDatabaseFlag.TillDragonflight)]
        public uint? TimeToTarget = 0;

        [DBFieldName("TimeToTargetScale")]
        public uint? TimeToTargetScale = 0;

        [DBFieldName("Speed", TargetedDatabaseFlag.SinceTheWarWithin)]
        public float? Speed;

        [DBFieldName("Shape", TargetedDatabaseFlag.SinceShadowlands)]
        public byte? Shape;

        [DBFieldName("ShapeData", TargetedDatabaseFlag.SinceShadowlands, 8, true)]
        public float?[] ShapeData = { 0, 0, 0, 0, 0, 0, 0, 0 };

        [DBFieldName("VerifiedBuild")]
        public int? VerifiedBuild = ClientVersion.BuildInt;
    }
}

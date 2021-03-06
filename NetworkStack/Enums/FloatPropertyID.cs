////////////////////////////////////////////////////////////////////////////////////
// This file is generated code.  Do not modify it's contents.
// If changes are required, update the message.xml in the TemplateBulder
// project and run the TemplateBuilder to recreate the files.
////////////////////////////////////////////////////////////////////////////////////
using System;

namespace ACE.Network.Enums
{
    /// <summary>
    /// The FloatPropertyID identifies a specific Character or Object float property.
    /// </summary>
    public enum FloatPropertyID : uint
    {
        Undef = 0x00000000,
        HeartbeatInterval = 0x00000001,
        HeartbeatTimestamp = 0x00000002,
        HealthRate = 0x00000003,
        StaminaRate = 0x00000004,
        ManaRate = 0x00000005,
        HealthUponResurrection = 0x00000006,
        StaminaUponResurrection = 0x00000007,
        ManaUponResurrection = 0x00000008,
        StartTime = 0x00000009,
        StopTime = 0x0000000A,
        ResetInterval = 0x0000000B,
        Shade = 0x0000000C,
        ArmorModVsSlash = 0x0000000D,
        ArmorModVsPierce = 0x0000000E,
        ArmorModVsBludgeon = 0x0000000F,
        ArmorModVsCold = 0x00000010,
        ArmorModVsFire = 0x00000011,
        ArmorModVsAcid = 0x00000012,
        ArmorModVsElectric = 0x00000013,
        CombatSpeed = 0x00000014,
        WeaponLength = 0x00000015,
        DamageVariance = 0x00000016,
        CurrentPowerMod = 0x00000017,
        AccuracyMod = 0x00000018,
        StrengthMod = 0x00000019,
        MaximumVelocity = 0x0000001A,
        RotationSpeed = 0x0000001B,
        MotionTimestamp = 0x0000001C,
        WeaponDefense = 0x0000001D,
        WimpyLevel = 0x0000001E,
        VisualAwarenessRange = 0x0000001F,
        AuralAwarenessRange = 0x00000020,
        PerceptionLevel = 0x00000021,
        PowerupTime = 0x00000022,
        MaxChargeDistance = 0x00000023,
        ChargeSpeed = 0x00000024,
        BuyPrice = 0x00000025,
        SellPrice = 0x00000026,
        DefaultScale = 0x00000027,
        LockpickMod = 0x00000028,
        RegenerationInterval = 0x00000029,
        RegenerationTimestamp = 0x0000002A,
        GeneratorRadius = 0x0000002B,
        TimeToRot = 0x0000002C,
        DeathTimestamp = 0x0000002D,
        PkTimestamp = 0x0000002E,
        VictimTimestamp = 0x0000002F,
        LoginTimestamp = 0x00000030,
        CreationTimestamp = 0x00000031,
        MinimumTimeSincePk = 0x00000032,
        DeprecatedHousekeepingPriority = 0x00000033,
        AbuseLoggingTimestamp = 0x00000034,
        LastPortalTeleportTimestamp = 0x00000035,
        UseRadius = 0x00000036,
        HomeRadius = 0x00000037,
        ReleasedTimestamp = 0x00000038,
        MinHomeRadius = 0x00000039,
        Facing = 0x0000003A,
        ResetTimestamp = 0x0000003B,
        LogoffTimestamp = 0x0000003C,
        EconRecoveryInterval = 0x0000003D,
        WeaponOffense = 0x0000003E,
        DamageMod = 0x0000003F,
        ResistSlash = 0x00000040,
        ResistPierce = 0x00000041,
        ResistBludgeon = 0x00000042,
        ResistFire = 0x00000043,
        ResistCold = 0x00000044,
        ResistAcid = 0x00000045,
        ResistElectric = 0x00000046,
        ResistHealthBoost = 0x00000047,
        ResistStaminaDrain = 0x00000048,
        ResistStaminaBoost = 0x00000049,
        ResistManaDrain = 0x0000004A,
        ResistManaBoost = 0x0000004B,
        Translucency = 0x0000004C,
        PhysicsScriptIntensity = 0x0000004D,
        Friction = 0x0000004E,
        Elasticity = 0x0000004F,
        AiUseMagicDelay = 0x00000050,
        ItemMinSpellcraftMod = 0x00000051,
        ItemMaxSpellcraftMod = 0x00000052,
        ItemRankProbability = 0x00000053,
        Shade2 = 0x00000054,
        Shade3 = 0x00000055,
        Shade4 = 0x00000056,
        ItemEfficiency = 0x00000057,
        ItemManaUpdateTimestamp = 0x00000058,
        SpellGestureSpeedMod = 0x00000059,
        SpellStanceSpeedMod = 0x0000005A,
        AllegianceAppraisalTimestamp = 0x0000005B,
        PowerLevel = 0x0000005C,
        AccuracyLevel = 0x0000005D,
        AttackAngle = 0x0000005E,
        AttackTimestamp = 0x0000005F,
        CheckpointTimestamp = 0x00000060,
        SoldTimestamp = 0x00000061,
        UseTimestamp = 0x00000062,
        UseLockTimestamp = 0x00000063,
        HealkitMod = 0x00000064,
        FrozenTimestamp = 0x00000065,
        HealthRateMod = 0x00000066,
        AllegianceSwearTimestamp = 0x00000067,
        ObviousRadarRange = 0x00000068,
        HotspotCycleTime = 0x00000069,
        HotspotCycleTimeVariance = 0x0000006A,
        SpamTimestamp = 0x0000006B,
        SpamRate = 0x0000006C,
        BondWieldedTreasure = 0x0000006D,
        BulkMod = 0x0000006E,
        SizeMod = 0x0000006F,
        GagTimestamp = 0x00000070,
        GeneratorUpdateTimestamp = 0x00000071,
        DeathSpamTimestamp = 0x00000072,
        DeathSpamRate = 0x00000073,
        WildAttackProbability = 0x00000074,
        FocusedProbability = 0x00000075,
        CrashAndTurnProbability = 0x00000076,
        CrashAndTurnRadius = 0x00000077,
        CrashAndTurnBias = 0x00000078,
        GeneratorInitialDelay = 0x00000079,
        AiAcquireHealth = 0x0000007A,
        AiAcquireStamina = 0x0000007B,
        AiAcquireMana = 0x0000007C,
        ResistHealthDrain = 0x0000007D,
        LifestoneProtectionTimestamp = 0x0000007E,
        AiCounteractEnchantment = 0x0000007F,
        AiDispelEnchantment = 0x00000080,
        TradeTimestamp = 0x00000081,
        AiTargetedDetectionRadius = 0x00000082,
        EmotePriority = 0x00000083,
        LastTeleportStartTimestamp = 0x00000084,
        EventSpamTimestamp = 0x00000085,
        EventSpamRate = 0x00000086,
        InventoryOffset = 0x00000087,
        CriticalMultiplier = 0x00000088,
        ManaStoneDestroyChance = 0x00000089,
        SlayerDamageBonus = 0x0000008A,
        AllegianceInfoSpamTimestamp = 0x0000008B,
        AllegianceInfoSpamRate = 0x0000008C,
        NextSpellcastTimestamp = 0x0000008D,
        AppraisalRequestedTimestamp = 0x0000008E,
        AppraisalHeartbeatDueTimestamp = 0x0000008F,
        ManaConversionMod = 0x00000090,
        LastPkAttackTimestamp = 0x00000091,
        FellowshipUpdateTimestamp = 0x00000092,
        CriticalFrequency = 0x00000093,
        LimboStartTimestamp = 0x00000094,
        WeaponMissileDefense = 0x00000095,
        WeaponMagicDefense = 0x00000096,
        IgnoreShield = 0x00000097,
        ElementalDamageMod = 0x00000098,
        StartMissileAttackTimestamp = 0x00000099,
        LastRareUsedTimestamp = 0x0000009A,
        IgnoreArmor = 0x0000009B,
        ProcSpellRate = 0x0000009C,
        ResistanceModifier = 0x0000009D,
        AllegianceGagTimestamp = 0x0000009E,
        AbsorbMagicDamage = 0x0000009F,
        CachedMaxAbsorbMagicDamage = 0x000000A0,
        GagDuration = 0x000000A1,
        AllegianceGagDuration = 0x000000A2,
        GlobalXpMod = 0x000000A3,
        HealingModifier = 0x000000A4,
        ArmorModVsNether = 0x000000A5,
        ResistNether = 0x000000A6,
        CooldownDuration = 0x000000A7,
        WeaponAuraOffense = 0x000000A8,
        WeaponAuraDefense = 0x000000A9,
        WeaponAuraElemental = 0x000000AA,
        WeaponAuraManaConv = 0x000000AB
    }
}

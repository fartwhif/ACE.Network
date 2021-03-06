////////////////////////////////////////////////////////////////////////////////////
// This file is generated code.  Do not modify it's contents.
// If changes are required, update the message.xml in the TemplateBulder
// project and run the TemplateBuilder to recreate the files.
////////////////////////////////////////////////////////////////////////////////////
using System;

namespace ACE.Network.Enums
{
    /// <summary>
    /// The CharacterErrorType identifies the type of character error that has occured.
    /// </summary>
    public enum CharacterErrorType : uint
    {
        
        /// <summary>
        /// ID_CHAR_ERROR_LOGON
        /// </summary>
        Logon = 0x00000001,
        
        /// <summary>
        /// ID_CHAR_ERROR_ACCOUNT_LOGON
        /// </summary>
        AccountLogin = 0x00000003,
        
        /// <summary>
        /// ID_CHAR_ERROR_SERVER_CRASH
        /// </summary>
        ServerCrash1 = 0x00000004,
        
        /// <summary>
        /// ID_CHAR_ERROR_LOGOFF
        /// </summary>
        Logoff = 0x00000005,
        
        /// <summary>
        /// ID_CHAR_ERROR_DELETE
        /// </summary>
        Delete = 0x00000006,
        
        /// <summary>
        /// ID_CHAR_ERROR_SERVER_CRASH
        /// </summary>
        ServerCrash2 = 0x00000008,
        
        /// <summary>
        /// ID_CHAR_ERROR_ACCOUNT_INVALID
        /// </summary>
        AccountInvalid = 0x00000009,
        
        /// <summary>
        /// ID_CHAR_ERROR_ACCOUNT_DOESNT_EXIST
        /// </summary>
        AccountDoesntExist = 0x0000000A,
        
        /// <summary>
        /// ID_CHAR_ERROR_ENTER_GAME_GENERIC
        /// </summary>
        EnterGameGeneric = 0x0000000B,
        
        /// <summary>
        /// ID_CHAR_ERROR_ENTER_GAME_STRESS_ACCOUNT
        /// </summary>
        EnterGameStressAccount = 0x0000000C,
        
        /// <summary>
        /// ID_CHAR_ERROR_ENTER_GAME_CHARACTER_IN_WORLD
        /// </summary>
        EnterGameCharacterInWorld = 0x0000000D,
        
        /// <summary>
        /// ID_CHAR_ERROR_ENTER_GAME_PLAYER_ACCOUNT_MISSING
        /// </summary>
        EnterGamePlayerAccountMissing = 0x0000000E,
        
        /// <summary>
        /// ID_CHAR_ERROR_ENTER_GAME_CHARACTER_NOT_OWNED
        /// </summary>
        EnterGameCharacterNotOwned = 0x0000000F,
        
        /// <summary>
        /// ID_CHAR_ERROR_ENTER_GAME_CHARACTER_IN_WORLD_SERVER
        /// </summary>
        EnterGameCharacterInWorldServer = 0x00000010,
        
        /// <summary>
        /// ID_CHAR_ERROR_ENTER_GAME_OLD_CHARACTER
        /// </summary>
        EnterGameOldCharacter = 0x00000011,
        
        /// <summary>
        /// ID_CHAR_ERROR_ENTER_GAME_CORRUPT_CHARACTER
        /// </summary>
        EnterGameCorruptCharacter = 0x00000012,
        
        /// <summary>
        /// ID_CHAR_ERROR_ENTER_GAME_START_SERVER_DOWN
        /// </summary>
        EnterGameStartServerDown = 0x00000013,
        
        /// <summary>
        /// ID_CHAR_ERROR_ENTER_GAME_COULDNT_PLACE_CHARACTER
        /// </summary>
        EnterGameCouldntPlaceCharacter = 0x00000014,
        
        /// <summary>
        /// ID_CHAR_ERROR_LOGON_SERVER_FULL
        /// </summary>
        LogonServerFull = 0x00000015,
        
        /// <summary>
        /// ID_CHAR_ERROR_ENTER_GAME_CHARACTER_LOCKED
        /// </summary>
        EnterGameCharacterLocked = 0x00000017,
        
        /// <summary>
        /// ID_CHAR_ERROR_SUBSCRIPTION_EXPIRED
        /// </summary>
        SubscriptionExpired = 0x00000018
    }
}

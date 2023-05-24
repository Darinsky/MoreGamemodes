



using Harmony;
using Il2Cpp;
using Il2CppAssets.Scripts.Unity.UI_New.ChallengeEditor;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppNinjaKiwi.Common;
using Il2CppNinjaKiwi.NKMulti.IO;
using Il2CppTMPro;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine;

[assembly: MelonModInfo(typeof(MoreGameModes.MoreGameModes), MoreGameModes.ModHelperData.Name, MoreGameModes.ModHelperData.Version, MoreGameModes.ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace MoreGameModes;






    
    public class MoreGameModes : BloonsTD6Mod
    {

    public const string EventId = nameof(MoreGameModes);
    public override void OnBloonCreated(Bloon bloon)
    {
      //  MelonLogger.Msg(bloon.bloonModel.maxHealth);
    }

    public override void OnApplicationStart()
    {

        //UnityEngine.Random.seed = UnityEngine.Random.RandomRangeInt(0, 57347985);

        if (!Directory.Exists("Mods/Gamemodes++/"))
        {
            Directory.CreateDirectory("Mods/Gamemodes++/");
        }
        if (!File.Exists("Mods/Gamemodes++/CurrentRandomRounds.txt"))
        {
            if (Debugmode) { MelonLogger.Msg("CurrentRandomRounds.txt doesn't exist, creating it..."); }
            try
            {
                File.Create("Mods/Gamemodes++/CurrentRandomRounds.txt").Close();
            }
            catch {
                if (Debugmode)
                {
                    MelonLogger.Msg("Upcoming error, sorry mate :(");
                }
                File.Create("Mods/Gamemodes++/CurrentRandomRounds.txt").Close();
            }
            File.WriteAllText("Mods/Gamemodes++/CurrentRandomRounds.txt", "Seed: \n" + UnityEngine.Random.seed.ToString() + "\n");


            try
            {
                string[] fuckyou = File.ReadAllLines("Mods/Gamemodes++/CurrentRandomRounds.txt");
                UnityEngine.Random.seed = Convert.ToInt32(fuckyou[1]);
            }
            catch
            {
                if (Debugmode)
                {
                    MelonLogger.Msg("Something went wrong, trying again :/");
                }
                File.WriteAllText("Mods/Gamemodes++/CurrentRandomRounds.txt", "Seed: \n" + UnityEngine.Random.seed.ToString() + "\n");
            }
            if (Debugmode)
            {
                MelonLogger.Msg("CurrentRandomRounds.txt does exist :/");
            }
            string[] lines = File.ReadAllLines("Mods/Gamemodes++/CurrentRandomRounds.txt");
            UnityEngine.Random.seed = Convert.ToInt32(lines[1]);
            if (Debugmode)
            {
                MelonLogger.Msg(UnityEngine.Random.seed);
            }
            File.WriteAllText("Mods/Gamemodes++/CurrentRandomRounds.txt", "Seed: \n" + UnityEngine.Random.seed.ToString() + "\n");


        }

         if (File.Exists("Mods/Gamemodes++/CurrentRandomRounds.txt"))
        {

            try
            {
                string[] fuckyou = File.ReadAllLines("Mods/Gamemodes++/CurrentRandomRounds.txt");
                UnityEngine.Random.seed = Convert.ToInt32(fuckyou[1]);
            }
            catch
            {
                if (Debugmode)
                {
                    MelonLogger.Msg("Something went wrong, trying again :/");
                }
                File.WriteAllText("Mods/Gamemodes++/CurrentRandomRounds.txt", "Seed: \n" + UnityEngine.Random.seed.ToString() + "\n");
            }
            if (Debugmode)
            {
                MelonLogger.Msg("CurrentRandomRounds.txt does exist :/");
            }
            string[] lines = File.ReadAllLines("Mods/Gamemodes++/CurrentRandomRounds.txt");
            UnityEngine.Random.seed = Convert.ToInt32(lines[1]);
            if (Debugmode)
            {
                MelonLogger.Msg(UnityEngine.Random.seed);
            }
            File.WriteAllText("Mods/Gamemodes++/CurrentRandomRounds.txt", "Seed: \n" + UnityEngine.Random.seed.ToString() + "\n");




        }

    }

    private static readonly string path = "Mods/Gamemodes++/";
    private static readonly string roundsnotespath = path + "CurrentRandomRounds.txt";

    
    static float[] startingcashs = new float[]
      {
            5000f
            ,8000f
            ,17000f
            ,38000f
          ,71000f

      };
    //settings 
    private static readonly System.Collections.Generic.Dictionary<string, string> promotionMap = new System.Collections.Generic.Dictionary<string, string>()
        {
            { "Red", "Blue" },
            { "RedCamo", "BlueCamo" },
            { "RedRegrow", "BlueRegrow" },
            { "RedRegrowCamo", "BlueRegrowCamo" },

            { "Blue", "Green" },
            { "BlueCamo", "GreenCamo" },
            { "BlueRegrow", "GreenRegrow" },
            { "BlueRegrowCamo", "GreenRegrowCamo" },

            { "Green", "Yellow" },
            { "GreenCamo", "YellowCamo" },
            { "GreenRegrow", "YellowRegrow" },
            { "GreenRegrowCamo", "YellowRegrowCamo" },

            { "Yellow", "Pink" },
            { "YellowCamo", "PinkCamo" },
            { "YellowRegrow", "PinkRegrow" },
            { "YellowRegrowCamo", "PinkRegrowCamo" },

            { "Pink", "Purple" },
            { "PinkCamo", "PurpleCamo" },
            { "PinkRegrow", "PurpleRegrow" },
            { "PinkRegrowCamo", "PurpleRegrowCamo" },

            { "Black", "Lead" },
            { "BlackCamo", "LeadCamo" },
            { "BlackRegrow", "LeadRegrow" },
            { "BlackRegrowCamo", "LeadRegrowCamo" },

            { "White", "Zebra" },
            { "WhiteCamo", "ZebraCamo" },
            { "WhiteRegrow", "ZebraRegrow" },
            { "WhiteRegrowCamo", "ZebraRegrowCamo" },

            { "Purple", "Rainbow" },
            { "PurpleCamo", "RainbowCamo" },
            { "PurpleRegrow", "RainbowRegrow" },
            { "PurpleRegrowCamo", "RainbowRegrowCamo" },

            { "Lead", "Rainbow" },
            { "LeadCamo", "RainbowCamo" },
            { "LeadRegrow", "RainbowRegrow" },
            { "LeadRegrowCamo", "RainbowRegrowCamo" },
            { "LeadFortified", "RainbowRegrowCamo" },
            { "LeadRegrowFortified", "RainbowRegrowCamo" },
            { "LeadFortifiedCamo", "RainbowRegrowCamo" },
            { "LeadRegrowFortifiedCamo", "RainbowRegrowCamo" },

            { "Zebra", "Rainbow" },
            { "ZebraCamo", "RainbowCamo" },
            { "ZebraRegrow", "RainbowRegrow" },
            { "ZebraRegrowCamo", "RainbowRegrowCamo" },

            { "Rainbow", "Ceramic" },
            { "Rainbow ", "Ceramic" },
            { "RainbowCamo", "CeramicCamo" },
            { "RainbowRegrow", "CeramicRegrow" },
            { "RainbowRegrowCamo", "CeramicRegrowCamo" },

            { "Ceramic", "Moab" },
            { "CeramicCamo", "Moab" },
            { "CeramicRegrow", "Moab" },
            { "CeramicRegrowCamo", "Moab" },
            { "CeramicFortified", "MoabFortified" },
            { "CeramicFortifiedCamo", "MoabFortified" },
            { "CeramicRegrowFortified", "MoabFortified" },
            { "CeramicRegrowFortifiedCamo", "MoabFortified" },

            { "Moab", "Bfb" },
            { "MoabFortified", "BfbFortified" },

            { "Bfb", "Zomg" },
            { "BfbFortified", "ZomgFortified" },

            { "DdtCamo", "DdtFortifiedCamo" },
            { "DdtFortifiedCamo", "DdtFortifiedCamo" },

            { "Zomg", "Bad" },
            { "ZomgFortified", "BadFortified" },

            { "Bad", "Bloonarius3" },
            { "BadFortified", "BloonariusElite3" },

        { "Bloonarius3", "Bloonarius3" },
            { "BloonariusElite3", "BloonariusElite3" }


        };

    private static readonly System.Collections.Generic.Dictionary<string, string> promotionMap2 = new System.Collections.Generic.Dictionary<string, string>()
    {
            { "Lead", "CeramicFortifiedCamo" },
            { "LeadCamo", "CeramicFortifiedCamo" },
            { "LeadRegrow", "CeramicRegrowFortifiedCamo" },
            { "LeadRegrowCamo", "CeramicRegrowFortifiedCamo" },
            { "LeadFortified", "CeramicFortifiedCamo" },
            { "LeadRegrowFortified", "CeramicRegrowFortifiedCamo" },
            { "LeadFortifiedCamo", "CeramicRegrowFortifiedCamo" },
            { "LeadRegrowFortifiedCamo", "CeramicRegrowFortifiedCamo" },
    
    };
    
    private static readonly ModSettingBool FastTrackEnabled = new(false)
    {
        displayName = "Fast Track Enabled",
        button = true
    };
   /*  
    private static readonly ModSettingInt Seed = new(0)
    {
        displayName = "Seed",
        min = -9999999999,
        max = 9999999999,
        



    };
     private static readonly ModSettingButton RamdomizeSeed = new(() => UnityEngine.Random.seed = Seed)
      {
          displayName = "Set Seed",
          buttonText = "Set it",

          action = () => { 
              File.AppendAllText(roundsnotespath, "Seed: \n " + Seed); 
          },



          requiresRestart = true,
      }; 
   */
    private static readonly ModSettingInt MasterModeScale = new(1)
    {
        displayName = "Master Mode Boost",
        slider= true,
        min =1,
        max =12,
        requiresRestart= true,
    };
    private static readonly ModSettingBool EliteBosses = new(false)
    {
        displayName = "Elite Bosses",
        
        
        
        requiresRestart = true,
    };
    /* private static readonly ModSettingBool BossRoundOverride = new(false)
     {
         displayName = "Override Boss Rounds with normal rounds",
         description = "Will cause some amount of lags when entering a game." +
         "\n Designed to be used with co-op mode " + 
         "\n USE AT YOUR OWN RISK",



         requiresRestart = true,
     };*/
    private static readonly ModSettingDouble MoabHpScale = new(4)
    {
        displayName = "Moab Health Boost",
       // slider = true,
        min = 0,
        max = 999999,
        requiresRestart = true,
    };
    private static readonly ModSettingDouble CeramicHpScale = new(4)
    {
        displayName = "Ceramic Health Boost",
       // slider = true,
        min = 0,
        max = 999999,
        requiresRestart = true,
    };
    private static readonly ModSettingDouble BloonSpeedBoost = new(3)
    {
        displayName = "Bloon Speed Boost",
       // slider = true,
        min = 0.1,
        max = 999999,
        requiresRestart = true,
    };
    private static readonly ModSettingDouble BossSpawningSpeed = new(40)
    {
        displayName = "Boss Spawning Delays (In Seconds)",
        // slider = true,
        min = 0,
        max = 180,
        requiresRestart = true,
    };
    private static readonly ModSettingInt MinRandValue = new(20)
    {
        displayName = "MinRandValue",
         slider = true,
        min = 0,
        max = 100,
        requiresRestart = true,
    };
    private static readonly ModSettingInt MaxRandValue = new(20)
    {
        displayName = "MaxRandValue",
        slider = true,
        min = 0,
        max = 100,
        requiresRestart = true,
    };
    private static readonly ModSettingBool Debugmode = new(false)
    {
        displayName = "Debug Mode",
        button = true
    };
    public override void OnNewGameModel(GameModel gameModel, List<ModModel> mods)
    {

        if (Debugmode) { MelonLogger.Msg(gameModel.GetRoundSet().name); }
        // fucking coding nighmare
        if (false)
        {
            int i = 0;
            string isElite = "";
            if (EliteBosses)
            {
                isElite = "Elite";
            }
            gameModel.GetRoundSet().rounds.ForEach(roundModel =>
            {

                if (i == 39) {
                    // roundModel.ClearBloonGroups();

                    roundModel.AddBloonGroup("Bloonarius" + isElite + "1", 1, BossSpawningSpeed * 0, BossSpawningSpeed * 1);
                    roundModel.AddBloonGroup("Rainbow", Convert.ToInt32(BossSpawningSpeed), 0, BossSpawningSpeed * 60);

                    foreach (var group in roundModel.groups)
                    {
                        var bloon = Game.instance.model.GetBloon(group.bloon);
                        if (bloon.isBoss)
                        {
                            bloon.leakDamage = 32767;
                        }
                    }
                }

                if (i == 40) {
                    //  roundModel.ClearBloonGroups();

                    roundModel.AddBloonGroup("Lych" + isElite + "1", 1, BossSpawningSpeed * 0, BossSpawningSpeed * 1);
                    roundModel.AddBloonGroup("Moab", Convert.ToInt32(Il2CppAssets.Scripts.Simulation.SMath.Math.Round(BossSpawningSpeed / 8)) + 1, BossSpawningSpeed * 5, BossSpawningSpeed * 60);

                    foreach (var group in roundModel.groups)
                    {
                        var bloon = Game.instance.model.GetBloon(group.bloon);
                        if (bloon.isBoss)
                        {
                            bloon.leakDamage = 32767;
                        }
                    }
                }

                if (i == 41) {
                    //  roundModel.ClearBloonGroups();

                    roundModel.AddBloonGroup("Vortex" + isElite + "1", 1, BossSpawningSpeed * 0, BossSpawningSpeed * 1);
                    roundModel.AddBloonGroup("Moab", Convert.ToInt32(Il2CppAssets.Scripts.Simulation.SMath.Math.Round(BossSpawningSpeed / 10)) + 1, BossSpawningSpeed * 8, BossSpawningSpeed * 60);
                    roundModel.AddBloonGroup("Pink", Convert.ToInt32(Il2CppAssets.Scripts.Simulation.SMath.Math.Round(BossSpawningSpeed * 4)) + 1, BossSpawningSpeed * 8, BossSpawningSpeed * 60);

                    foreach (var group in roundModel.groups)
                    {
                        var bloon = Game.instance.model.GetBloon(group.bloon);
                        if (bloon.isBoss)
                        {
                            bloon.leakDamage = 32767;
                        }
                    }
                }

                if (i == 42) {
                    //   roundModel.ClearBloonGroups();

                    roundModel.AddBloonGroup("Dreadbloon" + isElite + "1", 1, BossSpawningSpeed * 0, BossSpawningSpeed * 1);
                    roundModel.AddBloonGroup("Ceramic", Convert.ToInt32(Il2CppAssets.Scripts.Simulation.SMath.Math.Round(BossSpawningSpeed / 9)) + 1, BossSpawningSpeed * 0, BossSpawningSpeed * 5);


                    foreach (var group in roundModel.groups)
                    {
                        var bloon = Game.instance.model.GetBloon(group.bloon);
                        if (bloon.isBoss)
                        {
                            bloon.leakDamage = 32767;
                        }
                    }
                }



                if (i == 59) {
                    //  roundModel.ClearBloonGroups();

                    roundModel.AddBloonGroup("Bloonarius" + isElite + "2", 1, BossSpawningSpeed * 0, BossSpawningSpeed * 0);
                    roundModel.AddBloonGroup("Rainbow", Convert.ToInt32(BossSpawningSpeed * 3), 0, BossSpawningSpeed * 60);

                    foreach (var group in roundModel.groups)
                    {
                        var bloon = Game.instance.model.GetBloon(group.bloon);
                        if (bloon.isBoss)
                        {
                            bloon.leakDamage = 32767;
                        }
                    }
                }

                if (i == 60) {
                    //  roundModel.ClearBloonGroups();

                    roundModel.AddBloonGroup("Lych" + isElite + "2", 1, BossSpawningSpeed * 0, BossSpawningSpeed * 0);
                    roundModel.AddBloonGroup("Bfb", Convert.ToInt32(Il2CppAssets.Scripts.Simulation.SMath.Math.Round(BossSpawningSpeed / 15)) + 1, BossSpawningSpeed * 5, BossSpawningSpeed * 60);
                    roundModel.AddBloonGroup("Moab", Convert.ToInt32(Il2CppAssets.Scripts.Simulation.SMath.Math.Round(BossSpawningSpeed / 5)) + 1, BossSpawningSpeed * 5, BossSpawningSpeed * 60);

                    foreach (var group in roundModel.groups)
                    {
                        var bloon = Game.instance.model.GetBloon(group.bloon);
                        if (bloon.isBoss)
                        {
                            bloon.leakDamage = 32767;
                        }
                    }
                }

                if (i == 61) {
                    //   roundModel.ClearBloonGroups();

                    roundModel.AddBloonGroup("Vortex" + isElite + "2", 1, BossSpawningSpeed * 0, BossSpawningSpeed * 0);
                    roundModel.AddBloonGroup("MoabFortified", Convert.ToInt32(Il2CppAssets.Scripts.Simulation.SMath.Math.Round(BossSpawningSpeed / 9)) + 1, BossSpawningSpeed * 8, BossSpawningSpeed * 60);
                    roundModel.AddBloonGroup("Purple", Convert.ToInt32(Il2CppAssets.Scripts.Simulation.SMath.Math.Round(BossSpawningSpeed * 4)) + 1, BossSpawningSpeed * 8, BossSpawningSpeed * 60);

                    foreach (var group in roundModel.groups)
                    {
                        var bloon = Game.instance.model.GetBloon(group.bloon);
                        if (bloon.isBoss)
                        {
                            bloon.leakDamage = 32767;
                        }
                    }
                }
                if (i == 62) {
                    //  roundModel.ClearBloonGroups();

                    roundModel.AddBloonGroup("Dreadbloon" + isElite + "2", 1, BossSpawningSpeed * 0, BossSpawningSpeed * 0);
                    // roundModel.AddBloonGroup("DreadRockBloonStandard2", Convert.ToInt32(Il2CppAssets.Scripts.Simulation.SMath.Math.Round(BossSpawningSpeed / 9)) + 1, BossSpawningSpeed * 0, BossSpawningSpeed * 5);


                    foreach (var group in roundModel.groups)
                    {
                        var bloon = Game.instance.model.GetBloon(group.bloon);
                        if (bloon.isBoss)
                        {
                            bloon.leakDamage = 32767;
                        }
                    }
                }

                if (i == 79) {
                    //   roundModel.ClearBloonGroups();

                    roundModel.AddBloonGroup("Bloonarius" + isElite + "3", 1, BossSpawningSpeed * 0, BossSpawningSpeed * 0);
                    roundModel.AddBloonGroup("Bfb", Convert.ToInt32(BossSpawningSpeed / 4), 0, BossSpawningSpeed * 60);
                    roundModel.AddBloonGroup("Zomg", Convert.ToInt32(1), 0, BossSpawningSpeed * 60);

                    foreach (var group in roundModel.groups)
                    {
                        var bloon = Game.instance.model.GetBloon(group.bloon);
                        if (bloon.isBoss)
                        {
                            bloon.leakDamage = 32767;
                        }
                    }
                }
                if (i == 80) {
                    //    roundModel.ClearBloonGroups();

                    roundModel.AddBloonGroup("Lych" + isElite + "3", 1, BossSpawningSpeed * 0, BossSpawningSpeed * 0);
                    roundModel.AddBloonGroup("Bfb", Convert.ToInt32(Il2CppAssets.Scripts.Simulation.SMath.Math.Round(BossSpawningSpeed / 8)) + 1, BossSpawningSpeed * 5, BossSpawningSpeed * 60);
                    roundModel.AddBloonGroup("MoabFortified", Convert.ToInt32(Il2CppAssets.Scripts.Simulation.SMath.Math.Round(BossSpawningSpeed)) + 1, BossSpawningSpeed * 5, BossSpawningSpeed * 60);

                    foreach (var group in roundModel.groups)
                    {
                        var bloon = Game.instance.model.GetBloon(group.bloon);
                        if (bloon.isBoss)
                        {
                            bloon.leakDamage = 32767;
                        }
                    }
                }
                if (i == 81) {
                    //   roundModel.ClearBloonGroups();

                    roundModel.AddBloonGroup("Vortex" + isElite + "3", 1, BossSpawningSpeed * 0, BossSpawningSpeed * 0);
                    roundModel.AddBloonGroup("BfbFortified", Convert.ToInt32(Il2CppAssets.Scripts.Simulation.SMath.Math.Round(BossSpawningSpeed / 5)) + 1, BossSpawningSpeed * 8, BossSpawningSpeed * 60);
                    roundModel.AddBloonGroup("Purple", Convert.ToInt32(Il2CppAssets.Scripts.Simulation.SMath.Math.Round(BossSpawningSpeed * 8)) + 1, BossSpawningSpeed * 1, BossSpawningSpeed * 60);

                    foreach (var group in roundModel.groups)
                    {
                        var bloon = Game.instance.model.GetBloon(group.bloon);
                        if (bloon.isBoss)
                        {
                            bloon.leakDamage = 32767;
                        }
                    }
                }
                if (i == 82) {
                    //     roundModel.ClearBloonGroups();

                    roundModel.AddBloonGroup("Dreadbloon" + isElite + "3", 1, BossSpawningSpeed * 0, BossSpawningSpeed * 0);
                    roundModel.AddBloonGroup("DreadRockBloonStandard3", Convert.ToInt32(Il2CppAssets.Scripts.Simulation.SMath.Math.Round(BossSpawningSpeed / 9)) + 1, BossSpawningSpeed * 0, BossSpawningSpeed * 5);


                    foreach (var group in roundModel.groups)
                    {
                        var bloon = Game.instance.model.GetBloon(group.bloon);
                        if (bloon.isBoss)
                        {
                            bloon.leakDamage = 32767;
                        }
                    }
                }
                if (i == 99) {
                    //   roundModel.ClearBloonGroups();

                    roundModel.AddBloonGroup("Bloonarius" + isElite + "4", 1, BossSpawningSpeed * 0, BossSpawningSpeed * 0);
                    roundModel.AddBloonGroup("Zomg", Convert.ToInt32(BossSpawningSpeed / 4), 0, BossSpawningSpeed * 60);
                    roundModel.AddBloonGroup("Bad", Convert.ToInt32(1), 0, BossSpawningSpeed * 10);

                    foreach (var group in roundModel.groups)
                    {
                        var bloon = Game.instance.model.GetBloon(group.bloon);
                        if (bloon.isBoss)
                        {
                            bloon.leakDamage = 32767;
                        }
                    }
                }
                if (i == 100) {
                    //   roundModel.ClearBloonGroups();

                    roundModel.AddBloonGroup("Lych" + isElite + "4", 1, BossSpawningSpeed * 0, BossSpawningSpeed * 0);
                    roundModel.AddBloonGroup("Ddt", Convert.ToInt32(Il2CppAssets.Scripts.Simulation.SMath.Math.Round(BossSpawningSpeed / 4)) + 1, BossSpawningSpeed * 5, BossSpawningSpeed * 60);
                    roundModel.AddBloonGroup("BfbFortified", Convert.ToInt32(Il2CppAssets.Scripts.Simulation.SMath.Math.Round(BossSpawningSpeed)) + 1, BossSpawningSpeed * 5, BossSpawningSpeed * 60);

                    foreach (var group in roundModel.groups)
                    {
                        var bloon = Game.instance.model.GetBloon(group.bloon);
                        if (bloon.isBoss)
                        {
                            bloon.leakDamage = 32767;
                        }
                    }
                }
                if (i == 101) {
                    //     roundModel.ClearBloonGroups();

                    roundModel.AddBloonGroup("Vortex" + isElite + "4", 1, BossSpawningSpeed * 0, BossSpawningSpeed * 0);
                    roundModel.AddBloonGroup("ZomgFortified", Convert.ToInt32(Il2CppAssets.Scripts.Simulation.SMath.Math.Round(BossSpawningSpeed / 5)) + 1, BossSpawningSpeed * 8, BossSpawningSpeed * 60);
                    roundModel.AddBloonGroup("Purple", Convert.ToInt32(Il2CppAssets.Scripts.Simulation.SMath.Math.Round(BossSpawningSpeed * 16)) + 1, BossSpawningSpeed * 1, BossSpawningSpeed * 60);

                    foreach (var group in roundModel.groups)
                    {
                        var bloon = Game.instance.model.GetBloon(group.bloon);
                        if (bloon.isBoss)
                        {
                            bloon.leakDamage = 32767;
                        }
                    }
                }
                if (i == 102) {
                    //    roundModel.ClearBloonGroups();

                    roundModel.AddBloonGroup("Dreadbloon" + isElite + "4", 1, BossSpawningSpeed * 0, BossSpawningSpeed * 0);
                    roundModel.AddBloonGroup("DreadRockBloonStandard4", Convert.ToInt32(Il2CppAssets.Scripts.Simulation.SMath.Math.Round(BossSpawningSpeed / 9)) + 1, BossSpawningSpeed * 0, BossSpawningSpeed * 5);


                    foreach (var group in roundModel.groups)
                    {
                        var bloon = Game.instance.model.GetBloon(group.bloon);
                        if (bloon.isBoss)
                        {
                            bloon.leakDamage = 32767;
                        }
                    }
                }

                if (i == 119) {
                    //   roundModel.ClearBloonGroups();

                    roundModel.AddBloonGroup("Bloonarius" + isElite + "5", 1, BossSpawningSpeed * 0, BossSpawningSpeed * 0);
                    roundModel.AddBloonGroup("ZomgFortified", Convert.ToInt32(BossSpawningSpeed / 1.4444f), 0, BossSpawningSpeed * 60);
                    roundModel.AddBloonGroup("Bad", Convert.ToInt32(5), 0, BossSpawningSpeed * 10);

                    foreach (var group in roundModel.groups)
                    {
                        var bloon = Game.instance.model.GetBloon(group.bloon);
                        if (bloon.isBoss)
                        {
                            bloon.leakDamage = 32767;
                        }
                    }
                }
                if (i == 120) {
                    //   roundModel.ClearBloonGroups();

                    roundModel.AddBloonGroup("Lych" + isElite + "5", 1, BossSpawningSpeed * 0, BossSpawningSpeed * 0);
                    roundModel.AddBloonGroup("DdtFortifiedCamo", Convert.ToInt32(Il2CppAssets.Scripts.Simulation.SMath.Math.Round(BossSpawningSpeed / 2)) + 1, BossSpawningSpeed * 5, BossSpawningSpeed * 60);
                    roundModel.AddBloonGroup("ZomgFortified", Convert.ToInt32(Il2CppAssets.Scripts.Simulation.SMath.Math.Round(BossSpawningSpeed) / 2) + 1, BossSpawningSpeed * 5, BossSpawningSpeed * 60);

                    foreach (var group in roundModel.groups)
                    {
                        var bloon = Game.instance.model.GetBloon(group.bloon);
                        if (bloon.isBoss)
                        {
                            bloon.leakDamage = 32767;
                        }
                    }
                }
                if (i == 121) {
                    //     roundModel.ClearBloonGroups();

                    roundModel.AddBloonGroup("Vortex" + isElite + "5", 1, BossSpawningSpeed * 0, BossSpawningSpeed * 0);
                    roundModel.AddBloonGroup("ZomgFortified", Convert.ToInt32(Il2CppAssets.Scripts.Simulation.SMath.Math.Round(BossSpawningSpeed / 5)) + 1, BossSpawningSpeed * 8, BossSpawningSpeed * 60);
                    roundModel.AddBloonGroup("Purple", Convert.ToInt32(Il2CppAssets.Scripts.Simulation.SMath.Math.Round(BossSpawningSpeed * 64)) + 1, BossSpawningSpeed * 5, BossSpawningSpeed * 60);

                    foreach (var group in roundModel.groups)
                    {
                        var bloon = Game.instance.model.GetBloon(group.bloon);
                        if (bloon.isBoss)
                        {
                            bloon.leakDamage = 32767;
                        }
                    }
                }
                if (i == 122) {
                    //    roundModel.ClearBloonGroups();

                    roundModel.AddBloonGroup("Dreadbloon" + isElite + "5", 1, BossSpawningSpeed * 0, BossSpawningSpeed * 0);
                    roundModel.AddBloonGroup("DreadRockBloonStandard4", Convert.ToInt32(Il2CppAssets.Scripts.Simulation.SMath.Math.Round(BossSpawningSpeed / 9)) + 1, BossSpawningSpeed * 0, BossSpawningSpeed * 5);


                    foreach (var group in roundModel.groups)
                    {
                        var bloon = Game.instance.model.GetBloon(group.bloon);
                        if (bloon.isBoss)
                        {
                            bloon.leakDamage = 32767;
                        }
                    }
                }














                if (true)
                {

                    foreach (var group in roundModel.groups)
                    {
                        var bloon = Game.instance.model.GetBloon(group.bloon);
                        string[] bloonboost = { "Red", "Blue", "Green", "Yellow", "Pink", "White", "Black", "Purple", "Zebra", "Lead", "Rainbow" };
                        foreach (var str in bloonboost)
                        {
                            if (bloon.name.Contains(str))
                            {
                                group.bloon = PromoteBloon(group.bloon, i, MasterModeScale);
                            }
                        }

                    }
                    var roundmulti = RoundMultiplyier(i);
                    if (i > 43)
                    {

                        roundModel.groups.ForEach(group =>
                        {

                            var lenght = group.end * roundmulti;
                            group.end = (int)lenght;

                        });
                    }
                }

                i ++;
               
            });
        }
        if ("MoreGameModes-RandomizedRound" == gameModel.GetRoundSet().name)
        {
            foreach (var i in gameModel.GetRoundSet().rounds)
            {
                //MelonLogger.Msg(i);

            }

           
        }


        int x = gameModel.endRound / 2;
        
        if (FastTrackEnabled & gameModel.cash < 5000) {
            
            gameModel.startRound = gameModel.endRound/2;
            
            if (gameModel.endRound == 40) { gameModel.cash = startingcashs[0]; gameModel.spawnHeroesAtLevel = 5; }
            else if(gameModel.endRound == 60) { gameModel.cash = startingcashs[1]; gameModel.spawnHeroesAtLevel = 6; }
            else if(gameModel.endRound == 80) { gameModel.cash = startingcashs[2]; gameModel.spawnHeroesAtLevel = 7; }
            else if(gameModel.endRound == 100) { gameModel.cash = startingcashs[3]; gameModel.spawnHeroesAtLevel = 9; }
            else if(gameModel.endRound == 140) { gameModel.cash = startingcashs[4]; gameModel.spawnHeroesAtLevel = 10; gameModel.startRound = 60; }

            else
            {
                
                 gameModel.cash = Il2CppAssets.Scripts.Simulation.SMath.Math.Round((.71f * Il2CppAssets.Scripts.Simulation.SMath.Math.Pow((x - 15), 3) + 5000)*100)/100;
             //   MelonLogger.Msg(gameModel.endRound * gameModel.endRound);
            }
                }
       
    }


  
    
        public class AllFortified : ModRoundSet
        {
            public override string BaseRoundSet => RoundSetType.Default;
            public override int DefinedRounds => BaseRounds.Count;
            public override string DisplayName => "All Fortified";
            public override string Icon => VanillaSprites.FortifiedBloonIcon;

            public override void ModifyRoundModels(RoundModel roundModel, int round)
            {
                foreach (var group in roundModel.groups)
                
                {
                    
                
                var bloon = Game.instance.model.GetBloon(group.bloon);
                
                
                    if (bloon.FindChangedBloonId(bloonModel => bloonModel.isFortified = true, out var fortifiedBloon))
                    {
                        group.bloon = fortifiedBloon;
                    
                    }
                    
                }
            }
        }
    public static string PromoteBloon(string bloon, int round, int times)
    {
        //if (bloon.Contains("Pink") || bloon.Contains("Lead")) return bloon;
        
        
        string temp = bloon;

        if (times > 0)
        {
            for (int i = 0; i < times; i++)
            {
                if (bloon != null)
                {
                    if (bloon.Contains("Lead") & round > 80)
                    {

                        promotionMap2.TryGetValue(bloon, out temp);
                        

                    }
                    else
                    {
                        
                            promotionMap.TryGetValue(bloon, out temp);
                        
                    }

                    if (i != times)
                    {
                        bloon = temp;
                    }
                }
            }
        } 
       
            return temp;
        
    }
    public static float RoundMultiplyier(int round)
    {
        round += 1;
        
        if (44 <= round & round < 60)
        {
            return (round * -0.0625f) + 4.75f;
        }
        if (60 <= round & round < 80)
        {
            return (round * -0.05f) + 5f;
        }
        if (80 <= round & round < 100)
        {
            return (round * -0.05f) + 6f;
        }
        if (100 <= round & round < 120)
        {
            return (round * -0.05f) + 7f;
        }
        if (120 <= round & round < 140)
        {
            return (round * -0.05f) + 8f;
        }
        else
        {
            return 1;
        }
    }
    public class HarderRounds : ModRoundSet
        {
            public override string BaseRoundSet => RoundSetType.Default;
            public override int DefinedRounds => BaseRounds.Count;
            public override string DisplayName => "Harder Rounds";
            
            public override string Icon => VanillaSprites.Fortifried;

            public override void ModifyRoundModels(RoundModel roundModel, int round)
            {
          
            
           switch (round)
            {
                default:

                    foreach (var group in roundModel.groups)
                    {

                        group.bloon = PromoteBloon(group.bloon, round, MasterModeScale);
                        
                        
                    }

                    break;
            }
            }
        }
    public class OneRedBloonSet : ModRoundSet
    {
        public override string BaseRoundSet => RoundSetType.Default;
        public override int DefinedRounds => BaseRounds.Count;
        public override string DisplayName => "ORB";

        public override bool AddToOverrideMenu => false;

        public override string Icon => VanillaSprites.BloonDecreaseHPIcon;

        public override void ModifyRoundModels(RoundModel roundModel, int round)
        {


            switch (round)
            {
                default:

                    roundModel.ClearBloonGroups();
                    roundModel.AddBloonGroup("Red", 1, 0, 1);
                    
                    break;
            }
        }
    }
    static string[] lines2 = {};
   
    public class RandomizedRound : ModRoundSet
    {
        public override string BaseRoundSet => RoundSetType.Default;
        public override int DefinedRounds => BaseRounds.Count;
        public override string DisplayName => "Randomized Rounds";

       
        public string asd = "";
    
        public override string Icon => "RandRounds-Icon";
        public override bool AddToOverrideMenu => true;
        

        public override void ModifyRoundModels(RoundModel roundModel, int round)
        {

           
             if (round == 0 )
            {
                try
                {
                    lines2 = File.ReadAllLines(roundsnotespath);
                    asd = lines2[0] + "\n" + lines2[1] + "\nMin: " + MinRandValue.GetValue().ToString() + "\nMax: " + MaxRandValue.GetValue().ToString() + "\n";
                 }
                catch { asd = "Seed: \n" + UnityEngine.Random.seed.ToString() + "\nMin: " + MinRandValue.GetValue().ToString() + "\nMax: " + MaxRandValue.GetValue().ToString() + "\n"; }
            }
            
         

            switch (round)
            {
                default:
                    // Thanks warper for letting me use his code :)
                    RoundSetModel roundSet = Game.instance.model.roundSets[1];
                    

                        RoundModel newRound = roundSet.rounds[round];
                         int minvalue = 0;
                    int maxvalue = 140;
                    if (round - MinRandValue > 0)
                    {
                        minvalue = round - MinRandValue;
                    }
                    if (round + MaxRandValue < 140)
                    {
                        maxvalue = round + MaxRandValue;
                    }
                    
                    
                    int randvalue = UnityEngine.Random.RandomRange(minvalue, maxvalue);



                   
                    
                   
                    newRound = roundSet.rounds[randvalue];
                        
                    
                    foreach (var bloon in newRound.groups)
                        {
                            string bloonName = bloon.bloon;
                            BloonGroupModel bloonNew = bloon;
                            newRound.groups.Add(bloonNew);
                        }
                        roundModel.groups = newRound.groups;




                    asd += "Round " + (round+1).ToString() + " is replaced with Round " + (randvalue+1).ToString() + "\n";


                    if (round == 139)
                    {
                     //   MelonLogger.Msg(asd);
                        File.WriteAllText(roundsnotespath, asd);
                        
                       
                    }
                    break;

                
                    
                    
            }



            
        }

    }



    public class AllFortifiedGamemode : ModGameMode
        {
            public override string Difficulty => DifficultyType.Hard;

            public override string BaseGameMode => GameModeType.Hard;

            public override string DisplayName => "All Fortified";

            public override string Icon => VanillaSprites.FortifiedBloonIcon;

            public override void ModifyBaseGameModeModel(ModModel gameModeModel)
            {
            gameModeModel.UseRoundSet<AllFortified>();
                
            }
        }

    
    public class MegaChimps : ModGameMode
        {
            public override string Difficulty => DifficultyType.Hard;

            public override string BaseGameMode => GameModeType.Impoppable;

            

            public override string DisplayName => "Mastery Mode";

            public override string Icon => VanillaSprites.Fortifried;

            public override void ModifyBaseGameModeModel(ModModel gameModeModel)
            {
                gameModeModel.SetStartingRound(10);
            if (FastTrackEnabled == false)
            {
                gameModeModel.SetStartingCash(1500);
            }

                gameModeModel.SetEndingRound(140);

                gameModeModel.SetSellingEnabled(false);
                gameModeModel.SetPowersEnabled(false);
                gameModeModel.SetContinuesEnabled(false);
                gameModeModel.SetIncomeEnabled(false);
              //  gameModeModel.SetMkEnabled(false);
                gameModeModel.UseRoundSet<HarderRounds>();
            gameModeModel.SetSellMultiplier(0f);

            
             gameModeModel.SetAllCashMultiplier(0.25f);
            gameModeModel.AddMutator(new LockTowerModModel("lockingurmom", "BananaFarm"));
            gameModeModel.AddMutator(new MonkeyMoneyModModel("mrkrabs", 2));
            gameModeModel.AddMutator(new DisableMonkeyKnowledgeModModel("fr this works"));
            

                
                

            }
        }
    public class SupportOnly : ModGameMode
    {
        public override string Difficulty => DifficultyType.Hard;

        public override string BaseGameMode => GameModeType.Impoppable;

        public override string DisplayName => "Support Only";

        public override string Icon => VanillaSprites.SupportBtn;

        public override void ModifyBaseGameModeModel(ModModel gameModeModel)
        {
            gameModeModel.LockTowerSet(TowerSet.Primary);
            gameModeModel.LockTowerSet(TowerSet.Military);
            gameModeModel.LockTowerSet(TowerSet.Magic);
           
        }
    }
    public class SpeedyBloons : ModGameMode
    {
        public override string Difficulty => DifficultyType.Medium;

        public override string BaseGameMode => GameModeType.Medium;

        public override string DisplayName => "Speedier Bloons";

        public override string Icon => VanillaSprites.BloonBoostIcon;

        public override void ModifyBaseGameModeModel(ModModel gameModeModel)
        {
            gameModeModel.AddMutator(new GlobalSpeedModModel("yippee", BloonSpeedBoost, 0));
            gameModeModel.SetEndingRound(80);

        }
    }
    public class HealthierBloons : ModGameMode
    {
        public override string Difficulty => DifficultyType.Medium;

        public override string BaseGameMode => GameModeType.Hard;

        public override string DisplayName => "Healthier Bloons";

        public override string Icon => VanillaSprites.BadBloonIcon;

        public override void ModifyBaseGameModeModel(ModModel gameModeModel)
        {
            gameModeModel.AddMutator(new BloonHealthModel("yippesdsade", MoabHpScale, "Moabs"));
            gameModeModel.AddMutator(new BloonHealthModel("yahooo", CeramicHpScale, "Ceramic"));
            gameModeModel.SetEndingRound(80);
        }
    }

    public class RandomizedRounds: ModGameMode
    {
        public override string Difficulty => DifficultyType.Medium;

        public override string BaseGameMode => GameModeType.Hard;

        public override string DisplayName => "Random Rounds";

        public override string Icon => "RandRounds-Icon";

        public override void ModifyBaseGameModeModel(ModModel gameModeModel)
        {
            gameModeModel.UseRoundSet<RandomizedRound>();
            gameModeModel.SetEndingRound(80);
        }
    }
    public class OneRedBloon : ModGameMode
    {
        public override string Difficulty => DifficultyType.Easy;

        public override string BaseGameMode => GameModeType.Hard;

        public override string DisplayName => "One Red Bloon";

        public override string Icon => VanillaSprites.BloonDecreaseHPIcon;

        public override void ModifyBaseGameModeModel(ModModel gameModeModel)
        {
            
            gameModeModel.SetEndingRound(140);
            gameModeModel.UseRoundSet<OneRedBloonSet>();
        }
    }
    public class BossRushGamemode : ModGameMode
    {
        public override string Difficulty => DifficultyType.Hard;

        public override string BaseGameMode => GameModeType.Medium;

        public override string DisplayName => "Boss Rush";

        public override string Icon => VanillaSprites.LychEliteBadge;

        public override void ModifyBaseGameModeModel(ModModel gameModeModel)
        {

            gameModeModel.SetEndingRound(130);
            gameModeModel.UseRoundSet<BossRushSet>();
            gameModeModel.AddMutator(new GlobalSpeedModModel("solwaw", 0.8f, 0));
            gameModeModel.AddMutator(new BloonHealthModel("solwaw", 0.9f, "Moabs"));
            gameModeModel.SetStartingCash(2000);
        }
    }
    public class BossRushSet : ModRoundSet
    {
        public override string BaseRoundSet => RoundSetType.Default;
        public override int DefinedRounds => BaseRounds.Count;
        public override string DisplayName => "Boss Rush Set";



        public override string Icon => VanillaSprites.LychBadge;

        public override void ModifyRoundModels(RoundModel roundModel, int round)
        {
            string isElite = "";
            if (EliteBosses)
            {
                isElite = "Elite";
            }

            switch (round)
            {
                case 39:
                   // roundModel.ClearBloonGroups();
                 
                    roundModel.AddBloonGroup("Bloonarius" + isElite + "1", 1 , BossSpawningSpeed * 0, BossSpawningSpeed * 1);
                   roundModel.AddBloonGroup("Rainbow", Convert.ToInt32(BossSpawningSpeed), 0, BossSpawningSpeed * 60);
                    
                    foreach (var group in roundModel.groups) { 
                        var bloon = Game.instance.model.GetBloon(group.bloon);
                        if (bloon.isBoss)
                        {
                            bloon.leakDamage = 32767;
                        }
                    }
                        break;
                case 40:
                  //  roundModel.ClearBloonGroups();

                    roundModel.AddBloonGroup("Lych" + isElite + "1", 1, BossSpawningSpeed * 0, BossSpawningSpeed * 1);
                    roundModel.AddBloonGroup("Moab", Convert.ToInt32(Il2CppAssets.Scripts.Simulation.SMath.Math.Round(BossSpawningSpeed / 8)) + 1, BossSpawningSpeed *5, BossSpawningSpeed * 60);

                    foreach (var group in roundModel.groups)
                    {
                        var bloon = Game.instance.model.GetBloon(group.bloon);
                        if (bloon.isBoss)
                        {
                            bloon.leakDamage = 32767;
                        }
                    }
                    break;
                case 41:
                  //  roundModel.ClearBloonGroups();

                    roundModel.AddBloonGroup("Vortex" + isElite + "1", 1, BossSpawningSpeed * 0, BossSpawningSpeed * 1);
                    roundModel.AddBloonGroup("Moab", Convert.ToInt32(Il2CppAssets.Scripts.Simulation.SMath.Math.Round(BossSpawningSpeed / 10)) + 1, BossSpawningSpeed * 8, BossSpawningSpeed * 60);
                    roundModel.AddBloonGroup("Pink", Convert.ToInt32(Il2CppAssets.Scripts.Simulation.SMath.Math.Round(BossSpawningSpeed * 4)) + 1, BossSpawningSpeed * 8, BossSpawningSpeed * 60);

                    foreach (var group in roundModel.groups)
                    {
                        var bloon = Game.instance.model.GetBloon(group.bloon);
                        if (bloon.isBoss)
                        {
                            bloon.leakDamage = 32767;
                        }
                    }
                    break;
                case 42:
                 //   roundModel.ClearBloonGroups();

                    roundModel.AddBloonGroup("Dreadbloon" + isElite + "1", 1, BossSpawningSpeed * 0, BossSpawningSpeed * 1);
                    roundModel.AddBloonGroup("Ceramic", Convert.ToInt32(Il2CppAssets.Scripts.Simulation.SMath.Math.Round(BossSpawningSpeed / 9)) + 1, BossSpawningSpeed * 0, BossSpawningSpeed * 5);
                    

                    foreach (var group in roundModel.groups)
                    {
                        var bloon = Game.instance.model.GetBloon(group.bloon);
                        if (bloon.isBoss)
                        {
                            bloon.leakDamage = 32767;
                        }
                    }
                    break;



                case 59:
                  //  roundModel.ClearBloonGroups();

                    roundModel.AddBloonGroup("Bloonarius" + isElite + "2", 1, BossSpawningSpeed * 0, BossSpawningSpeed * 0);
                    roundModel.AddBloonGroup("Rainbow", Convert.ToInt32(BossSpawningSpeed * 3), 0, BossSpawningSpeed * 60);

                    foreach (var group in roundModel.groups)
                    {
                        var bloon = Game.instance.model.GetBloon(group.bloon);
                        if (bloon.isBoss)
                        {
                            bloon.leakDamage = 32767;
                        }
                    }
                    break;
                case 60:
                  //  roundModel.ClearBloonGroups();

                    roundModel.AddBloonGroup("Lych" + isElite + "2", 1, BossSpawningSpeed * 0, BossSpawningSpeed * 0);
                    roundModel.AddBloonGroup("Bfb", Convert.ToInt32(Il2CppAssets.Scripts.Simulation.SMath.Math.Round(BossSpawningSpeed / 15)) + 1, BossSpawningSpeed * 5, BossSpawningSpeed * 60);
                    roundModel.AddBloonGroup("Moab", Convert.ToInt32(Il2CppAssets.Scripts.Simulation.SMath.Math.Round(BossSpawningSpeed / 5)) + 1, BossSpawningSpeed * 5, BossSpawningSpeed * 60);

                    foreach (var group in roundModel.groups)
                    {
                        var bloon = Game.instance.model.GetBloon(group.bloon);
                        if (bloon.isBoss)
                        {
                            bloon.leakDamage = 32767;
                        }
                    }
                    break;
                case 61:
                 //   roundModel.ClearBloonGroups();

                    roundModel.AddBloonGroup("Vortex" + isElite + "2", 1, BossSpawningSpeed * 0, BossSpawningSpeed * 0);
                    roundModel.AddBloonGroup("MoabFortified", Convert.ToInt32(Il2CppAssets.Scripts.Simulation.SMath.Math.Round(BossSpawningSpeed / 9)) + 1, BossSpawningSpeed * 8, BossSpawningSpeed * 60);
                    roundModel.AddBloonGroup("Purple", Convert.ToInt32(Il2CppAssets.Scripts.Simulation.SMath.Math.Round(BossSpawningSpeed * 4)) + 1, BossSpawningSpeed * 8, BossSpawningSpeed * 60);

                    foreach (var group in roundModel.groups)
                    {
                        var bloon = Game.instance.model.GetBloon(group.bloon);
                        if (bloon.isBoss)
                        {
                            bloon.leakDamage = 32767;
                        }
                    }
                    break;
                case 62:
                  //  roundModel.ClearBloonGroups();

                    roundModel.AddBloonGroup("Dreadbloon" + isElite + "2", 1, BossSpawningSpeed * 0, BossSpawningSpeed * 0);
                   // roundModel.AddBloonGroup("DreadRockBloonStandard2", Convert.ToInt32(Il2CppAssets.Scripts.Simulation.SMath.Math.Round(BossSpawningSpeed / 9)) + 1, BossSpawningSpeed * 0, BossSpawningSpeed * 5);


                    foreach (var group in roundModel.groups)
                    {
                        var bloon = Game.instance.model.GetBloon(group.bloon);
                        if (bloon.isBoss)
                        {
                            bloon.leakDamage = 32767;
                        }
                    }
                    break;

                case 79:
                 //   roundModel.ClearBloonGroups();

                    roundModel.AddBloonGroup("Bloonarius" + isElite + "3", 1, BossSpawningSpeed * 0, BossSpawningSpeed * 0);
                    roundModel.AddBloonGroup("Bfb", Convert.ToInt32(BossSpawningSpeed / 4), 0, BossSpawningSpeed * 60);
                    roundModel.AddBloonGroup("Zomg", Convert.ToInt32(1), 0, BossSpawningSpeed * 60);

                    foreach (var group in roundModel.groups)
                    {
                        var bloon = Game.instance.model.GetBloon(group.bloon);
                        if (bloon.isBoss)
                        {
                            bloon.leakDamage = 32767;
                        }
                    }
                    break;
                case 80:
                //    roundModel.ClearBloonGroups();

                    roundModel.AddBloonGroup("Lych" + isElite + "3", 1, BossSpawningSpeed * 0, BossSpawningSpeed * 0);
                    roundModel.AddBloonGroup("Bfb", Convert.ToInt32(Il2CppAssets.Scripts.Simulation.SMath.Math.Round(BossSpawningSpeed / 8)) + 1, BossSpawningSpeed * 5, BossSpawningSpeed * 60);
                    roundModel.AddBloonGroup("MoabFortified", Convert.ToInt32(Il2CppAssets.Scripts.Simulation.SMath.Math.Round(BossSpawningSpeed )) + 1, BossSpawningSpeed * 5, BossSpawningSpeed * 60);

                    foreach (var group in roundModel.groups)
                    {
                        var bloon = Game.instance.model.GetBloon(group.bloon);
                        if (bloon.isBoss)
                        {
                            bloon.leakDamage = 32767;
                        }
                    }
                    break;
                case 81:
                 //   roundModel.ClearBloonGroups();

                    roundModel.AddBloonGroup("Vortex" + isElite + "3", 1, BossSpawningSpeed * 0, BossSpawningSpeed * 0);
                    roundModel.AddBloonGroup("BfbFortified", Convert.ToInt32(Il2CppAssets.Scripts.Simulation.SMath.Math.Round(BossSpawningSpeed / 5)) + 1, BossSpawningSpeed * 8, BossSpawningSpeed * 60);
                    roundModel.AddBloonGroup("Purple", Convert.ToInt32(Il2CppAssets.Scripts.Simulation.SMath.Math.Round(BossSpawningSpeed * 8)) + 1, BossSpawningSpeed * 1, BossSpawningSpeed * 60);

                    foreach (var group in roundModel.groups)
                    {
                        var bloon = Game.instance.model.GetBloon(group.bloon);
                        if (bloon.isBoss)
                        {
                            bloon.leakDamage = 32767;
                        }
                    }
                    break;
                case 82:
               //     roundModel.ClearBloonGroups();

                    roundModel.AddBloonGroup("Dreadbloon" + isElite + "3", 1, BossSpawningSpeed * 0, BossSpawningSpeed * 0);
                    roundModel.AddBloonGroup("DreadRockBloonStandard3", Convert.ToInt32(Il2CppAssets.Scripts.Simulation.SMath.Math.Round(BossSpawningSpeed / 9)) + 1, BossSpawningSpeed * 0, BossSpawningSpeed * 5);


                    foreach (var group in roundModel.groups)
                    {
                        var bloon = Game.instance.model.GetBloon(group.bloon);
                        if (bloon.isBoss)
                        {
                            bloon.leakDamage = 32767;
                        }
                    }
                    break;
                case 99:
                 //   roundModel.ClearBloonGroups();

                    roundModel.AddBloonGroup("Bloonarius" + isElite + "4", 1, BossSpawningSpeed * 0, BossSpawningSpeed * 0);
                    roundModel.AddBloonGroup("Zomg", Convert.ToInt32(BossSpawningSpeed / 4), 0, BossSpawningSpeed * 60);
                    roundModel.AddBloonGroup("Bad", Convert.ToInt32(1), 0, BossSpawningSpeed * 10);

                    foreach (var group in roundModel.groups)
                    {
                        var bloon = Game.instance.model.GetBloon(group.bloon);
                        if (bloon.isBoss)
                        {
                            bloon.leakDamage = 32767;
                        }
                    }
                    break;
                case 100:
                 //   roundModel.ClearBloonGroups();

                    roundModel.AddBloonGroup("Lych" + isElite + "4", 1, BossSpawningSpeed * 0, BossSpawningSpeed * 0);
                    roundModel.AddBloonGroup("Ddt", Convert.ToInt32(Il2CppAssets.Scripts.Simulation.SMath.Math.Round(BossSpawningSpeed / 4)) + 1, BossSpawningSpeed * 5, BossSpawningSpeed * 60);
                    roundModel.AddBloonGroup("BfbFortified", Convert.ToInt32(Il2CppAssets.Scripts.Simulation.SMath.Math.Round(BossSpawningSpeed)) + 1, BossSpawningSpeed * 5, BossSpawningSpeed * 60);

                    foreach (var group in roundModel.groups)
                    {
                        var bloon = Game.instance.model.GetBloon(group.bloon);
                        if (bloon.isBoss)
                        {
                            bloon.leakDamage = 32767;
                        }
                    }
                    break;
                case 101:
               //     roundModel.ClearBloonGroups();

                    roundModel.AddBloonGroup("Vortex" + isElite + "4", 1, BossSpawningSpeed * 0, BossSpawningSpeed * 0);
                    roundModel.AddBloonGroup("ZomgFortified", Convert.ToInt32(Il2CppAssets.Scripts.Simulation.SMath.Math.Round(BossSpawningSpeed / 5)) + 1, BossSpawningSpeed * 8, BossSpawningSpeed * 60);
                    roundModel.AddBloonGroup("Purple", Convert.ToInt32(Il2CppAssets.Scripts.Simulation.SMath.Math.Round(BossSpawningSpeed * 16)) + 1, BossSpawningSpeed * 1, BossSpawningSpeed * 60);

                    foreach (var group in roundModel.groups)
                    {
                        var bloon = Game.instance.model.GetBloon(group.bloon);
                        if (bloon.isBoss)
                        {
                            bloon.leakDamage = 32767;
                        }
                    }
                    break;
                case 102:
                //    roundModel.ClearBloonGroups();

                    roundModel.AddBloonGroup("Dreadbloon" + isElite + "4", 1, BossSpawningSpeed * 0, BossSpawningSpeed * 0);
                    roundModel.AddBloonGroup("DreadRockBloonStandard4", Convert.ToInt32(Il2CppAssets.Scripts.Simulation.SMath.Math.Round(BossSpawningSpeed / 9)) + 1, BossSpawningSpeed * 0, BossSpawningSpeed * 5);


                    foreach (var group in roundModel.groups)
                    {
                        var bloon = Game.instance.model.GetBloon(group.bloon);
                        if (bloon.isBoss)
                        {
                            bloon.leakDamage = 32767;
                        }
                    }
                    break;

                case 119:
                 //   roundModel.ClearBloonGroups();

                    roundModel.AddBloonGroup("Bloonarius" + isElite + "5", 1, BossSpawningSpeed * 0, BossSpawningSpeed * 0);
                    roundModel.AddBloonGroup("ZomgFortified", Convert.ToInt32(BossSpawningSpeed / 1.4444f), 0, BossSpawningSpeed * 60);
                    roundModel.AddBloonGroup("Bad", Convert.ToInt32(5), 0, BossSpawningSpeed * 10);

                    foreach (var group in roundModel.groups)
                    {
                        var bloon = Game.instance.model.GetBloon(group.bloon);
                        if (bloon.isBoss)
                        {
                            bloon.leakDamage = 32767;
                        }
                    }
                    break;
                case 120:
                 //   roundModel.ClearBloonGroups();

                    roundModel.AddBloonGroup("Lych" + isElite + "5", 1, BossSpawningSpeed * 0, BossSpawningSpeed * 0);
                    roundModel.AddBloonGroup("DdtFortifiedCamo", Convert.ToInt32(Il2CppAssets.Scripts.Simulation.SMath.Math.Round(BossSpawningSpeed / 2)) + 1, BossSpawningSpeed * 5, BossSpawningSpeed * 60);
                    roundModel.AddBloonGroup("ZomgFortified", Convert.ToInt32(Il2CppAssets.Scripts.Simulation.SMath.Math.Round(BossSpawningSpeed)/2) + 1, BossSpawningSpeed * 5, BossSpawningSpeed * 60);

                    foreach (var group in roundModel.groups)
                    {
                        var bloon = Game.instance.model.GetBloon(group.bloon);
                        if (bloon.isBoss)
                        {
                            bloon.leakDamage = 32767;
                        }
                    }
                    break;
                case 121:
               //     roundModel.ClearBloonGroups();

                    roundModel.AddBloonGroup("Vortex" + isElite + "5", 1, BossSpawningSpeed * 0, BossSpawningSpeed * 0);
                    roundModel.AddBloonGroup("ZomgFortified", Convert.ToInt32(Il2CppAssets.Scripts.Simulation.SMath.Math.Round(BossSpawningSpeed / 5)) + 1, BossSpawningSpeed * 8, BossSpawningSpeed * 60);
                    roundModel.AddBloonGroup("Purple", Convert.ToInt32(Il2CppAssets.Scripts.Simulation.SMath.Math.Round(BossSpawningSpeed * 64)) + 1, BossSpawningSpeed * 5, BossSpawningSpeed * 60);

                    foreach (var group in roundModel.groups)
                    {
                        var bloon = Game.instance.model.GetBloon(group.bloon);
                        if (bloon.isBoss)
                        {
                            bloon.leakDamage = 32767;
                        }
                    }
                    break;
                case 122:
                //    roundModel.ClearBloonGroups();

                    roundModel.AddBloonGroup("Dreadbloon" + isElite + "5", 1, BossSpawningSpeed * 0, BossSpawningSpeed * 0);
                    roundModel.AddBloonGroup("DreadRockBloonStandard4", Convert.ToInt32(Il2CppAssets.Scripts.Simulation.SMath.Math.Round(BossSpawningSpeed / 9)) + 1, BossSpawningSpeed * 0, BossSpawningSpeed * 5);


                    foreach (var group in roundModel.groups)
                    {
                        var bloon = Game.instance.model.GetBloon(group.bloon);
                        if (bloon.isBoss)
                        {
                            bloon.leakDamage = 32767;
                        }
                    }
                    break;














                default:
                    
                    foreach (var group in roundModel.groups)
                    {
                        var bloon = Game.instance.model.GetBloon(group.bloon);
                        string[] bloonboost = { "Red", "Blue", "Green", "Yellow", "Pink", "White", "Black", "Purple", "Zebra", "Lead", "Rainbow" };
                        foreach (var str in bloonboost)
                        {
                            if (bloon.name.Contains(str))
                            {
                                group.bloon = PromoteBloon(group.bloon, round, MasterModeScale);
                            }
                        }
                        
                    }
                    var roundmulti = RoundMultiplyier(round);
                    if (round > 43)
                    {
                        
                        roundModel.groups.ForEach(group =>
                        {

                            var lenght = group.end * roundmulti;
                            group.end = (int)lenght;

                        });
                    }
                    break;
            }
        }
    }
}



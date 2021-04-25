using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct MusicNames //struct that has reference to name of sound clips
{
    public static string MainMenu = "Froot Punch_Menu Music_FINAL.1";
    public static string Level1 = "Froot Punch_Main Music_FINAL.1";
    public static string BossMusic = "Froot Punch_Boss Music_FINAL.1";

    public string getMain()
    {
        return MainMenu;
    }
    public string getLevel1()
    {
        return Level1;
    }
    public string getBoss()
    {
        return BossMusic;
    }
}


public struct FXNames //struct that has reference to name of sound clips
{
    public static string ButtonHover = "Button Hit";
    public static string Defeat = "Defeat-3";
    public static string Victory = "Victory-3";
    public string getButtonHit()
    {
        return ButtonHover;
    }

    public string getDefeat()
    {
        return Defeat;
    }

    public string getVictory()
    {
        return Victory;
    }
}
public static class SceneConstants
{
    //Static animation variables
    static public string IdleAnim = "Idle";
    static public string WalkAnim = "Walk";
    static public string PunchChargeAnim = "PunchCharge";
    static public string PunchReleaseAnim = "PunchRelease";
    static public string Punch = "Punch";
    static public string Death = "Death";
    static public MusicNames musicNames = new MusicNames();
    static public FXNames fxNames;
}

public enum SceneName{
  PersistantData = 0,
  MainMenu = 1,
  Level_1 = 2,
  settings =3
}



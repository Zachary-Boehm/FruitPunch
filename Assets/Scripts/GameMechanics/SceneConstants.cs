using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct MusicNames //struct that has reference to name of sound clips
{
    public static string MainMenu = "Menu Music";
    public static string Level1 = "General THeme";
}


public struct FXNames //struct that has reference to name of sound clips
{
    public static string ButtonHover = "Button Hit";
}
public static class SceneConstants
{
    //Static animation variables
    static public string IdleAnim = "Idle";
    static public string WalkAnim = "Walk";
    static public string PunchChargeAnim = "PunchCharge";
    static public string PunchReleaseAnim = "PunchRelease";
    static public string Punch = "Punch";

    static public MusicNames musicNames;
    static public FXNames fxNames;
}

public enum SceneName{
  PersistantData = 0,
  MainMenu = 1,
  Level_1 = 2,
  settings =3
}



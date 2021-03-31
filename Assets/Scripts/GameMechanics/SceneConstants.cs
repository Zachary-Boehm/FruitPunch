using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct MusicNames //struct that has reference to name of sound clips
{
    public static string MainMenu = "Menu Music";
    public static string Level1 = "General THeme";
}

public static class SceneConstants
{
    //Static animation variables
    static public string IdleAnim = "Idle";
    static public string WalkAnim = "Walk";
    static public string PunchChargeAnim = "PunchCharge";
    static public string PunchReleaseAnim = "PunchRelease";

    static public MusicNames musicNames;
}

public enum SceneName{
  PersistantData = 0,
  MainMenu = 1,
  LoadingScene = 2,
  Level_1 = 3,
  settings = 4
}



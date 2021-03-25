using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SceneConstants
{
    //Static animation variables
    static public string IdleAnim = "Idle";
    static public string WalkAnim = "Walk";
    static public string PunchChargeAnim = "PunchCharge";
    static public string PunchReleaseAnim = "PunchRelease";
}
public enum SceneName{
  PersistantData = 0,
  MainMenu = 1,
  LoadingScene = 2,
  Level_1 = 3
}

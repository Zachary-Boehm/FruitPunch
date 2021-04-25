using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WinLossController : MonoBehaviour
{
    
    private string FAILURE = "FAILURE";
    private string VICTORY = "VICTORY";

    private string activeState = "FAILURE"; //Either a victory or failure state

    [Header("Reference Variables")]
    [SerializeField] private TextMeshProUGUI Title;
    [SerializeField] private Animator WinLossAnimation;
    public void ActivateLoss()
    {
        //Change the text
        Title.text = FAILURE;
        activeState = FAILURE;
        GameManager.GAMEMANAGER.stopMusic();
        GameManager.GAMEMANAGER.playFX(SceneConstants.fxNames.getDefeat());
        //Fade in the screen
        //animate the title
        //animate the buttons
        WinLossAnimation.Play("Base Layer." + FAILURE, 0);
    }

    public void ActivateWin()
    {
        //Change the text
        Title.text = VICTORY;
        activeState = VICTORY;
        GameManager.GAMEMANAGER.stopMusic();
        GameManager.GAMEMANAGER.playFX(SceneConstants.fxNames.getVictory());
        //Fade in the screen
        //animate the title
        //animate the buttons
        WinLossAnimation.Play("Base Layer." + VICTORY, 0);
    }

    public void loadScene(int sceneName){
        WinLossAnimation.Play("Base Layer." + "FadeOut", 0);
        GameManager.GAMEMANAGER.loadScene((SceneName)sceneName); //Start coroutine to load in new scene
    }
}

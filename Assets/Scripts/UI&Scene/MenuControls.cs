 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{
    //private IEnumerator Start() {
    //yield return new WaitForSeconds(3.0f);
    //SceneManager.LoadScene(1);
    //}

    int volumeLevel = 5;

    public void startGame(){

        GameManager.GAMEMANAGER.loadScene(SceneName.Level_1); //Start coroutine to load in new scene
    }

    //Method will exit the game
    public void exitGame()
    {   
      Application.Quit();
    }

    //Will open the settings menu
    public void enterSettings()
    {
        GameManager.GAMEMANAGER.openSettings();
    }
    //exit settins menu
    public void exitSettings()
    {
        GameManager.GAMEMANAGER.closeSettings();
    }
    //return to main menu
    public void goToMain()
    {
        GameManager.GAMEMANAGER.loadScene(SceneName.MainMenu);//load main menu
    }

    public void playButtonHover()
    {
        GameManager.GAMEMANAGER.playFX("Button Hit");
    }
}

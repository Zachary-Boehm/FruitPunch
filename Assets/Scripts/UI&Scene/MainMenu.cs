 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //private IEnumerator Start() {
    //yield return new WaitForSeconds(3.0f);
    //SceneManager.LoadScene(1);
    //}

    int volumeLevel = 5;

    public void startGame(){
      
      StartCoroutine(LoadScene((int)SceneName.Level_1)); //Start coroutine to load in new scene
    }

    //Coroutine that will load in new scene
    IEnumerator LoadScene(int scene)
    {
      yield return new WaitForSeconds(1f);
      SceneManager.LoadScene(scene);
    }

    //Method will exit the game
    public void exitGame()
    {   
      Application.Quit();
    }

    //Will open the settings menu
    public void enterSettings()
    {
        StartCoroutine(LoadScene(4));
    }

    //return to main menu
    public void goToMain()
    {
        StartCoroutine(LoadScene((int)SceneName.MainMenu));
    }


    public void VolumeUp()
    {
        volumeLevel++;
    }

    public void volumeDown()
    {
        volumeLevel--;
    }
}

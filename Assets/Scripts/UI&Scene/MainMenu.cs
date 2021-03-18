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

    public void startGame(){
      
      StartCoroutine(LoadScene(1));
    }

    IEnumerator LoadScene(int scene)
    {
      yield return new WaitForSeconds(1f);
      SceneManager.LoadScene(scene);
    }

    public void exitGame()
    {   if (UnityEditor.EditorApplication.isPlaying == true)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }

    public void enterSettings()
    {

        StartCoroutine(LoadScene(3));
    }

    public void goToMain()
    {

        StartCoroutine(LoadScene(0));
    }
}

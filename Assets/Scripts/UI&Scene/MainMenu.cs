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
      
      StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
      yield return new WaitForEndOfFrame();
      SceneManager.LoadScene(1);
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

        StartCoroutine(LoadSettings());
    }


    IEnumerator LoadScene()
    {
        yield return new WaitForEndOfFrame();
        SceneManager.LoadScene(3);
    }

    public void goToMain()
    {

        StartCoroutine(LoadMain());
    }

    IEnumerator LoadMain()
    {
        yield return new WaitForEndOfFrame();
        SceneManager.LoadScene(0);
    }
}

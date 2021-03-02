using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneLoading : MonoBehaviour
{

    [SerializeField]
    private Image ProgressBar; 

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadAsyncOperation());
    }

    IEnumerator LoadAsyncOperation()
    {
      AsyncOperation gameLevel = SceneManager.LoadSceneAsync(2);
      while(gameLevel.progress < 1)
      {
        ProgressBar.fillAmount = gameLevel.progress;
        yield return new WaitForEndOfFrame();
      }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingMenu : MonoBehaviour
{
    int volumeLevel = 5;
    // Start is called before the first frame update
    IEnumerator LoadScene(int scene)
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(scene);
    }

    public void goToMain()
    {
        StartCoroutine(LoadScene(0));
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
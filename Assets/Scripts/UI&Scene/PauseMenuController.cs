using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField]private GameObject PauseMenu;
    [SerializeField]private GameObject Player;
    [SerializeField]private GameObject[] ActiveObjects;
    public void OpenMenu()
    {
        Time.timeScale = 0;
        PauseMenu.GetComponent<Canvas>().enabled = true;
        Player.GetComponent<PlayerController>().enabled = false;
        Player.GetComponent<ActorVariables>().Direction = Vector2.zero;
        Player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    public void CloseMenu()
    {
        PauseMenu.GetComponent<Canvas>().enabled = false;
        Player.GetComponent<PlayerController>().enabled = true;
        Time.timeScale = 1;
    }

    public void mainMenu()
    {
        SceneManager.LoadScene((int)SceneName.MainMenu);//Load The main menu
    }

    public void settingsMenu()
    {
        SceneManager.LoadScene(4);
    }

    public void deselectButton()
    {
        GameObject.Find("EventSystem").GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null); //Deselects whatever button was just used
    }

    public void quit()
    {
        Application.Quit();
    }
}

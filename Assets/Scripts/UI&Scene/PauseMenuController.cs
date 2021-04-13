using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField]private GameObject PauseMenu;//Reference of pause menu object
    [SerializeField]private GameObject Player; //Reference to the player
    
    //Method will handle logic for opening pause menu
    public void OpenMenu()
    {
        Time.timeScale = 0; //Set time scale to 0
        PauseMenu.GetComponent<Canvas>().enabled = true; //Turn on pause menu
        Player.GetComponent<PlayerController>().enabled = false; //Stop player movement
        Player.GetComponent<ActorVariables>().Direction = Vector2.zero; //set global direction to zero
        Player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;//Set player velocity to zero
    }

    //Method will handle the logic for closing the pause menu
    public void CloseMenu()
    {
        PauseMenu.GetComponent<Canvas>().enabled = false; //Turn off pause menu
        Player.GetComponent<PlayerController>().enabled = true; //Allow player movement
        Time.timeScale = 1; //Set time scale back to normal
    }

    //Go to main menu
    public void mainMenu()
    {
        Time.timeScale = 1;//so coroutines will work
        GameManager.GAMEMANAGER.loadScene(SceneName.MainMenu);//load main menu
    }

    //Go to settings menu
    public void settingsMenu()
    {
        GameManager.GAMEMANAGER.openSettings();
    }

    //This method will remove button from event system as selected button
    public void deselectButton()
    {
        GameObject.Find("EventSystem").GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null); //Deselects whatever button was just used
    }

    //Quits the game
    public void quit()
    {
        Application.Quit();
    }

    public void playFX(string fxName)
    {
        GameManager.GAMEMANAGER.playFX(fxName);
    }
}

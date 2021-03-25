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
    public void OpenMenu(){
      PauseMenu.GetComponent<Canvas>().enabled = true;
      Player.GetComponent<PlayerController>().enabled = false;
      Player.GetComponent<StaticVariables>().Direction = Vector2.zero;
      Player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
      foreach(GameObject g in ActiveObjects){
        g.GetComponent<StaticVariables>().isAttacking = true;
        g.GetComponent<AnimationController>().ChangeAnim(0);
      }
    }

    public void CloseMenu(){
      PauseMenu.GetComponent<Canvas>().enabled = false;
      Player.GetComponent<PlayerController>().enabled = true;
      foreach(GameObject g in ActiveObjects){
        g.GetComponent<StaticVariables>().isAttacking = false;
      }
    }

    public void mainMenu(){
      SceneManager.LoadScene((int)SceneName.MainMenu);//Load The main menu
    }

    public void settingsMenu(){
      SceneManager.LoadScene(4);
    }

    public void deselectButton(){
      GameObject.Find("EventSystem").GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null); //Deselects whatever button was just used
    }

    public void quit(){
      Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    [SerializeField] private GameObject overlay;
    public void startGame()
    {
        GameManager.GAMEMANAGER.setCanMove(true);
        overlay.SetActive(false);
    }
}

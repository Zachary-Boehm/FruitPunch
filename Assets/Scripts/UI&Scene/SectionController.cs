using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class SectionController : MonoBehaviour
{
    [SerializeField] private Collider2D barrier;
    [SerializeField] private Collider2D trigger;
    [SerializeField] private string AudioClip;
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private GameObject[] itemsToTurnOn;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.isTrigger == false)
        {
            //Check for null elements and remove them
            enemies = enemies.Where(x => x != null).ToArray();
            //Only allow the trigger to activate when all enemies are dead
            if (enemies.Length == 0)
            {
                //Show an arrow on where the player can go
                barrier.enabled = false;
                GetComponent<SpriteRenderer>().enabled = true;

            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //Camera Move
        if (enemies.Length <= 0)
        {
            //New Area and block the previous area off
            barrier.enabled = true;

            //GetComponent<SpriteRenderer>().enabled = false; //!turn on when camera system is in

            trigger.enabled = false;

            if (AudioClip != "")
            {
                GameManager.GAMEMANAGER.playMusic(SceneConstants.musicNames.getBoss());
            }
            foreach (GameObject o in itemsToTurnOn)
            {
                o.SetActive(true);
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialController : MonoBehaviour
{
    [SerializeField] private GameObject overlay;
    [SerializeField] private Button[] continueButtons;
    [SerializeField] private Animator textFadeAnim;
    
    [SerializeField] private TextMeshProUGUI dialogueBox;
    [TextArea(5,10)]
    [SerializeField] private string[] dialogue;
    private int currentDialogue = 0;
    
    private void Start() 
    {
        dialogueBox.text = dialogue[currentDialogue];
        textFadeAnim.Play("Base Layer." + "FadeIn", 0);
    }
    public void startGame()
    {
        GameManager.GAMEMANAGER.setCanMove(true);
        overlay.SetActive(false);
    }

    public void nextText()
    {
        //play fade out anim
        textFadeAnim.Play("Base Layer." + "FadeOut", 0);
        
        currentDialogue++;
        if(currentDialogue + 1 == dialogue.Length)
        {
            //Change the next button to the start button
            swapToStart();
        }
    }

    public void doneFadeOut()
    {
        //Change text
        dialogueBox.text = dialogue[currentDialogue];
        //play fade in anim
        textFadeAnim.Play("Base Layer." + "FadeIn", 0);
    }

    public void swapToStart()
    {
        continueButtons[0].gameObject.SetActive(false);
        continueButtons[1].gameObject.SetActive(true);
    }
}

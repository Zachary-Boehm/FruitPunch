using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Vector2 oldDir; //Old direction of object
    [SerializeField] private Vector2 newDir; //new direction of object
    [SerializeField] private Animator animator; //objects animator
    [SerializeField] private bool flipMode;//True means starts flipped
    [SerializeField] private string AnimLabel;//First part of animation labels
    private SpriteRenderer spriteRend; //Sprite renderer for object
    [SerializeField]private bool idling = true;
    private int currentAnim = 0; //Current animation for object
    private void Start() {
      oldDir = Vector2.zero;
      animator = GetComponent<Animator>();
      spriteRend = GetComponent<SpriteRenderer>();

    }
    // Update is called once per frame
    void Update()
    {
      newDir = GetComponent<StaticVariables>().Direction;
      if(newDir.x != oldDir.x){
        idling = false;
        Debug.Log("Directions are not the same");
        if(newDir.x < 0){
          spriteRend.flipX = flipMode;
          ChangeAnim(1); //walk left
        }else if(newDir.x > 0){
          spriteRend.flipX = !flipMode;
          ChangeAnim(2);//walk right
        }
        oldDir = newDir;
      }else if(oldDir.x == 0 && !idling){
        ChangeAnim(0);//idle
        if(oldDir.x > 0){ //right
          spriteRend.flipX = !flipMode;
        }else if( oldDir.x < 0){ //left
          spriteRend.flipX = flipMode;
        }
        idling = true;
      }
    }

    private void ChangeAnim(int animation){
      if(currentAnim != animation){
        switch(animation){
          case 0: //idle
            animator.Play("Base Layer." + AnimLabel + "Idle", 0);
          break;
          case 1: //walk left
            //invert the image
            animator.Play("Base Layer." + AnimLabel + "Walk", 0);
          break;
          case 2://walk right
            //make sure image is not inverted
            animator.Play("Base Layer." + AnimLabel + "Walk", 0);
          break;
          case 3://attack
            animator.Play("");
          break;
        }
        currentAnim = animation;
      }
      
    }
}

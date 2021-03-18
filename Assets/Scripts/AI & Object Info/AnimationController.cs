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
    [SerializeField]private int currentAnim = 0; //Current animation for object
    private StaticVariables Variables;
    private void Start() {
      oldDir = Vector2.zero;
      animator = GetComponent<Animator>();
      spriteRend = GetComponent<SpriteRenderer>();
      Variables = GetComponent<StaticVariables>();
    }
    // Update is called once per frame
    void Update()
    {
      if(!Variables.isAttacking){
        newDir = Variables.Direction;
        if(newDir.x != oldDir.x || newDir.y != oldDir.y){
          idling = false;
          if(newDir.x < 0){
            spriteRend.flipX = flipMode;
            ChangeAnim(1); //walk left
          }else if(newDir.x > 0){
            spriteRend.flipX = !flipMode;
            ChangeAnim(2);//walk right
          }
          if(newDir.x == 0 && newDir.y != 0)
          {
            Debug.Log("Vertical Movement");
            if(Variables.AttackDirection.x < 0){
              spriteRend.flipX = flipMode;
              ChangeAnim(1); //walk left
            }else if(Variables.AttackDirection.x > 0){
              spriteRend.flipX = !flipMode;
              ChangeAnim(2);//walk right
            }
          }
          oldDir = newDir;
        }else if(oldDir.x == 0 && oldDir.y == 0 && !idling){
          ChangeAnim(0);//idle
          if(oldDir.x > 0){ //right
            spriteRend.flipX = !flipMode;
          }else if( oldDir.x < 0){ //left
            spriteRend.flipX = flipMode;
          }
          idling = true;
        }
      }
    }

    public void ChangeAnim(int animation, string attackType = ""){
      if(currentAnim != animation || animation == 3){
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
          case 3://attack charge
            animator.Play("Base Layer." + AnimLabel + attackType, 0);
          break;
        }
        currentAnim = animation;
      }
      
    }
    public void EndAttack(int animation){
      ChangeAnim(animation);
      oldDir = Vector2.zero;
      Variables.isAttacking = false;
    }
}

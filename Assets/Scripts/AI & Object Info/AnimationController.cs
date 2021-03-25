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
    [SerializeField]private string currentAnim = "Idle"; //Current animation for object
    private ActorVariables Variables;
    private void Start() {
      oldDir = Vector2.zero;
      animator = GetComponent<Animator>();
      spriteRend = GetComponent<SpriteRenderer>();
      Variables = GetComponent<ActorVariables>();
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
            ChangeAnim(SceneConstants.WalkAnim); //walk left
          }else if(newDir.x > 0){
            spriteRend.flipX = !flipMode;
            ChangeAnim(SceneConstants.WalkAnim);//walk right
          }
          if(newDir.x == 0 && newDir.y != 0)
          {
            if(Variables.AttackDirection.x < 0){
              spriteRend.flipX = flipMode;
              ChangeAnim(SceneConstants.WalkAnim); //walk left
            }else if(Variables.AttackDirection.x > 0){
              spriteRend.flipX = !flipMode;
              ChangeAnim(SceneConstants.WalkAnim);//walk right
            }
          }
          oldDir = newDir;
        }else if(oldDir.x == 0 && oldDir.y == 0 && !idling){
          ChangeAnim(SceneConstants.IdleAnim);//idle
          if(oldDir.x > 0){ //right
            spriteRend.flipX = !flipMode;
          }else if( oldDir.x < 0){ //left
            spriteRend.flipX = flipMode;
          }
          idling = true;
        }
      }
    }

    public void ChangeAnim(string animation){
      if(currentAnim != animation){
        animator.Play("Base Layer." + AnimLabel + animation, 0);
        currentAnim = animation;
      }
      
    }
    public void EndAnimation(string nextAnimation)
    {
        ChangeAnim(nextAnimation);
        oldDir = Vector2.zero;
        Variables.isAttacking = false;
    }
}

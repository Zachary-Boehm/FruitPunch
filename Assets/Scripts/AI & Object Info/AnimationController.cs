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
    [SerializeField]private bool idling = true; //Toggle for whether the object is idling
    [SerializeField]private string currentAnim = "Idle"; //Current animation for object
    private ActorVariables Variables;//Global variables for this object

    private void Start()
    {
        oldDir = Vector2.zero; //Start with a default zero vector for old direction
        animator = GetComponent<Animator>(); //Reference to the objects animator
        spriteRend = GetComponent<SpriteRenderer>(); //Reference to the Sprite renderer for the object
        Variables = GetComponent<ActorVariables>();//Reference to this objects global variables
    }

    // Update is called once per frame
    void Update()
    {
        if(!Variables.isAttacking)
        {
            newDir = Variables.Direction;
            if(newDir.x != oldDir.x || newDir.y != oldDir.y)
            {
                idling = false;
                if (newDir.x < 0)//moving left 
                {
                    spriteRend.flipX = flipMode;//flip image
                    ChangeAnim(SceneConstants.WalkAnim); //walk left anim
                }
                else if(newDir.x > 0)//moving right
                {
                    spriteRend.flipX = !flipMode;//flip image
                    ChangeAnim(SceneConstants.WalkAnim);//walk right anim
                }
                if(newDir.x == 0 && newDir.y != 0) //if not moving horizontal but moving vertical
                {
                    if(Variables.AttackDirection.x < 0){//if looking left
                    spriteRend.flipX = flipMode;//flip image
                    ChangeAnim(SceneConstants.WalkAnim); //walk left anim
                    }else if(Variables.AttackDirection.x > 0)//if looking right
                    {
                    spriteRend.flipX = !flipMode;//flip image
                    ChangeAnim(SceneConstants.WalkAnim);//walk right anim
                    }
                }
                oldDir = newDir;//update old direction
            }else if(oldDir.x == 0 && oldDir.y == 0 && !idling)
            {
                ChangeAnim(SceneConstants.IdleAnim);//idle anim
                if(oldDir.x > 0)//right moving
                { 
                    spriteRend.flipX = !flipMode;
                }else if( oldDir.x < 0)//left moving
                { 
                    spriteRend.flipX = flipMode;//flip image
                }
                idling = true;//set idling toggle to true
            }
        }
    }

    public void ChangeAnim(string animation)
    {
        if(currentAnim != animation)
        {
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

    public void GrapeEndAnimation(string nextAnimation)
    {
        ChangeAnim(nextAnimation);
        oldDir = Vector2.zero;
        Variables.isAttacking = false;
        GetComponent<Attack>().AttackTarget();
    }

    public void Death(int time)
    {
        Debug.Log("End of the line bucko");
        Destroy(this.gameObject);
    }
}

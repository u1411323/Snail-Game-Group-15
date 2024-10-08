using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] AnimationClip runAnim;
    [SerializeField] AnimationClip upAnim;
    [SerializeField] AnimationClip downAnim;
    [SerializeField] AnimationClip jumpAnim;
    [SerializeField] AnimationClip landAnim;
    Animator animator;
    //1 if positive Y, -1 if negative y, 0 if no y
    int velocityLastFrame = 0;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.speed = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        // Get the current animation state info
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // Only change animation if the current one has finished (normalizedTime >= 1)
        if (stateInfo.normalizedTime >= 1f)
        {

            //Walking, walking
            if ((int)(rb.velocity.y * 5) == 0 && velocityLastFrame == 0)
            {
                animator.Play(runAnim.name);
                velocityLastFrame = 0;
            }
            //Ascending, walking
            else if ((int)(rb.velocity.y * 5) == 0 && velocityLastFrame == 1)
            {
                animator.Play(landAnim.name);///transition
                velocityLastFrame = 0;
            }
            //Descending, walking
            else if ((int)(rb.velocity.y * 5) == 0 && velocityLastFrame == -1)
            {
                animator.Play(landAnim.name);///transition
                velocityLastFrame = 0;
            }
            //Walking, ascending
            else if (rb.velocity.y > 0 && velocityLastFrame == 0)
            {
                animator.Play(jumpAnim.name);///transition
                velocityLastFrame = 1;
            }
            //Ascending, Ascending
            else if (rb.velocity.y > 0 && velocityLastFrame == 1)
            {
                animator.Play(upAnim.name);
                velocityLastFrame = 1;
            }
            //Descending, ascending
            else if (rb.velocity.y > 0 && velocityLastFrame == -1)
            {
                animator.Play(upAnim.name);
                velocityLastFrame = 1;
            }
            //Walking, descending
            else if (rb.velocity.y < 0 && velocityLastFrame == 0)
            {
                animator.Play(downAnim.name);
                velocityLastFrame = -1;
            }
            //Ascending, descending
            else if (rb.velocity.y < 0 && velocityLastFrame == 1)
            {
                animator.Play(downAnim.name);
                velocityLastFrame = -1;
            }
            //Descending, descending
            else if (rb.velocity.y < 0 && velocityLastFrame == -1)
            {
                animator.Play(downAnim.name);
                velocityLastFrame = -1;
            }
        }
    }
}

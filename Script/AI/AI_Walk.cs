using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Walk : StateMachineBehaviour
{
       public  Transform myplayer;
    public Rigidbody2D rb;
    public float speed;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //myplayer = GameObject.FindGameObjectWithTag("Enemy2").transform;
       // rb = animator.GetComponentInParent<Rigidbody2D>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 target = new Vector2(myplayer.position.x, rb.position.y);
       Vector2 NewPos =  Vector2.MoveTowards(rb.position, target, speed * Time.deltaTime);
        rb.MovePosition(NewPos);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
   override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }


}

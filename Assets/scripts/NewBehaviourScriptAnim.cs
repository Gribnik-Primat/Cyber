using UnityEngine;
using System.Collections;

public class NewBehaviourScriptAnim : StateMachineBehaviour
{

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Transform trans = animator.transform;
        if (trans.GetComponent<PlayerInput>())
        {
            trans.GetComponent<PlayerMovement>().canMove = true;
        }
    }
} 
	
	


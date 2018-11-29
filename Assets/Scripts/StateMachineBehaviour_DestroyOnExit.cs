using UnityEngine;

public class StateMachineBehaviour_DestroyOnExit : StateMachineBehaviour
{

    override public void OnStateExit(Animator Animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Destroy(Animator.gameObject);
    }
}

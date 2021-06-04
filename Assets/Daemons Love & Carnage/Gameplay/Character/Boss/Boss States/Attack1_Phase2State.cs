using UnityEngine;

public class Attack1_Phase2State : StateMachineBehaviour
{
    ArcMovement arcMovement;
    public int i = 0;
    bool isMove;
    float initialPosition;
    bool isUp = false;

    [SerializeField] float arcSpeed;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        arcMovement = animator.GetComponent<ArcMovement>();
        initialPosition = animator.transform.position.y;     
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(i < 6 && isMove == false)
        {
            arcMovement.Arc();
            isMove = true;
            i++;
        }
             
        if (animator.transform.position.y >= arcMovement.height)
        {
            isUp = true;      
        }

        if(isUp)
            animator.transform.position = Vector3.MoveTowards(animator.transform.position, new Vector3( animator.transform.position.x, 
                                                                                                        initialPosition, 
                                                                                                        animator.transform.position.z),
                                                                                                        arcSpeed * Time.deltaTime);

        if (animator.transform.position.y == initialPosition && isMove == true)
        {
            isMove = false;
            isUp = false;
            if(i>2)
                arcMovement.cameraShake.ShakeElapsedTime = arcMovement.cameraShake.ShakeDuration;
        }      
        
        if(i == 6)
            animator.SetTrigger("GoToIdle");
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        i = 0;
    }
}

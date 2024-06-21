using UnityEngine;
using System.Collections;

public class FightAnimation : MonoBehaviour
{
    private Animator animator;
    private CharacterMover playerMover;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerMover = GetComponent<CharacterMover>();

    }

    public IEnumerator PlayAttackAnimation()
    {
        animator.SetTrigger("isAttacking");
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length-3.5f);
        //When attacking movement is frozen. Below line unlocks that.
        playerMover.SetIsCaught(false);

    }
    
}
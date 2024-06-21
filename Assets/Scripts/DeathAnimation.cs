using UnityEngine;
using System.Collections;

public class DeathAnimation : MonoBehaviour
{
    [SerializeField] private float timeBeforeDeath = 0.3f;
    private ParticleSystem ps;

    private void Awake()
    {
        ps = GetComponent<ParticleSystem>();
    }

    //I had a death animation which i decided not to use and I decided to use some blood particle effect
    //The comments below are about the previous animation.
    public IEnumerator PlayDeathAnimation()
    {
        //animator.SetTrigger("isDying");
        //Below part looks a bit slow to me so I commented it and gave a manual time for death
        //yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        //yield return new WaitForSeconds(timeBeforeDeath);
        
        
        
        ps.Play();
        yield return new WaitForSeconds(timeBeforeDeath);
    }
}
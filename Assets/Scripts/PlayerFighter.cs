using System.Collections;
using UnityEngine;

public class PlayerFighter : MonoBehaviour
{
    
    private FightAnimation fightAnimation;
    private LevelManager playerLevel;
    private DeathAnimation deathAnimation;
    
    private void Start()
    {
        fightAnimation = GetComponent<FightAnimation>();
        deathAnimation = GetComponent<DeathAnimation>();
        playerLevel = GetComponent<LevelManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            LevelManager enemyLevel = other.GetComponent<LevelManager>();

            if (enemyLevel != null && playerLevel != null)
            {
                if (playerLevel.GetLevel() > enemyLevel.GetLevel())
                {
                    //Attack enemy if you have a higher level
                    StartCoroutine(AttackEnemy(other.gameObject));
                }
                else
                {
                    //Enemy attacks you if he has a higher or equal level
                    StartCoroutine(HandleDefeat(other.gameObject, enemyLevel));
                }
            }
        }
    }

    private IEnumerator AttackEnemy(GameObject enemy)
    {
        yield return StartCoroutine(fightAnimation.PlayAttackAnimation());
        DeathAnimation enemyDeathAnimation = enemy.GetComponent<DeathAnimation>();
        if (enemyDeathAnimation != null)
        {
            yield return StartCoroutine(enemyDeathAnimation.PlayDeathAnimation());
        }
        Destroy(enemy);
    }

    private IEnumerator HandleDefeat(GameObject enemy, LevelManager enemyLevel)
    {
        //Code Below calls the enemyPatrol to stop patrol
        EnemyPatrol enemyPatrol = enemy.GetComponent<EnemyPatrol>();
        if (enemyPatrol != null)
        {
            enemyPatrol.StopPatrol();
        }
        
        FightAnimation enemyFightAnimation = enemy.GetComponent<FightAnimation>();
        
        if (enemyFightAnimation != null)
        {
            yield return StartCoroutine(enemyFightAnimation.PlayAttackAnimation());
        }
        
        if (deathAnimation != null)
        {
            yield return StartCoroutine(deathAnimation.PlayDeathAnimation());
        }        
        Destroy(gameObject);
        
        //Code Below calls the enemyPatrol to start patrol. Since game is over if you die, it does not really do anything
        //But in future it might be needed for something
        if (enemyPatrol != null && enemyPatrol.HasPatrolPath())
        {
            enemyPatrol.StartPatrol();
        }
        GameManager.Instance.GameOver();
    }
}

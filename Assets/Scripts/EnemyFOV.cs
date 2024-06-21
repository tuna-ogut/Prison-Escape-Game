using UnityEngine;

public class EnemyFOV : MonoBehaviour
{
    [SerializeField] EnemyPatrol enemyPatrol;
    //[SerializeField] Collider fovCollider;
    [SerializeField] CharacterMover playerMover;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enemyPatrol.StopPatrol();//stop patrol
            enemyPatrol.UpdateWaypoint(other.transform.position);//chase player
            playerMover.SetIsCaught(true);// freeze player
        }
    }
}
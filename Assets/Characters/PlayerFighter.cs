
using UnityEngine;

public class PlayerFighter : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            PlayerLevel enemyLevel = other.GetComponent<PlayerLevel>();
            PlayerLevel playerLevel = GetComponent<PlayerLevel>();
            
            if (playerLevel != null && enemyLevel != null)
            {
                if (playerLevel.GetLevel() > enemyLevel.GetLevel())
                {
                    Debug.Log("sadasdasd");
                    Destroy(other.gameObject);
                }
                else
                {
                    Destroy(gameObject);
                    GameManager.Instance.GameOver();

                }
            }
        }
    }

}

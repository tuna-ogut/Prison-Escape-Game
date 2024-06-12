using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeCollectable : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerLevel playerLevel = other.GetComponent<PlayerLevel>();
            if (playerLevel != null)
            {
                playerLevel.IncreaseLevel();
                Destroy(gameObject); // Remove the collectable from the scene
            }
        }
    }
}

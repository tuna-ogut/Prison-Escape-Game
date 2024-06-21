using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
                MakeCollectibleSpecificAction(other);
                Destroy(gameObject); 
        }
    }

    protected abstract void MakeCollectibleSpecificAction(Collider playerCollider);
}
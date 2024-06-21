
using UnityEngine;

public class KeyCollector : Collectable
{
    [SerializeField] private int keyID;
    protected override void MakeCollectibleSpecificAction(Collider playerCollider)
    {
        Player player = playerCollider.GetComponent<Player>();
        player.AddKey(keyID);
    }

    private void Start()
    {
        SetColor();
    }

    void SetColor()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = ColorManager.Instance.GetColor(keyID);
        }
    }
}

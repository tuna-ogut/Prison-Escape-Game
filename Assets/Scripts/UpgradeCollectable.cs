using UnityEngine;

public class UpgradeCollectable : Collectable
{
    protected override void MakeCollectibleSpecificAction(Collider player)
    {
        LevelManager playerLevel = player.GetComponent<LevelManager>();
        playerLevel.IncreaseLevel();
    }
}
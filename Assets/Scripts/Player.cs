
using UnityEngine;

//Player level could also be held here. Or this class can be called PlayerKey, PlayerInventory or something like that.
//For now it only handles key related things. In the future it could be more like an Inventory.
public class Player : MonoBehaviour
{
    private int collectedBlueKeys = 0;
    private int collectedRedKeys = 0;

    public void AddKey(int keyID)
    {
        Color color = ColorManager.Instance.GetColor(keyID);

        if (color == Color.blue)
        {
            collectedBlueKeys++;
            Debug.Log("Blue key acquired!!!");
        }
        else if (color == Color.red)
        {
            collectedRedKeys++;
            Debug.Log("Red key acquired!!!");

        }
        else if (color == Color.white)
        {
            Debug.Log("Unknown Key Acquired");
        }

    }

    public bool HasKey(int keyID)
    {
        if (ColorManager.Instance.GetColor(keyID) == Color.blue)
        {
            return collectedBlueKeys > 0;
        }
        
        if (ColorManager.Instance.GetColor(keyID) == Color.red)
        {
            return collectedRedKeys > 0;
        }
        return false;
    }

    public void DecrementKey(int keyID)
    {
        Color color = ColorManager.Instance.GetColor(keyID);

        if (color == Color.blue)
        {
            collectedBlueKeys--;
        }
        else if (color == Color.red)
        {
            collectedRedKeys--;
        }
        else if (color == Color.white)
        {
            Debug.Log("Unknown Key");
        }
    }
    
}
using System.Collections.Generic;
using UnityEngine;

//I decided to map integers with colors to see keys and doors as id's in inspector that is what this class does
public class ColorManager : MonoBehaviour
{
    public static ColorManager Instance { get; private set; }

    private Dictionary<int, Color> keyColorMapping = new Dictionary<int, Color>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeKeyColorMapping();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeKeyColorMapping()
    {
        keyColorMapping[1] = Color.red;
        keyColorMapping[2] = Color.blue;
        keyColorMapping[3] = Color.green;
    }

    public Color GetColor(int keyID)
    {
        if (keyColorMapping.ContainsKey(keyID))
        {
            return keyColorMapping[keyID];
        }
        return Color.white; // Default color if keyID not found
    }
}


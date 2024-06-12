using TMPro;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    [SerializeField] int level = 1;
    [SerializeField] TMP_Text levelText;

    void Start()
    {
        UpdateLevelText();
    }

    void UpdateLevelText()
    {
        levelText.text = "LEVEL " + level.ToString();
    }

    public void IncreaseLevel()
    {
        level++;
        UpdateLevelText();
    }

    public int GetLevel()
    {
        return level;
    }
}
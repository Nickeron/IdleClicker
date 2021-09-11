using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int gold;
    [SerializeField] TMPro.TextMeshProUGUI goldText;
    [SerializeField] Sprite[] backgrounds;
    [SerializeField] Image backgroundImage;

    int enemiesTillBackgroundChange;
    int startingEnemies = 3;
    int enemyIncrease = 2;
    int curLevel;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        goldText.text = "0";
        enemiesTillBackgroundChange = startingEnemies;
        curLevel = 1;
    }

    internal void AddGold(int amount)
    {
        gold += amount;
        UpdateGoldText();
    }
    
    internal void TakeGold(int amount)
    {
        gold -= amount;
        UpdateGoldText();
    }

    private void UpdateGoldText()
    {
        goldText.text = gold.ToString();
    }

    internal void BackgroundCheck()
    {
        enemiesTillBackgroundChange--;        

        if(enemiesTillBackgroundChange <= 0)
        {
            curLevel++;
            backgroundImage.sprite = backgrounds[curLevel % backgrounds.Length];            
            enemiesTillBackgroundChange = startingEnemies + (enemyIncrease * curLevel);
        }
    }
}

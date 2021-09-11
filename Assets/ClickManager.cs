using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    internal List<float> autoClickersLastTime = new List<float>();
    [SerializeField] int autoClickerPrice = 0;
    [SerializeField] TMPro.TextMeshProUGUI quantityText;

    private void Update()
    {
        for(int i = 0; i < autoClickersLastTime.Count; i++)
        {
            if(Time.time - autoClickersLastTime[i] >= 1.0f)
            {
                autoClickersLastTime[i] = Time.time;
                EnemyManager.Instance.curEnemy.Damage();
            }
        }
    }

    public void OnBuyAutoClicker()
    {
        if(GameManager.Instance.gold >= autoClickerPrice)
        {
            GameManager.Instance.TakeGold(autoClickerPrice);
            autoClickersLastTime.Add(Time.time);
            quantityText.text = $"x{autoClickersLastTime.Count}";
        }
    }
}

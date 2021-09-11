using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Image healthBarFill;    
    public int maxHealth;
    public int goldValue;

    [SerializeField] Animation dmgAnimation;
    private int _curHealth;

    private void Awake()
    {
        _curHealth = maxHealth;
    }

    public void Damage()
    {
        _curHealth--;

        dmgAnimation.Stop();
        dmgAnimation.Play();

        healthBarFill.fillAmount = (float) _curHealth / maxHealth;

        if(_curHealth < 0) Defeated();
    }

    public void Defeated()
    {
        EnemyManager.Instance.DefeatEnemy(gameObject, goldValue);
    }
}

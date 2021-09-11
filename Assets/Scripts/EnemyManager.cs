using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] Transform enemiesGroup;
    internal Enemy curEnemy;    

    public static EnemyManager Instance {  get; private set; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }        

        if(curEnemy == null)
        {
            CreateNewEnemy();
        }
    }

    void CreateNewEnemy()
    {
        curEnemy =  Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], enemiesGroup).GetComponent<Enemy>();
    }

    internal void DefeatEnemy(GameObject enemy, int goldValue)
    {
        GameManager.Instance.AddGold(goldValue);
        GameManager.Instance.BackgroundCheck();
        Destroy(enemy);
        CreateNewEnemy();
    }
}

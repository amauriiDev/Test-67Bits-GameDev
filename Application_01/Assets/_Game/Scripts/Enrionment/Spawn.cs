using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]private GameObject enemyPrefab;
    [SerializeField]private const float spawnTime = 4.0f;
    [SerializeField]private const int maxEnemy = 15;
    [SerializeField]private float time;
    [SerializeField]private int enemyCount;

    public int EnemyCount { get => enemyCount; set => enemyCount = value; }


    private void OnEnable()
    {
        EnemiesStack.OnUnstackEnemy+= UpdateCount;
    }
    void Start()
    {
        enemyCount = 0;
        time = spawnTime;
        SpawnEnemy();
    }

    void FixedUpdate()
    {
        if (enemyCount >= maxEnemy)
            return;
    
        SpawnEnemy();
    }

    void SpawnEnemy(){

        time-= Time.fixedDeltaTime;

        if (time <= 0)
        {
            time = spawnTime;
            enemyCount+=1;
            Instantiate(enemyPrefab, RandomLocal(), Quaternion.identity);
        }
    }

    Vector3 RandomLocal(){
        float wallRange = 19;
        return new Vector3(Random.Range(-wallRange,wallRange), 0, Random.Range(-wallRange,wallRange));
    }

    void UpdateCount(){
        enemyCount-=1;
    }


    private void OnDisable()
    {
        EnemiesStack.OnUnstackEnemy-= UpdateCount;
    }
}

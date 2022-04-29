using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner2 : MonoBehaviour
{
    public GameObject[] earlyPhaseMobs;
    public GameObject[] midPhaseMobs;
    public GameObject[] latePhaseMobs;
    
    //public GameObject parent;
    [Tooltip("How many units to spawn in at once.")]
    [SerializeField] private int numberToSpawn;
    [Tooltip("How many units will come out in total.")]
    [SerializeField] private int limit;
    [Tooltip("How fast units come out.")]
    [SerializeField] private float rate;
    [Tooltip("How many units until rate change.")]
    [SerializeField] private int rateChange;
    [Tooltip("What the rate you want it to be when you hit rate change.")]
    [SerializeField] private float rateUp;
    [Tooltip("This number is the amount of enemies spawned before rate is increased.")]
    private int rateUpMeter;
    private int spawnCount;
    public Transform[] spawnPoints;
    public int monsterLimit;
    public int monsterAmount;

    float spawnTimer;
    [SerializeField] private float gameplaytime;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = rate;
    }

    // Update is called once per frame
    void Update()
    {
            gameplaytime += Time.deltaTime;

            SpawnEnemy();
            spawnTimer -= Time.deltaTime;

            
            
        
    }
     void FixedUpdate()
    {
        GameObject[] monsters = GameObject.FindGameObjectsWithTag("Enemy");
        monsterAmount = monsters.Length;
    }

    public void SpawnEnemy()
    {
        if (spawnTimer <= 0f)
        {
            for (int i = 0; i < numberToSpawn; i++)
            {

                if (spawnCount <= limit)
                {
                    if (gameplaytime <= 180)
                    {
                        int randomEnemy;
                        randomEnemy = (int)Random.Range(0, earlyPhaseMobs.Length);
                        int randomIndex = Random.Range(0, spawnPoints.Length);
                        Transform spawnPoint = spawnPoints[randomIndex];
                        Instantiate(earlyPhaseMobs[randomEnemy], spawnPoint.position, spawnPoint.rotation);
                        spawnCount++;
                        rateUpMeter++;
                    }

                    else if (gameplaytime > 180 && gameplaytime <= 360)
                    {
                        int randomEnemy;
                        randomEnemy = (int)Random.Range(0, midPhaseMobs.Length);
                        int randomIndex = Random.Range(0, spawnPoints.Length);
                        Transform spawnPoint = spawnPoints[randomIndex];
                        Instantiate(midPhaseMobs[randomEnemy], spawnPoint.position, spawnPoint.rotation);
                        spawnCount++;
                        rateUpMeter++;
                    }

                    else if (gameplaytime > 360)
                    {
                        int randomEnemy;
                        randomEnemy = (int)Random.Range(0, latePhaseMobs.Length);
                        int randomIndex = Random.Range(0, spawnPoints.Length);
                        Transform spawnPoint = spawnPoints[randomIndex];
                        Instantiate(latePhaseMobs[randomEnemy], spawnPoint.position, spawnPoint.rotation);
                        spawnCount++;
                        rateUpMeter++;
                    }
                }
            }

            spawnTimer = rate;
        }

        if (rateUpMeter == rateChange)
        {
            rateUpMeter = 0;
            rate *= rateUp;
        }

    }
    
}

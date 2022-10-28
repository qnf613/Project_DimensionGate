using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum spawnNthWave { spawnFirstWave, spawnSecondWave, spawnThirdWave, spawnFourthWave, doNotSpawn }
public class SwampSpawner : MonoBehaviour
{
    public Transform[] firstWave;
    public Transform[] secondWave;
    public Transform[] thirdWave;
    public Transform[] fourthWave;
    public GameObject[] firstMobs;
    public GameObject[] secondMobs;
    public GameObject[] thirdMobs;
    public GameObject[] fourthMobs;
    public spawnNthWave sw;
    [SerializeField] private int monsterAmount;
    [SerializeField] private float gameplaytime;
    [SerializeField] private int numberToSpawn;
    [SerializeField] private int firstWaveTime;
    [SerializeField] private int secondWaveTime;
    [SerializeField] private int thirdWaveTime;
    [SerializeField] private int fourthWaveTime;

    Transform spawnPoint;
    int Enemies;
    int randomIndex;
    // Start is called before the first frame update
    public void Awake()
    {
        
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        gameplaytime += Time.deltaTime;
        CheckWaveOrder();
        SpawnSwamp();
        
    }

    public void CheckWaveOrder()
    {
        if (firstWaveTime < gameplaytime && gameplaytime < (firstWaveTime + 1f))
        {
            sw = spawnNthWave.spawnFirstWave;
        }

        else if (secondWaveTime < gameplaytime && gameplaytime < (secondWaveTime + 1f))
        {
            sw = spawnNthWave.spawnSecondWave;
        }

        else if (thirdWaveTime < gameplaytime && gameplaytime < (thirdWaveTime + 1f))
        {
            sw = spawnNthWave.spawnThirdWave;
        }

        else if (fourthWaveTime < gameplaytime && gameplaytime < (fourthWaveTime + 1f))
        {
            sw = spawnNthWave.spawnFourthWave;
        }

        else
        {
            sw = spawnNthWave.doNotSpawn;
            monsterAmount = 0;
        }
    }

    public void SpawnSwamp()
    {
        if (monsterAmount < numberToSpawn)
        {
            switch (sw)
            {
                case spawnNthWave.spawnFirstWave:
                    Enemies = Random.Range(0, firstMobs.Length);
                    randomIndex = Random.Range(0, firstWave.Length);
                    spawnPoint = firstWave[randomIndex];
                    Instantiate(firstMobs[Enemies], spawnPoint.position, spawnPoint.rotation);
                    monsterAmount++;
                    break;

                case spawnNthWave.spawnSecondWave:
                    Enemies = Random.Range(0, secondWave.Length);
                    randomIndex = Random.Range(0, secondWave.Length);
                    spawnPoint = secondWave[randomIndex];
                    Instantiate(secondMobs[Enemies], spawnPoint.position, spawnPoint.rotation);
                    monsterAmount++;
                    break;

                case spawnNthWave.spawnThirdWave:
                    Enemies = Random.Range(0, thirdWave.Length);
                    randomIndex = Random.Range(0, thirdWave.Length);
                    spawnPoint = thirdWave[randomIndex];
                    Instantiate(thirdMobs[Enemies], spawnPoint.position, spawnPoint.rotation);
                    monsterAmount++;
                    break;

                case spawnNthWave.spawnFourthWave:
                    Enemies = Random.Range(0, fourthWave.Length);
                    randomIndex = Random.Range(0, fourthWave.Length);
                    spawnPoint = fourthWave[randomIndex];
                    Instantiate(fourthMobs[Enemies], spawnPoint.position, spawnPoint.rotation);
                    monsterAmount++;
                    break;

                case spawnNthWave.doNotSpawn:
                    break;
            }
        }
            


    }

}

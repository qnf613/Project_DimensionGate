using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ClearBonus : MonoBehaviour
{
    public GameObject Chest;
    public ClearCondition cc;
    [SerializeField] private int numOfRewards = 0;
    public List<Transform> spawnPoints;
    // Start is called before the first frame update
    void Start()
    {
        cc = this.gameObject.GetComponent<ClearCondition>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CalculateBonusRewards()
    {
        if (cc.timeRemain <= 180)
        {
            numOfRewards = 1;
            
        }

        else if (cc.timeRemain > 180 && cc.timeRemain < 360)
        {
            numOfRewards = 2;

        }

        else if (cc.timeRemain >= 360)
        {
            numOfRewards = 3;

        }

        for (int i = 0; i < numOfRewards; i++)
        {
            BonusRewards();
        }
    }

    public void BonusRewards()
    {
        int randomSpawn = (int)Random.Range(0, spawnPoints.LongCount());
        Transform spawnPoint = spawnPoints[randomSpawn];
        Instantiate(Chest, spawnPoint.position, spawnPoint.rotation);
        spawnPoints.RemoveAt(randomSpawn);
    }
}

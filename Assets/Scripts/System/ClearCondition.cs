using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum StageCleared {yes, yet, over}
public class ClearCondition : MonoBehaviour
{
    public Text[] times;
    public float timeRemain = 600.0f;
    [SerializeField] private GameObject[] bossMonsters;
    [SerializeField] private GameObject bossOfStage;
    [SerializeField] private bool bossSummoned = false;
    [SerializeField] protected StageCleared sc;
    // Start is called before the first frame update
    private void Start()
    {
        sc = StageCleared.yet;
        bossOfStage = bossMonsters[Random.Range(0, bossMonsters.Length)];
    }

    // Update is called once per frame
    private void Update()
    {
        switch (sc) 
        {
            case StageCleared.yes:
                //TODO: spawn portal
                break;
            case StageCleared.yet:
                if (timeRemain >= 0)
                {
                    timeRemain -= Time.deltaTime;
                    times[0].text = ((int)timeRemain / 60 % 60).ToString();
                    times[1].text = ((int)timeRemain % 60).ToString();
                }
                break;
            case StageCleared.over:
                //TODO: call game over animation + UI
                break;
        }


        if (Input.GetKeyDown(KeyCode.E))
        {
            bossSummoned = true;
            Debug.Log("boss has been summoned");
        }

        if (bossSummoned && !bossOfStage.activeInHierarchy)
        {
            sc = StageCleared.yes;
            Debug.Log("boss dead, stage cleared");
        }
    }
}

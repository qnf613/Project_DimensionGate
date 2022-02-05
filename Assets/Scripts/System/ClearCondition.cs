using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum stageCleared {yes, yet, over}
public enum bossSummoned {yes, no}
public enum portalStatus {active, inactive, activalbe}
public class ClearCondition : MonoBehaviour
{
    public Text[] times;
    public float timeRemain = 600.0f;
    [SerializeField] private GameObject[] bossMonsters;
    [SerializeField] private GameObject bossOfStage;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject portal;
    [SerializeField] protected bossSummoned bs;
    [SerializeField] protected stageCleared sc;
    [SerializeField] protected portalStatus ps;
    // private int repeatStopper;

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sc = stageCleared.yet;
        bs = bossSummoned.no;
        ps = portalStatus.inactive;
        bossOfStage = bossMonsters[Random.Range(0, bossMonsters.Length)];
    }
    // Update is called once per frame
    private void Update()
    {
        switch (sc) 
        {
            case stageCleared.yes:
                //TODO: activate the portal & check bonus rewards depending on time remains
                break;

            case stageCleared.yet:
                //countdown for survive limits
                Countdown();
                //check player is alive or not
                CheckPlayer();
                break;
            
            case stageCleared.over:
                //TODO: call game over animation + UI
                break;
        }

        switch (bs)
        {
            case bossSummoned.yes:
                //check boss is alive or not
                CheckBoss();
            break;

            case bossSummoned.no:
                //make portal 'inactive' state while boss never summoned yet
                DeactivatePortal();
            break;
        }
        
        switch (ps)
        {
            case portalStatus.active:
                CheckBoss();
            break;

            case portalStatus.activalbe:
            break;

            case portalStatus.inactive:
                CheckBoss();
            break;
        }

    }

    private void Countdown()
    {
        if (timeRemain > 0)
        {
            timeRemain -= Time.deltaTime;
            times[0].text = ((int)timeRemain / 60 % 60).ToString();
            times[1].text = ((int)timeRemain % 60).ToString();
        }
        else
        {
            times[0].text = "0";
            times[1].text = "00";
            sc = stageCleared.over;
        }
    }

    private void CheckPlayer()
    {
        if(!player.activeInHierarchy)
        {
            sc = stageCleared.over;
        }
    }

    private void CheckBoss()
    {
        if(!bossOfStage.activeInHierarchy && sc == stageCleared.yet)
        {
            sc = stageCleared.yes;
        }
    }

    private void DeactivatePortal()
    {
        ps = portalStatus.inactive;
    }
}

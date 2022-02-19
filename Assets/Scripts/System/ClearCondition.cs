using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum stageCleared {yes, yet, over}
public enum bossStatus {nSummon, nDead}
public class ClearCondition : MonoBehaviour
{
    //countdown
    public Text[] times;
    public float timeRemain = 600.0f;
    //boss monster
    [SerializeField] private GameObject[] bossMonsters;
    [SerializeField] private GameObject bossOfStage;
    //player
    [SerializeField] private GameObject player;
    //portal
    [SerializeField] private GameObject portal;
    [SerializeField] private GameObject[] portals;
    //conditions
    [SerializeField] protected bossStatus bs;
    [SerializeField] protected stageCleared sc;
    [SerializeField] private bool happened = false;
    [SerializeField] private bool gameStart = false;
    // private int repeatStopper;


    private void Awake() {
        //find player
        player = GameObject.FindGameObjectWithTag("Player");
        //get all possible boss monsters of stage and put them in the list, and pick one of them for this run
        //bossMonsters = Resources.LoadAll<GameObject>("Boss").ToList();
        bossOfStage = bossMonsters[Random.Range(0, bossMonsters.Length)];
        
        //declear starting status
        sc = stageCleared.yet;
        bs = bossStatus.nSummon;
        //start with Summonable-portal
        portal = GameObject.FindGameObjectWithTag("Portal");
    }

    // Update is called once per frame
    private void Update()
    {
        //portal = GameObject.FindGameObjectWithTag("Portal"); //this might cause the lag in later build
        switch (sc) 
        {
            case stageCleared.yes:
                //activate the portal & check number of bonus rewards depending on time remains (this is conditional calculation)
                ActivatePortal();
                break;

            case stageCleared.yet:
                //countdown for survive limits
                Countdown();
                //check player is alive or not
                CheckPlayer();
                break;
            
            case stageCleared.over:
                //call game over animation + UI
                Gameover();
                break;
        }

        switch (bs)
        {
            case bossStatus.nSummon:
                //check portal('s seal) has been destoryed and if so, summon the boss and make portal as non-interactable
                CheckPortal();
                break;

            case bossStatus.nDead:
                //check boss is alive or not
                CheckBoss();
                break;
        }
        
    }

    private void Gameover()
    {
        if (!happened)
        {
            //TO DO: cut scene or animation of player death
            //TO DO: UI pop up
            happened = true;
        }
    }

    private void Countdown()
    {
        if (timeRemain > 0)
        {
            timeRemain -= Time.deltaTime;
            //minutes
            times[0].text = ((int)timeRemain / 60).ToString();
            //seconds
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
        if (GameObject.FindGameObjectWithTag("Player") == null) //can be changed to something like 'player.hp == 0'
        {
            sc = stageCleared.over;
        }
    }

    private void CheckBoss()
    {
        if (GameObject.FindGameObjectWithTag("Boss") == null && sc == stageCleared.yet)
        {
            sc = stageCleared.yes;
        }
    }

    private void CheckPortal()
    {
        if (GameObject.FindGameObjectWithTag("Portal") == null && sc == stageCleared.yet)
        {
            portal = portals[0];
            Instantiate(portal, new Vector3(this.transform.position.x, this.transform.position.y), Quaternion.identity);
            //Instantiate boss monster
            SummomBoss();
        }
    }

    private void SummomBoss()
    {
        //TO DO: cut scene or summon animation
        Instantiate(bossOfStage, new Vector3(this.transform.position.x, this.transform.position.y), Quaternion.identity);
        bossOfStage = GameObject.FindGameObjectWithTag("Boss");
        bs = bossStatus.nDead;
    }

    private void ActivatePortal()
    {
        if (!happened)
        {
            if (timeRemain > 120)
            {
                BonusRewards();
            }
            Destroy(GameObject.FindGameObjectWithTag("Portal"));
            portal = portals[1];
            Instantiate(portal, new Vector3(this.transform.position.x, this.transform.position.y), Quaternion.identity);
            happened = true;
        }
    }
    private void BonusRewards()
    {
        int numOfRewards = 0;
        timeRemain -= 120;
        numOfRewards = (int)timeRemain / 60;
        //TO DO: Generate rewards (chest) as same as the value of 'numOfRewards'
        //for(int i = 0; i ++; i < numOfRewards)
        //{
        //  ~~code for generate rewards
        //}
    }
}

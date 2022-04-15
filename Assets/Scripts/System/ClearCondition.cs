using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum stageCleared {yes, yet, over, notStarted}
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
    //portal navigator
    [SerializeField] private GameObject portalNavi;
    //conditions
    [SerializeField] protected bossStatus bs;
    [SerializeField] protected stageCleared sc;
    [SerializeField] private bool happened = false;
    [SerializeField] private bool gameStart = false;
    //rewards
    [SerializeField] private ClearBonus cb;
    //game over/stage clear
    [SerializeField] private GameObject GOUI;
    [SerializeField] private GameObject enemySpawner;


    private void Start() 
    {
        //find everything need to be start with
        player = GameObject.FindGameObjectWithTag("Player");                                    //player
        portal = GameObject.FindGameObjectWithTag("Portal");                                    //Summonable-portal
        enemySpawner = GameObject.Find("Spawner1");                                             //enemy spawner 
        cb = this.gameObject.GetComponent<ClearBonus>();                                        //access to clear bonus script
        GOUI = GameObject.Find("UI-FollowCam").transform.Find("GameOver").gameObject;           //game over UI

        //get all possible boss monsters of stage and put them in the list, and pick one of them for this run
        //bossMonsters = Resources.LoadAll<GameObject>("Boss").ToList();
        bossOfStage = bossMonsters[Random.Range(0, bossMonsters.Length)];

        //assign timer text
        times[0] = GameObject.Find("Mins").GetComponent<Text>();
        times[1] = GameObject.Find("Secs").GetComponent<Text>();
        times[2] = GameObject.Find(":").GetComponent<Text>();
        //declear starting status
        bs = bossStatus.nSummon;
        
        //start countdown when first monster spawn
        StartCoroutine(CountStart());
        if (portalNavi == null)
        {
            portalNavi = GameObject.Find("PortalPointer");
        }
        portalNavi.SetActive(false);
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
                StartCoroutine(Gameover());
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

    IEnumerator Gameover()
    {
        if (!happened)
        {
            //TO DO: cut scene or animation of player death
            yield return new WaitForSecondsRealtime(2.0f);
            GOUI.SetActive(true);
            Time.timeScale = 0;
            happened = true;
        }
    }

    IEnumerator CountStart()
    {
        yield return new WaitForSecondsRealtime(3.0f);
        sc = stageCleared.yet;
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
            if (((int)timeRemain % 60) < 10)
            {
                times[1].text = "0"+((int)timeRemain % 60).ToString();
            }
            if (timeRemain < 301 && timeRemain > 121)
            {
                times[0].color = Color.yellow;
                times[1].color = Color.yellow;
                times[2].color = Color.yellow;
            }
            else if (timeRemain < 121)
            {
                times[0].color = Color.red;
                times[1].color = Color.red;
                times[2].color = Color.red;
            }


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
            StopEnemySpawn();
            if (timeRemain > 120)
            {
                cb.CalculateBonusRewards();
            }
            Destroy(GameObject.FindGameObjectWithTag("Portal"));
            portal = portals[1];
            Instantiate(portal, new Vector3(this.transform.position.x, this.transform.position.y), Quaternion.identity);
            portalNavi.SetActive(true);
            happened = true;
        }
    }

    private void StopEnemySpawn(){
        enemySpawner.SetActive(false);
        ClearAllEnemies();
    }

    private void ClearAllEnemies(){
        GameObject[] monsters = GameObject.FindGameObjectsWithTag("Enemy");
        for(int i = 0; i < monsters.Length; i++){
            Destroy(monsters[i]);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour
{
    //level related
    public int level;
    public int exp;
    public int expToLevelUp = 10;
    //rewarding related
    public GameObject rsManager;
    public RewardSystem rs;
    public GameObject rUI;
    public RewardUI ru;
    // EXP UI BAR
    [SerializeField] private Slider expSlider;
    [SerializeField] private Text expValue;


    void Start()
    {
        level = 1;
        exp = 0;
        expToLevelUp = 10;
        // Exp sliders max value is the amount of expToLevelUp
        expSlider.maxValue = expToLevelUp;

        rsManager = GameObject.Find("RewardManager");
        rs = rsManager.GetComponent<RewardSystem>();
        rUI = GameObject.Find("UI-FollowCam").transform.Find("RewardPick").gameObject;
        ru = rUI.GetComponent<RewardUI>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (exp >= expToLevelUp)
        {
            LevelUp();
        }

        //debug
        if (Input.GetKeyDown(KeyCode.L))
        {
            LevelUp();
        }

    }

    public void LevelUp()
    {
        level++;
        exp -= expToLevelUp;
        expToLevelUp = level * 10 + 20;
        rs.MakeLevelUpRewardList();
        ru.GetRewardsList();
        ru.OpenUI();
        expSlider.maxValue = expToLevelUp;
    }

    public void AddExp(int amount)
    {
        exp += amount;
        //Debug.Log("Current exp: " + exp);
    }

    private void OnGUI()
    {
        // Changing the time here will change how fast the the slider moves
        float t = Time.deltaTime / .2f;
        expSlider.value = Mathf.Lerp(expSlider.value, exp, t);
    }

}

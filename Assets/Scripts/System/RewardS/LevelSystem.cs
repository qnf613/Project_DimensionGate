using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour
{
    //level related
    public int level = 1;
    public int exp = 0;
    public int expToLevelUp = 10;
    //rewarding related
    public GameObject rsManager;
    public RewardSystem rs;
    public GameObject rUI;
    public RewardUI ru;
    public bool lvUp;
    // EXP UI BAR
    [SerializeField] private Slider expSlider;
    //SFX
    [SerializeField] private AudioClip levelupSFX;
    [SerializeField] private float volume = 0.50f;


    void Start()
    {
        // Exp sliders max value is the amount of expToLevelUp
        expSlider.maxValue = expToLevelUp;

        rsManager = GameObject.Find("RewardManager");
        rs = rsManager.GetComponent<RewardSystem>();
        rUI = GameObject.Find("UI-FollowCam").transform.Find("RewardPick").gameObject;
        ru = rUI.GetComponent<RewardUI>();
        lvUp = false;
    }



    // Update is called once per frame
    void LateUpdate()
    {
        expSlider.maxValue = expToLevelUp;
        
        if (DonTDestroy.inStage)
        {
            if (exp >= expToLevelUp)
            {
                LevelUp();
            }

            ////debug
            //if (Input.GetKeyDown(KeyCode.L))
            //{
            //    exp = expToLevelUp;
            //}
        }
    }

    public void LevelUp()
    {
        lvUp = true;
        if (levelupSFX != null)
        {
            AudioSource.PlayClipAtPoint(levelupSFX, transform.position, volume);
        }
        level++;
        exp -= expToLevelUp;
        expToLevelUp = level * 10;
        rs.MakeLevelUpRewardList();
        ru.GetRewardsList();
        ru.OpenUI();
    }

    public void AddExp(int amount)
    {
        exp += amount;
    }

    private void OnGUI()
    {
        // Changing the time here will change how fast the the slider moves
        float t = Time.deltaTime / .5f;
        expSlider.value = Mathf.Lerp(expSlider.value, exp, t);
    }

}

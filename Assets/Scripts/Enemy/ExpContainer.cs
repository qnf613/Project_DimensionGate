using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpContainer : MonoBehaviour
{
    public GameObject lvManager;
    public LevelSystem lv;
    [SerializeField] private int exp = 1;

    public DamageSystem dmgsys;
    [SerializeField] private float hpChecker;
    [SerializeField] private bool sentExp = false;
    // Start is called before the first frame update
    void Start()
    {
        dmgsys = transform.GetComponent<DamageSystem>();
        lvManager = GameObject.Find("LevelManager");
        lv = lvManager.GetComponent<LevelSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        hpChecker = dmgsys.currentHealth;
        if (hpChecker <= 0 && !sentExp)
        {
            lv.AddExp(exp);
            sentExp = true;
        }
             
    }


}

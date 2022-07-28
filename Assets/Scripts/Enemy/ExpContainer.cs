using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpContainer : MonoBehaviour
{
    public GameObject lvManager;
    public LevelSystem ls;
    [SerializeField] public int exp = 1;
    // Change newExp to default exp.
    public int newExp;

    public DamageSystem dmgsys;
    [SerializeField] private float hpChecker;
    [SerializeField] private bool sentExp = false;
    // Start is called before the first frame update
    void Start()
    {
        dmgsys = transform.GetComponent<DamageSystem>();
        lvManager = GameObject.Find("LevelManager");
        ls = lvManager.GetComponent<LevelSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        hpChecker = dmgsys.currentHealth;
        if (hpChecker <= 0 && !sentExp)
        {
            ls.AddExp(newExp);
            sentExp = true;
        }
             
    }


}

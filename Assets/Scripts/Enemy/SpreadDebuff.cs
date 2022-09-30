using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadDebuff : MonoBehaviour
{
    [SerializeField] private DamageSystem Myds;
    [SerializeField] private DamageSystem Theirds;
    bool shouldspread = false;
    private void Start()
    {
      Myds = this.GetComponent<DamageSystem>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShouldSpread()
    {
        if (Myds.burning == true)
        {
            shouldspread = true;
        }
        else if(Myds.burning != true)
        {
            shouldspread = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Theirds = collision.GetComponent<DamageSystem>();
        if (shouldspread == true && Theirds.burning == false)
        {
            Debug.Log("Spread");
            Theirds.ApplyStatusEffect(2, Myds.statusStrength, Myds.statusDuration);
        }
    }
}

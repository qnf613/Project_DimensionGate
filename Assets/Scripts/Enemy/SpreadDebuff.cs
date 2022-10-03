using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadDebuff : MonoBehaviour
{
    [SerializeField] private DamageSystem Myds;
    [SerializeField] private DamageSystem Theirds;
    private void Start()
    {
      Myds = this.GetComponent<DamageSystem>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Theirds = collision.GetComponent<DamageSystem>();
        if (Theirds != null)
        {
            if (Theirds.burning == false && Myds.burning == true)
            {
                Debug.Log("Spread");
                Theirds.ApplyStatusEffect(2, Myds.statusStrength, Myds.statusDuration, Myds.origins);
            }
        }
    }
}

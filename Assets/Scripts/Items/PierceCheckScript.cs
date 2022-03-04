using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PierceCheckScript : MonoBehaviour
{
    [SerializeField] private int pierceCount;
    [SerializeField] private int maxPierceCount;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<DamageSystem>())
        {
            PierceCount();
        }
       
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (pierceCount >= maxPierceCount)
            {
                DestroyAfterPierce();
            }
        
    }
    public void DestroyAfterPierce() {
        
        Destroy(this.gameObject);
        
    }
    public void PierceCount()
    {

        if (pierceCount < maxPierceCount)
        {
            pierceCount++;
            //Debug.Log(pierceCount);
        }
    }
}

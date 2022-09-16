using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialKingSlime : MonoBehaviour
{
    public GameObject[] slimeGoo;
    [SerializeField] public float cooldown;
    private float timer = 1f;

    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        Attack();
    }

    void Attack()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;

        }
        else if (timer <= 0)
        {
            int randomSpawn;
            randomSpawn = (int)Random.Range(0, slimeGoo.Length);
            Instantiate(slimeGoo[randomSpawn], transform.position, transform.rotation);
            timer = cooldown;
        }
    }
}

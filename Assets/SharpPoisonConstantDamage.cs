using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharpPoisonConstantDamage : MonoBehaviour
{
    public float spikeAmount = 5;
    
    [SerializeField] public float attacktime = 2f;
    [SerializeField] public float attacktimelimit = 5;
    [SerializeField] public float cooldown = 10f;
    
    protected Vector3 projectileDirection;

    [SerializeField] private float attackDelay = .5f;
    [SerializeField] private float nextDamageEvent;
    [SerializeField] private float duration;

    private float attackDamage;
    private float FinalDamage;
    private GameObject SharpPoison;

    private float volume = 0.6f;

    List<DamageSystem> enemies;

    void Start()
    {
        enemies = new List<DamageSystem>();
        SharpPoison = GameObject.Find("SharpPoison");
        var venomscript = SharpPoison.GetComponent<SharpPoison>();
        attackDamage = venomscript.damage;
        SetDamage();

        Invoke("SetDamage", duration);
        dropCaltrops();
    }

    public void SetDamage()
    {
        FinalDamage = attackDamage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.GetComponent<DamageSystem>() != null)
            {
                enemies.Add(collision.GetComponent<DamageSystem>());
            }
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.GetComponent<DamageSystem>() != null)
            {
                enemies.Remove(collision.GetComponent<DamageSystem>());
            }
        }

    }
    private void Update()
    {
        if (SharpPoison == null)
        {
            Destroy(this.gameObject);
        }
        for (var i = enemies.Count - 1; i > -1; i--)
        {
            if (enemies[i] == null)
                enemies.RemoveAt(i);
        }

        if (Time.time >= nextDamageEvent)
        {

            // Do damage here         
            foreach (var item in enemies)
            {
                item.TakeDamage(FinalDamage, false);
            }
            DamageScale();
            nextDamageEvent = Time.time + attackDelay;
        }

        //The pool should only last a few seconds
        Destroy(this.gameObject, duration);

    }
    void DamageScale()
    {
        FinalDamage *= SharpPoison.GetComponent<SharpPoison>().dotDamageScale;

    }
    public void dropCaltrops()
    {
        var venomscript = SharpPoison.GetComponent<SharpPoison>();
        for (float i = spikeAmount; i >= 0; i--)
        {
            float xOffSet = Random.Range(-3f, 3f);
            float yOffSet = Random.Range(-3f,3f);
            Vector3 randomPos = new Vector3(transform.position.x + xOffSet, transform.position.y + yOffSet);

            venomscript.CheckIfCrit();
            AudioSource.PlayClipAtPoint(venomscript.weaponSound, transform.position, volume);
            Instantiate(venomscript.Spikes, randomPos, transform.rotation);

            venomscript.Spikes.GetComponent<DealDamage>().SetDamage(venomscript.CalcCritDamageForSpikes(), venomscript.crit, venomscript.CritDamageMod);
        }
    }
}

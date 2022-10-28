using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DamagePopUp : MonoBehaviour
{

    [SerializeField] private float speed = .3f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, .5f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += Vector3.up * speed * Time.deltaTime;
    }
    public void SetNumber(float damage, Color c, float fontsize)
    {
        var tmp = this.gameObject.GetComponent<TextMeshPro>();
        tmp.text = ((int)damage).ToString();
        tmp.fontSize = fontsize;
        tmp.color = c;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePortal : MonoBehaviour
{
    [SerializeField] private Collider2D cd;
    [SerializeField] private GameObject keyButtonIcon;
    // Start is called before the first frame update
    void Start()
    {
        cd = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            keyButtonIcon.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            keyButtonIcon.SetActive(false);
        }
    }


}

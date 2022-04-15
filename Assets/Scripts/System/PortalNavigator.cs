using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalNavigator : MonoBehaviour
{
    [SerializeField] private GameObject portal;
    [SerializeField] private Vector3 portalDirection;
    [SerializeField] private Vector3 pointingDirection;
    // Start is called before the first frame update
    void Start()
    {
        //portal = GameObject.FindGameObjectWithTag("Portal");
    }

    // Update is called once per frame
    void Update()
    {
        if (portal == null)
        {
            portal = GameObject.FindGameObjectWithTag("Portal");
        }
        portalDirection = portal.transform.position;
        pointingDirection = portalDirection - transform.position;
        float rotz = Mathf.Atan2(pointingDirection.y, pointingDirection.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz);
    }
}

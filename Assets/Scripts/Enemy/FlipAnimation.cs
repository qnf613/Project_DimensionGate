using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FlipAnimation : MonoBehaviour
{
    [SerializeField] private AIPath script;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (script.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (script.velocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}

using UnityEngine;

public class SwordHitbox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //destroy after one half second
        //this.transform.position = this.transform.parent.position;
        Destroy(gameObject, .175f);
    }
}

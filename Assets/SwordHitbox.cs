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
        Destroy(this.gameObject, .1f);
    }
}

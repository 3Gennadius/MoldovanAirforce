using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public GameObject bullet;

    //Destroy bullet limits
    private float boundf = -1000f;
    private float boundr = 1000f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z < boundf){
            Destroy(bullet);
        }
        if(transform.position.z > boundr ){
            Destroy(bullet);
        }
        
        if(transform.position.x > boundr ){
            Destroy(bullet);
        }
        if(transform.position.x < boundf){
            Destroy(bullet);
        }  
    }
}

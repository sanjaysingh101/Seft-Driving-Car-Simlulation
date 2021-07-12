using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionOff : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.layer==10)
        {
            //Physics.IgnoreCollision()
        }
    }
    void Update()
    {
        
    }
}

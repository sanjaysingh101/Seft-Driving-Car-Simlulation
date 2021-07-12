using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Igonrecollision : MonoBehaviour
{
    // Start is called before the first frame update
    public Collider[] cars;
    
    void Start()
    {

        Physics.IgnoreCollision(cars[0], cars[1]);
        Physics.IgnoreCollision(cars[0], cars[2]);
        Physics.IgnoreCollision(cars[0], cars[3]);
        Physics.IgnoreCollision(cars[0], cars[4]);
        Physics.IgnoreCollision(cars[1], cars[2]);
        Physics.IgnoreCollision(cars[1], cars[3]);
        Physics.IgnoreCollision(cars[1], cars[4]);
        Physics.IgnoreCollision(cars[2], cars[3]);
        Physics.IgnoreCollision(cars[2], cars[4]);
        Physics.IgnoreCollision(cars[3], cars[4]);

        






    }

    
}

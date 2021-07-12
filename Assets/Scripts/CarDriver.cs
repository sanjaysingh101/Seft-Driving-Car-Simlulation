using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDriver : MonoBehaviour
{
    // Start is called before the first frame update
    public float gas;
    public float steer;
    void Start()
    {
        
    }
    

    // Update is called once per frame
    void Update()
    {
        if(gas>1)
        {
            gas=1;
        }
        if(gas<-1)
        {
            gas=-1;
        }
        if(steer>1)
        {
            steer=1;
        }
        if(steer<-1)
        {
            steer=-1;
        }
        GetComponent<RCC_CarControllerV3>().gasInput = gas;
        GetComponent<RCC_CarControllerV3>().brakeInput = -gas;
        GetComponent<RCC_CarControllerV3>().steerInput = steer;
    }
    
    
}

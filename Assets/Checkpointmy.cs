using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpointmy : MonoBehaviour
{
    public CarDriverAgent[] Cars;
    public CheckpointManager checkpointManager;
    public int checkpoint_No;
    public bool passed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //checkpointManager.index = index;
    }
    public void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.transform.CompareTag("Car0"))
        {
            Cars[0].index_checkpoint += 1;
            Cars[0].Correntcheckpoint();

        }
        if (other.gameObject.transform.CompareTag("Car1"))
        {
            Cars[1].index_checkpoint += 1;
            Cars[1].Correntcheckpoint();

        }
        if (other.gameObject.transform.CompareTag("Car2"))
        {
            Cars[2].index_checkpoint += 1;
            Cars[2].Correntcheckpoint();

        }
        if (other.gameObject.transform.CompareTag("Car3"))
        {
            Cars[3].index_checkpoint += 1;
            Cars[3].Correntcheckpoint();

        }
        if (other.gameObject.transform.CompareTag("Car4"))
        {
            Cars[4].index_checkpoint += 1;
            Cars[4].Correntcheckpoint();

        }
        if (other.gameObject.transform.CompareTag("Car5"))
        {
            Cars[5].index_checkpoint += 1;
            Cars[5].Correntcheckpoint();

        }
        if (other.gameObject.transform.CompareTag("Car6"))
        {
            Cars[6].index_checkpoint += 1;
            Cars[6].Correntcheckpoint();

        }
        if (other.gameObject.transform.CompareTag("Car7"))
        {
            Cars[7].index_checkpoint += 1;
            Cars[7].Correntcheckpoint();

        }
        if (other.gameObject.transform.CompareTag("Car8"))
        {
            Cars[8].index_checkpoint += 1;
            Cars[8].Correntcheckpoint();

        }
        if (other.gameObject.transform.CompareTag("Car9"))
        {
            Cars[9].index_checkpoint += 1;
            Cars[9].Correntcheckpoint();

        }
        
    }


}

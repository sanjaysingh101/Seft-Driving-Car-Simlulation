using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.CommunicatorObjects;
using Unity.MLAgents.Editor;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class CarDriverAgent : Agent
{
    public Transform spawnPosition;
    private CarDriver carDriver;
    //public Checkpointmy[] checkpointmy;
    public RCC_CarControllerV3 rCC_CarControllerV3;
    public GameObject NextCheckpoint;
    public int index_checkpoint;
    public int car_no;
    public int steering;
    public int Gas;
    private Vector3 diff;
    public float directiondot;


    public CheckpointManager checkpointManager;



    private void Awake()
    {
        carDriver = GetComponent<CarDriver>();
        //index_checkpoint = -1;
        //NextCheckpoint = checkpointManager.checkpoints[0].gameObject;


    }


    void Start()
    {
        // trackCheckpoints.OnPlayerCorrectCheckpoint+=TrackCheckpoints_OnCarCorrectCheckpoint;
        // trackCheckpoints.OnPlayerWrongCheckpoint+=TrackCheckpoints_OnCarWrongCheckpoint;
    }

    public void Correntcheckpoint()
    {
        Debug.Log(car_no + "Checkpoint" + index_checkpoint);

        AddReward(+2f);

    }
    public void Wrongcheckpoint()
    {
        Debug.Log("WrongCheckpoint");
        AddReward(-1f);

    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.transform.CompareTag("Wall"))
        {

            AddReward(-1f);
            //EndEpisode();
        }
    }
    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.transform.CompareTag("Wall"))
        {

            AddReward(-0.1f);
            StartCoroutine(waitfor(5));
            //EndEpisode();
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.transform.CompareTag("Wall"))
        {

            StopAllCoroutines();
        }
    }
    IEnumerator waitfor(int timee)
    {
        yield return new WaitForSeconds(timee);
        AddReward(-1f);
        checkpointManager.shuffleArray();
        EndEpisode();
    }

    public override void OnEpisodeBegin()
    {
        //base.OnEpisodeBegin();
        //carDriver.gas = 0;
        carDriver.steer = 0;
        rCC_CarControllerV3.speed = 0;
        GetComponent<Rigidbody>().isKinematic = true;



        // for (int i = 0; i < checkpointmy.Length; i++)
        // {
        //     checkpointmy[i].passed = false;
        // }



        index_checkpoint = 0;




        //transform.localPosition = spawnPosition.localPosition + new Vector3(0, 0, 0);
        checkpointManager.shuffleArray();
        transform.localPosition = checkpointManager.SpawnLocations[Random.Range(0, 4)].transform.localPosition;
        transform.forward = spawnPosition.forward;
        GetComponent<Rigidbody>().isKinematic = false;


    }
    public override void CollectObservations(VectorSensor sensor)
    {
        //base.CollectObservations(sensor);
        Vector3 checkpointforward = NextCheckpoint.gameObject.transform.forward;
        directiondot = Vector3.Dot(transform.forward, checkpointforward);
        diff = NextCheckpoint.gameObject.transform.localPosition - transform.localPosition;
        sensor.AddObservation(directiondot);


    }
    public override void OnActionReceived(ActionBuffers actions)
    {
        // base.OnActionReceived(actions);

        // carDriver.steer = 0f;

        // switch (actions.DiscreteActions[1])
        // {
        //     case 0: carDriver.steer = 0f; break;
        //     case 1: carDriver.steer = 1f; break;
        //     case 2: carDriver.steer = -1f; break;

        // }
        var input = actions.DiscreteActions;
        steering = input[1];
        Gas = input[0];
        if(Gas==0)
        {
            carDriver.gas=0;
        }
        if(Gas==1)
        {
            carDriver.gas=1;
        }
        if(Gas==2)
        {
            carDriver.gas=-1;
        }
        if(steering==0)
        {
            carDriver.steer=0;
        }
        if(steering==1)
        {
            carDriver.steer=1;
        }
        if(steering==2)
        {
            carDriver.steer=-1;
        }
    }
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        //base.Heuristic(actionsOut);
        Gas = 0;

        if(Input.GetKey(KeyCode.UpArrow))
        {
            Gas=1;
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            Gas = 2;
        }
        steering=0;
        if(Input.GetKey(KeyCode.RightArrow))
        {
            steering= 1;
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            steering =2;
        }
        // var action = actionsOut.DiscreteActions;
        // action[0] = Gas;
        // action[1] = steering;

        // // ActionSegment<float> continiousActions = actionsOut.ContinuousActions;
        // // continiousActions[1] = Input.GetAxis("Horizontal");
        // // continiousActions[0] = Input.GetAxis("Vertical");

        ActionSegment<int> discreteActions = actionsOut.DiscreteActions;
        discreteActions[0] = Gas;
        discreteActions[1] = steering;





        // carDriver.gas = ((int)Input.GetAxis("Vertical"));
        // carDriver.steer = ((int)Input.GetAxis("Horizontal"));
    }

    void Update()
    {
        // carDriver.gas = Gas;
        // carDriver.steer = steering;
        // Gas = ((int)carDriver.gas);
        // steering = ((int)carDriver.steer);
        


        if (index_checkpoint == 36)
        {

            checkpointManager.shuffleArray();
            AddReward(1f);

            EndEpisode();
        }

        NextCheckpoint = checkpointManager.checkpoints[index_checkpoint].gameObject;
    }




}

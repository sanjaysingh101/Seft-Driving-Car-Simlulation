using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.CommunicatorObjects;
using Unity.MLAgents.Editor;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class MoveToGoalAgent : Agent
{
    public Transform Spheretransform;
    public Material winmaterial;
    public Material Loosematerial;
    public MeshRenderer floormesh;
    public override void OnEpisodeBegin()
    {
        transform.localPosition = new Vector3(Random.Range(-3.7f,3.7f),0,Random.Range(-4.1f,0.3f));
        Spheretransform.localPosition = new Vector3(Random.Range(-3.3f,2.7f),0,Random.Range(2.6f,3.6f));
        //base.OnEpisodeBegin();
    }
    public override void CollectObservations(VectorSensor sensor)
    {

        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(Spheretransform.localPosition);
    }
    public override void OnActionReceived(ActionBuffers actions)
    {
        float moveX = actions.ContinuousActions[0];
        float moveZ = actions.ContinuousActions[1];
        float movespeed = 3f;
        transform.localPosition += new Vector3(moveX, 0, moveZ) * Time.deltaTime * movespeed;

    }
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<float> continiousActions = actionsOut.ContinuousActions;
        continiousActions[0] = Input.GetAxisRaw("Horizontal");
        continiousActions[1] = Input.GetAxisRaw("Vertical");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Goal>(out Goal goal))
        {
            SetReward(+1f);
            floormesh.material = winmaterial;
            EndEpisode();
        }
        if (other.TryGetComponent<Wall>(out Wall wall))
        {
            SetReward(-1f);
            floormesh.material = Loosematerial;

            EndEpisode();
        }


    }


}

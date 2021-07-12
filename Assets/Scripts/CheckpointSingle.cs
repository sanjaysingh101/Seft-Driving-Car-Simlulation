using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSingle : MonoBehaviour
{
    private TrackCheckpoints trackCheckpoints;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.transform.CompareTag("Car"))
        {
            //Debug.Log("CheckPoint");
            trackCheckpoints.PlayerThroughCheckpoint(this);
        }
    }
    public void setTrackCheckpoints(TrackCheckpoints trackCheckpoints)
    {
        this.trackCheckpoints = trackCheckpoints;
    }
}

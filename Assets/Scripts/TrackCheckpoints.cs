using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TrackCheckpoints : MonoBehaviour
{
    public event EventHandler OnPlayerCorrectCheckpoint;
    public event EventHandler OnPlayerWrongCheckpoint;
    private List<CheckpointSingle> checkpointSinglesList;
    private int NextCheckpointSingleIndex;
    public CarDriverAgent carDriverAgent;
    private void Awake()
    {
        Transform CheckpointsTransform = transform.Find("Checkpoints");
        checkpointSinglesList = new List<CheckpointSingle>();
        foreach (Transform checkpointSingleTransform in CheckpointsTransform)
        {
            CheckpointSingle checkpointSingle = checkpointSingleTransform.GetComponent<CheckpointSingle>();
            checkpointSingle.setTrackCheckpoints(this);
            checkpointSinglesList.Add(checkpointSingle);
            //Debug.Log(checkpointSingleTransform);
        }
        NextCheckpointSingleIndex = 0;
    }
    public void PlayerThroughCheckpoint(CheckpointSingle checkpointSingle)
    {
        Debug.Log(checkpointSinglesList.IndexOf(checkpointSingle));
        if (checkpointSinglesList.IndexOf(checkpointSingle) == NextCheckpointSingleIndex)
        {
            //correct checkpoint
            Debug.Log("correct");
            carDriverAgent.Correntcheckpoint();
            NextCheckpointSingleIndex = (NextCheckpointSingleIndex + 1) % checkpointSinglesList.Count;
            OnPlayerCorrectCheckpoint?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            //wrong checkpoint
            Debug.Log("wrong");
            carDriverAgent.Wrongcheckpoint();

            OnPlayerWrongCheckpoint?.Invoke(this, EventArgs.Empty);


        }

    }
}

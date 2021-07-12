using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] checkpoints;
    public Transform[] SpawnLocations;
    void Awake()
    {
        shuffleArray();
    }
    public void shuffleArray()
    {
        for (int t = 0; t < SpawnLocations.Length; t++)
        {
            Transform tmp = SpawnLocations[t];
            int r = Random.Range(t, SpawnLocations.Length);
            SpawnLocations[t] = SpawnLocations[r];
            SpawnLocations[r] = tmp;
        }
        

    }
    


    // Update is called once per frame
    void Update()
    {


    }
}

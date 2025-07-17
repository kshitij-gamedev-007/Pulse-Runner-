using UnityEngine;
using System.Collections.Generic;

public class Chunk : MonoBehaviour
{
    [SerializeField] GameObject fencePrefab; 
    [SerializeField] float[] lanes = { -1.8f, 0f, 2.31f };


    void Start()
    {
        SpawnFence();
    }

    void SpawnFence()
    {
        List<int> availableLanes = new List<int> {0,1,2};
        int fenceToSpawn = Random.Range (0,lanes.Length);
        for (int i = 0; i < fenceToSpawn; i++)
        {
            if (availableLanes.Count <=0) break; 
            int randomLaneIndex = Random.Range(0, availableLanes.Count);
            int selectedLane = availableLanes[randomLaneIndex];
            availableLanes.RemoveAt(randomLaneIndex);
            Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
            Instantiate(fencePrefab, spawnPosition, Quaternion.identity,this.transform);
        }
    }
}

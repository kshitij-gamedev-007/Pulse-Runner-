using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class Chunk : MonoBehaviour
{
    [SerializeField] GameObject fencePrefab;
    [SerializeField] GameObject applePrefab;
    [SerializeField] GameObject coinPrefab; 
    [SerializeField] float[] lanes = { -2.32f, 0f, 2.31f };
    [SerializeField] float appleSpawnChance = .3f;
    [SerializeField] float coinSpawnChance = .5f;
    [SerializeField] float coinSeperationLength = 2f; 
    List<int> availableLanes = new List<int> {0,1,2};

    void Start()
    {
        SpawnFences();
        SpawnApple();
        SpawnCoins();
    }

    void SpawnFences()
    {
        int fenceToSpawn = Random.Range (0,lanes.Length);
        for (int i = 0; i < fenceToSpawn; i++)
        {
            if (availableLanes.Count <= 0) break;
            int selectedLane = SelectLane();
            Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
            Instantiate(fencePrefab, spawnPosition, Quaternion.identity, this.transform);
        }
    }

    void SpawnApple(){
        if (Random.value > appleSpawnChance || availableLanes.Count <= 0 ) return;
            int selectedLane = SelectLane();    
            Vector3 spawnPosition = new(lanes[selectedLane], transform.position.y, transform.position.z);
            Instantiate(applePrefab, spawnPosition, Quaternion.identity, this.transform);
    }
    void SpawnCoins()
    {
        int coinAmount = Random.Range(1, 6);
        if (Random.value > coinSpawnChance || availableLanes.Count <= 0) return;
        int selectedLane = SelectLane();
        float topOfCoin = transform.position.z + (coinSeperationLength * 2f);
        for (int i = 0; i < coinAmount; i++)
        {
            float spawnPosZ = topOfCoin - (i * coinSeperationLength);
            Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, spawnPosZ);
            Instantiate(coinPrefab, spawnPosition, Quaternion.identity, this.transform);
        }
    }
    int SelectLane()
    {
        int randomLaneIndex = Random.Range(0, availableLanes.Count);
        int selectedLane = availableLanes[randomLaneIndex];
        availableLanes.RemoveAt(randomLaneIndex);
        return selectedLane;
    }

}

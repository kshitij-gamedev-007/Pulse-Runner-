using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] obstaclePrefabs;
    [SerializeField] float waitingPeriod = 1f;
    [SerializeField] float minObstacleSpawnTime = .4f;
    [SerializeField] Transform obstacleParent;
    [SerializeField] float spawnWidth = 3.5f;
    void Start()
    {
        StartCoroutine(WaitSeconds());   
        
    }
    public void DecreaseSpawnTime(float amount)
    {
        waitingPeriod -= amount;
        if (waitingPeriod <= minObstacleSpawnTime)
        {
            waitingPeriod = minObstacleSpawnTime;
        }
    }
    IEnumerator WaitSeconds()
    {
        while (true)
        {
            GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnWidth, spawnWidth), transform.position.y, transform.position.z);
            yield return new WaitForSeconds(waitingPeriod);
            Instantiate(obstaclePrefab, spawnPosition, Random.rotation, obstacleParent);
        } 
    }
}
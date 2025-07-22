using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class LevelGenerator : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Animator animator;
    [SerializeField] CameraController cameraController; 
    [SerializeField] GameObject[] ChunkPrefabs;
    [SerializeField] GameObject checkpointChunk;
    List<GameObject> chunks = new List<GameObject>();
    [SerializeField] ScoreManager scoreManager;

    [Header("Settings")]
    [SerializeField] int checkpointChunkInterval = 8;
    [SerializeField] int chunkAmount = 12;
    [SerializeField] Transform chunkPrefabs;
    [SerializeField] float chunkSpeed = 2f;
    float minMoveSpeed = 2f; 
    float chunkLength = 10f;
    int chunkSpawned = 0; 
    void Start()
    {
        SpawnStartingChunk();
    }

    void Update()
    {
        MoveChunk();
    }
    public void ChangeMovementSpeed(float speed)
    {
        chunkSpeed += speed;

        if (chunkSpeed < minMoveSpeed)
        {
            chunkSpeed = minMoveSpeed;
        }
        cameraController.ChangeCameraFov(speed);
    }
    void SpawnStartingChunk()
    {
        for (int i = 0; i < chunkAmount; i++)
        {
            SpawnChunks();
        }
    }

    void SpawnChunks()
    {
        GameObject ChunkToSpawn;
        float currentPosZ = CalculateSpawnPosZ();
        Vector3 chunkPosZ = new Vector3(transform.position.x, transform.position.y, currentPosZ);
        if (chunkSpawned % checkpointChunkInterval == 0)
        {
            ChunkToSpawn = checkpointChunk;
        }
        else
        {
            ChunkToSpawn = ChunkPrefabs[Random.Range(0, ChunkPrefabs.Length)];  
        }
        GameObject newchunkGO = Instantiate(ChunkToSpawn, chunkPosZ, Quaternion.identity, chunkPrefabs);

        chunks.Add(newchunkGO);
        Chunk newChunk = newchunkGO.GetComponent<Chunk>();
        newChunk.Init(this, scoreManager);

        chunkSpawned++;
    }

    float CalculateSpawnPosZ()
    {
        float currentPosZ;
        if (chunks.Count == 0)
        {
            currentPosZ = transform.position.z;
        }
        else
        {
            currentPosZ = chunks[chunks.Count - 1].transform.position.z + chunkLength;
        }
        return currentPosZ;
    }
    void MoveChunk()
    {
        for (int i = 0; i < chunks.Count; i++)
        {
            GameObject chunk = chunks[i];
            chunk.transform.Translate((chunkSpeed * Time.deltaTime) * -transform.forward);
            if (chunk.transform.position.z <= Camera.main.transform.position.z - chunkLength)
            {
                chunks.Remove(chunk);
                Destroy(chunk);
                SpawnChunks();
            }
        }
    }
}

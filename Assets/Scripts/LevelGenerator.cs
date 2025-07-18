using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject ChunkPrefab;
    [SerializeField] int chunkAmount = 12;
    [SerializeField] Transform chunkPrefabs;
    List<GameObject> chunks = new List<GameObject>();
    [SerializeField] float chunkSpeed = 2f;
    float chunkLength = 10f;

    void Start()
    {
        SpawnStartingChunk();
    }

    void Update()
    {
        MoveChunk();
        
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
        float currentPosZ = CalculateSpawnPosZ();
        Vector3 chunkPosZ = new Vector3(transform.position.x, transform.position.y, currentPosZ);
        GameObject newchunk = Instantiate(ChunkPrefab, chunkPosZ, Quaternion.identity, chunkPrefabs);
        chunks.Add(newchunk);
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

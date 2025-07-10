using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject ChunkPrefab;
    [SerializeField] int chunkAmount =12 ;
    [SerializeField] Transform chunkPrefabs;
    float chunkLength = 10f;

    void Start()
    {
        for (int i = 0; i < chunkAmount; i++)
        {
            float currentPosZ;
            if (i == 0)
            {
                currentPosZ = transform.position.z;
            }
            else
            {
                currentPosZ = transform.position.z + (i * chunkLength);
            }
            Vector3 chunkPosZ = new Vector3(transform.position.x, transform.position.y, currentPosZ);
            Instantiate(ChunkPrefab, chunkPosZ, Quaternion.identity, chunkPrefabs);
        }
    }

}

using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] float timeIncrement = 5f;
    [SerializeField] float decreaseObstacleSpawnTime = .2f;
    GameManager gameManager;
    ObstacleSpawner obstacleSpawner;
    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        obstacleSpawner = FindFirstObjectByType<ObstacleSpawner>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameManager.IncreaseTimer(timeIncrement);
            obstacleSpawner.DecreaseSpawnTime(decreaseObstacleSpawnTime);
        }
    }
}
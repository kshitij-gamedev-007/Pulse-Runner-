using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] float timeIncrement = 5f;
    GameManager gameManager;
    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameManager.IncreaseTimer(timeIncrement);
        }
    }
}
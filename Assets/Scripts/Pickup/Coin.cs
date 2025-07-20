using TMPro;
using UnityEngine;

public class Coin : PickupHandler
{
    ScoreManager scoreManager;

    void Start()
    {
        scoreManager = FindAnyObjectByType<ScoreManager>();
    }
    protected override void OnPickUp()
    {
        scoreManager.IncrementScore(1);
    }
}

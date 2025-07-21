using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Coin : PickupHandler
{
    ScoreManager scoreManager;

    public void Init(ScoreManager scoreManager)
    {
        this.scoreManager = scoreManager;
    }
    protected override void OnPickUp()
    {
        scoreManager.IncrementScore(1);
    }
}

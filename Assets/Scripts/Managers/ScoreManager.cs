using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] TMP_Text scoreboard;

    int score = 0;

    public void IncrementScore(int amount)
    {
        if (gameManager.GameOver) return;
        
        score += amount;
        scoreboard.text = score.ToString();
    }
}

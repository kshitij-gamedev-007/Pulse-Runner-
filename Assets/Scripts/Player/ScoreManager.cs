using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreboard;

    int score = 0;

    public void IncrementScore(int amount)
    {
        score += amount;
        scoreboard.text = score.ToString();
    }
}

using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerControl playerControl;
    [SerializeField] TMP_Text time;
    [SerializeField] GameObject GameOverText;
    [SerializeField] float startTimer = 5f;
    float timeLeft;

    void Start()
    {
        timeLeft = startTimer;
    }
    void Update()
    {
        timeLeft -= Time.deltaTime;
        time.text = timeLeft.ToString("F1");
        if (timeLeft <= 0)
        {
            timeLeft = 0f;
            GameOver();
        }
    }
    void GameOver()
    {
        playerControl.enabled = false;
        GameOverText.SetActive(true);
        Time.timeScale = .1f;
        
    }
}

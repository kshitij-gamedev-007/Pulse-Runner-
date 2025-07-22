using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerControl playerControl;
    [SerializeField] TMP_Text time;
    [SerializeField] GameObject GameOverText;
    [SerializeField] float startTimer = 5f;
    float timeLeft;
    bool isGameOver = false;

    public bool GameOver{get{ return isGameOver;}}
    void Start()
    {
        timeLeft = startTimer;
    }
    void Update()
    {
        if (isGameOver) return;
        timeLeft -= Time.deltaTime;
        time.text = timeLeft.ToString("F1");
        if (timeLeft <= 0)
        {
            PlayerGameOver();
        }
    }
    void PlayerGameOver()
    {
        isGameOver = true;
        playerControl.enabled = false;
        GameOverText.SetActive(true);
        Time.timeScale = .1f;
        
    }
}

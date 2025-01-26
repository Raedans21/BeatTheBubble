using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System;

public class CountdownTimer : MonoBehaviour
{
    public float timeRemaining = 10f; // 5 minutes in seconds
    public bool timerIsRunning = false;

    public StockManager stockManager;

    public bool didWin = false;
    public int round = 1;
    public float goal;
    [SerializeField] private TextMeshProUGUI timerText;

    [SerializeField] private TextMeshProUGUI goalText;
    [SerializeField] private TextMeshProUGUI roundText;

    void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
        setGoal();
        roundText.text = round.ToString();
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                DisplayTime(timeRemaining);
                // Optionally, do something when the timer reaches 0
                bool didWin = checkProfitAgainstGoal();
                if (didWin)
                {
                    Debug.Log("You win!");
                    stockManager.BubbleBurst(1);
                    resetTimer();
                    round++;
                    roundText.text = round.ToString();
                    setGoal();
                    Debug.Log(timeRemaining);
                }
                else
                {
                    Debug.Log("You lose!");
                }
            }
        }
    }

    private bool checkProfitAgainstGoal()
    {
        // if (stockManager.CalculateNetWorth() >= goal)
        if (stockManager.CalculateNetWorth() >= 10)
        {
            return true;
        }
        return false;
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void resetTimer()
    {
        timeRemaining = 120f;
        timerIsRunning = true;
        didWin = false;
        Update();
    }

    public void setGoal()
    {
        goal = Mathf.Pow(10, round+2);
        goalText.text = "Your net worth must be\n $" + goal.ToString() + " by end of round";
    }

}

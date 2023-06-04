using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    private Text timerText;

    private float startTime;
    private float currentTime;
    private float elapsedTime;

    public void SetTimerText(string time)
    {
        timerText.text = time;
    }

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        currentTime = Time.time;
        elapsedTime = currentTime - startTime;

        TimeSpan timeSpan = TimeSpan.FromSeconds(elapsedTime);
        string formattedTime = string.Format("{0:00}:{1:00}", timeSpan.Minutes, timeSpan.Seconds);

        timerText.text = formattedTime;
    }

    private void Awake()
    {
        timerText = GetComponentInChildren<Text>();

        if (timerText == null)
        {
            Debug.LogError("TimerManager: Text component not found.");
        }
    }

}

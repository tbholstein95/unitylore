using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTime : MonoBehaviour
{
    float nextSecond = 25;

    public static int second = 1;
    public static int minute = second/10;
    public static int hour = minute/10;
    public static int day = hour/24;
    public static int month = day/30;
    public static int year = month/12;

    public Text timeDisplay;
    private void Start()
    {
        timeDisplay = GameObject.FindGameObjectWithTag("timeDisplay").GetComponent<Text>();
        InvokeRepeating("Tick", 0f, 1f);
    }

    public void Tick()
    {

        second += 1;
        timeDisplay.text = "Day: " + day + "Time: " + hour + ":" + minute + ":" + second;
    }

    
}

﻿using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTime : MonoBehaviour
{

    public static int second = -1;
    public static int minute = second/10;
    public static int hour = minute/10;
    public static int day = hour/24;
    public static int month = day/30;
    public static int year = month/12;

    public static bool recruitChance = false;
    public static bool refreshList = false;
    public static bool clearList = false;
    public Text timeDisplay;
    spawnResources temp;

    public void Start()
    {
        GameObject gametime = GameObject.Find("Tilemap");
        temp = gametime.GetComponent<spawnResources>();
        timeDisplay = GameObject.FindGameObjectWithTag("timeDisplay").GetComponent<Text>();
        InvokeRepeating("Tick", 0f, 1f);
    }

    public void Tick()
    {

        second += 1;

        if(minute == 2 && second <= 1)
        {
            recruitChance = true;
            refreshList = true;
        }

        if(second >= 15)
        {
            second = 0;
            minute += 1;
        }

        if(minute >= 3)
        {
            temp.Generate();
            minute = 0;
            hour += 1;
            
        }

        if(hour == 1 && minute <= 2)
        {
            clearList = true;
        }

        if(hour == 2)
        {
            hour = 0;
            day += 1;
        }
        
        timeDisplay.text = "Day: " + day + "Time: " + hour + ":" + minute + ":" + second;
    }

    public static int returnTime()
    {
        return second;
    }

    
}

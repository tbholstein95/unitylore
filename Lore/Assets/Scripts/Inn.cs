﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inn : Building
{
    public static float innScore;
    // Start is called before the first frame update
    void Start()
    {
        recruitFactor = 10;
        Recruitment.recruitScore += recruitFactor;
        innScore += recruitFactor;
        //Debug.Log(Recruitment.recruitScore);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(innScore);
    }
}
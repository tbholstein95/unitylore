﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlacksmithScript : Building
{

    public static int blackSmithScore;
    // Start is called before the first frame update
    void Start()
    {
        recruitFactor = 10;
        Recruitment.recruitScore += recruitFactor;
        blackSmithScore += recruitFactor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

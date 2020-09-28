using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlacksmithScript : Building
{

    public static int blackSmithScore;
    public static int recruitFactor = 0;
    // Start is called before the first frame update
    void Start()
    {
        recruitFactor = 100;
        Recruitment.recruitScore += recruitFactor;
        blackSmithScore += recruitFactor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static int GetRecruitFactor()
    {
        return BlacksmithScript.recruitFactor;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adventurer : MonoBehaviour
{
    public int recruitFactor = 0;
    public static int adventurerScore = 0;
    void Start()
    {
        Recruitment.recruitScore += recruitFactor;
    }

    //This might be able to be moved to a function that is called during end of day "clean ups" to set up recruits for the next day.
    void Update()
    {
        int blacksmithTemp = BlacksmithScript.GetRecruitFactor();

        //Adventurers are tempted by great weapons, and as such rely on the blacksmithScore being there and word "getting out" about it.
        adventurerScore += (recruitFactor + blacksmithTemp);
    }
}

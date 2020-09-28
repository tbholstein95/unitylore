using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adventurer : MonoBehaviour
{
    public int recruitFactor = 0;
    public static int adventurerScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        Recruitment.recruitScore += recruitFactor;

    }

    // Update is called once per frame
    void Update()
    {
        int blacksmithTemp = BlacksmithScript.GetRecruitFactor();
        adventurerScore += (recruitFactor + blacksmithTemp);
    }
}

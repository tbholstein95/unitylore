using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlacksmithScript : MonoBehaviour
{

    public static int blackSmithScore;

    //This will be used for overall recruitment for NPC's later.  Not needed for individual recruitment, but is needed for that idea.
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recruitment : MonoBehaviour
{
    public static int recruitScore;
    float innScore;
    float blackSmithScore;
    public static List<string> InnRecruits = new List<string>();

    void Update()
    {
        innScore = Inn.innScore;
        blackSmithScore = BlacksmithScript.blackSmithScore;
        if(GameTime.recruitChance == true)
        {
            FindInnNPC();
            FindBlackSmithNPC();
            GameTime.recruitChance = false;
        }
    }

    void FindInnNPC()
    {
        float InnChanceDecimal = innScore / 1;

        float ICD_Modifier = InnChanceDecimal * Random.Range(1, 100);

        int ICD_Compare = Random.Range(1, 50);

        if (ICD_Modifier >= ICD_Compare)
        {
            Debug.Log("Innkeeper on Board");
            
            InnRecruits.Add("Bilbo");
            return;
        }
        else
        {
            Debug.Log("Sure is quiet around here");
        }
    }

    void FindBlackSmithNPC()
    {
        float BlacksmithChanceDecimal = blackSmithScore / 1;

        float BSCD_Modifier = BlacksmithChanceDecimal * Random.Range(1, 100);

        int BSCD_Compare = Random.Range(1, 50);

        if(BSCD_Modifier >= BSCD_Compare)
        {
            Debug.Log("Blacksmith On Board");

            InnRecruits.Add("Charles");
            return;
        }
        else
        {
            Debug.Log("No blacksmith today");
            GameTime.recruitChance = false;
        }
    }
}

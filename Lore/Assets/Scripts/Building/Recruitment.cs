using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recruitment : MonoBehaviour
{
    public static int recruitScore;
    float innScore;
    public static List<string> InnRecruits = new List<string>();

    void Update()
    {
        innScore = Inn.innScore;
        if(GameTime.recruitChance == true)
        {
            FindInnNPC();
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
            Debug.Log("Who dat boi, who him is?");
            
            InnRecruits.Add("Bilbo");
            return;
        }
        else
        {
            Debug.Log("Sure is quiet around here");
            GameTime.recruitChance = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recruitment : MonoBehaviour
{
    public static int recruitScore;
    float innScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        innScore = Inn.innScore;
        FindInnNPC();
    }

    void FindInnNPC()
    {
        float InnChanceDecimal = innScore / 10;
        //Debug.Log(InnChanceDecimal + "INN CHANCE");

        float ICD_Modifier = InnChanceDecimal * Random.Range(1, 100);
        Debug.Log(ICD_Modifier + "ICD MOD");

        int ICD_Compare = Random.Range(1, 50);
        Debug.Log(ICD_Compare);

        if(ICD_Modifier >= ICD_Compare)
        {
            Debug.Log("Who dat boi, who him is?");
        }
        else
        {
            Debug.Log("Sure is quiet around here");
        }

    }
}

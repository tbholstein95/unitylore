using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rollDice : MonoBehaviour
{
    public static int RollDice(int sides, int quantity)
    {
        int total = 0;
        for(var i = 0; i <= quantity; i++)
        {
            total += Random.Range(1, sides + 1);
        }
        return total;
    }
}

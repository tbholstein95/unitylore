using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestChecker : MonoBehaviour
{
    public void QuestCalculation(GameObject adventurer, GameObject currentQuest)
    {

        int questresultvalue;
        int monsters = currentQuest.GetComponent<testquest>().combatants;
        int difficulty = currentQuest.GetComponent<testquest>().difficulty;
        
        if (adventurer.name == "King"){
            int diceroll =  (rollDice.RollDice(4, monsters));
            Debug.Log(monsters + "number of monsters");
            int questsave = rollDice.RollDice(6, 1);

            questresultvalue = questsave - diceroll;
            if (questresultvalue >= 0)
            {
                Debug.Log("Success! Coming home!");
            }
            else
            {
                Debug.Log("Failure. Coming home.");
            }



        }
    }

}



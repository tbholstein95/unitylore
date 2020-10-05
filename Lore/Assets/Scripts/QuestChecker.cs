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
        List<GameObject> rewards = currentQuest.GetComponent<testquest>().ListOfRewards;
        List<RewardStats> iHave = adventurer.GetComponent<Inventory>().inventorySlots;
        Debug.Log(iHave.Count + "SIZE OF IHAVE");
        if (adventurer.name == "King"){
            int diceroll =  (rollDice.RollDice(4, monsters));
            Debug.Log(monsters + "number of monsters");
            int questsave = rollDice.RollDice(6, 6);

            questresultvalue = questsave - diceroll;
            if (questresultvalue >= 0)
            {
                Debug.Log("Success! Coming home!");
                Debug.Log("Adventurer bringing home: \n");
                foreach (GameObject reward in rewards)
                {
                    Debug.Log(reward.name + "REWARD NAME");
                    adventurer.GetComponent<Inventory>().AddItem(reward);
                    
                    Debug.Log(iHave[0].name + "yeyeyeyey");

                }

            }
            else
            {
                Debug.Log("Failure. Coming home.");
            }



        }
    }

}



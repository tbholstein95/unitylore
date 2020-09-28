using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGenerator : MonoBehaviour
{
    public static int questSuccess;
    public static int partySize;
    public static string[] questTypes = { "Combat", "Gathering" };
    public static List<string> questList = new List<string>();
    int difficulty;
    bool deadly;
    public int combatants;
    public static List<object> listOfQuests = new List<object>();
    public GameObject questToSpawn;
    public static List<GameObject> listOfGoQuests = new List<GameObject>();


    public void Update()
    {
        if(GameTime.recruitChance == true)
        {
            makeQuest();
            //GameTime.recruitChance = false;
        }
    }
    void makeQuest()
    {
        int index = Random.Range(1,questTypes.Length);
        string questAssign = questTypes[index];
        difficulty = createDifficulty();
        int villains = createCombatants(difficulty);
        int questNumber = Random.Range(1, 100000);
        questList.Add("Quest" + questNumber);
        string questName = ("Quest" + questNumber);
        GameObject newQuest = Instantiate(questToSpawn);
        newQuest.GetComponent<testquest>().questname = questName;
        newQuest.GetComponent<testquest>().combatants = villains;
        newQuest.GetComponent<testquest>().difficulty = difficulty;
        listOfGoQuests.Add(newQuest);
    }

    public static int createDifficulty()
    {
        int difficulty = 0;
        int check = rollDice.RollDice(6, 3);
        if(check <= 6 || check >= 3)
        {
            difficulty = 0;
        }
        else if(check <= 14 || check >= 7)
        {
            difficulty = 1;
        }
        else
        {
            difficulty = 2;
        }

        return difficulty;
    }

    public static int createCombatants(int difficulty)
    {
        int combatants;
        if(difficulty == 0)
        {
            combatants = 2;

        }
        else if(difficulty == 1)
        {
            combatants = 3;
        }
        else
        {
            combatants = 4;

        }

        return combatants;


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGenerator : MonoBehaviour
{
    //Holder for quest names that this generator makes.
    public static List<string> questList = new List<string>();

    //Holds the actual obejcts of quests.
    public static List<object> listOfQuests = new List<object>();

    //Similar to the buttontemplate, this holds all the information that the quest will spawn.
    public GameObject questToSpawn;

    //Holds all of the quest game objects that can be accessed later.
    public static List<GameObject> listOfGoQuests = new List<GameObject>();

    //Holds all of the possible rewards for quests.
    public Transform RewardsContainer;

    //Holds the rewards
    public List<GameObject> ListOfRewards;

    public void Start()
    {
        //Puts all the reward objects into the ListOfRewards
        foreach (Transform child in RewardsContainer.transform)
        {
            ListOfRewards.Add(child.gameObject);
        }
    }

    public void Update()
    {
        if(GameTime.recruitChance == true)
        {
            makeQuest();
        }
    }
    void makeQuest()
    {
        int difficulty = createDifficulty();
        int villains = createCombatants(difficulty);

        //Makes the name of the quest. Temporary.
        int questNumber = Random.Range(1, 100000);
        questList.Add("Quest" + questNumber);
        string questName = ("Quest" + questNumber);
        int timeToComplete = Random.Range(2, 4);

        //Selects a random reward. Can be refined later for selective reward based on type.
        GameObject questReward = reward();

        //Instantiates a new quest object
        GameObject newQuest = Instantiate(questToSpawn);

        //Sets all the qualities of the test values.
        newQuest.GetComponent<testquest>().questname = questName;
        newQuest.GetComponent<testquest>().combatants = villains;
        newQuest.GetComponent<testquest>().difficulty = difficulty;
        newQuest.GetComponent<testquest>().ListOfRewards.Add(questReward);
        newQuest.GetComponent<testquest>().secondsToComplete = timeToComplete;
        newQuest.name = questName;

        //Adds the quest to the list of currently created quests.
        listOfGoQuests.Add(newQuest);
    }

    int createDifficulty()
    {
        int difficulty;
        int check = rollDice.RollDice(6, 3);
        if(check <= 6 && check >= 3)
        {
            difficulty = 0;
            return difficulty;
        }
        else if(check <= 14 && check >= 7)
        {
            difficulty = 1;
            return difficulty;
        }   
        else
        {
            difficulty = 2;
            return difficulty;
        }
    }

    public static int createCombatants(int difficulty)
    {
        int combatants;
        if(difficulty == 0)
        {
            combatants = 2;
            return combatants;
        }
        else if(difficulty == 1)
        {
            combatants = 3;
            return combatants;
        }
        else
        {
            combatants = 4;
            return combatants;
        }
    }


    public GameObject reward()
    {
        //Temporary reward. Is static now, rework to be variable later.
        int randomSelect = 2;
        GameObject generatedReward = ListOfRewards[randomSelect];
        return generatedReward;
    }
}

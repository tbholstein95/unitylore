using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QuestButtonListControl : MonoBehaviour
{
    //The button template that the questse will use.
    public GameObject buttonTemplate;

    //Holds list of quests.
    public List<GameObject> qList;

    //Contains the UI for the quest itself's UI
    public GameObject questMenu;
    //Quest name holder in the questinfo UI
    public Text questNameDisplay;
    //Display's selectable list of characters you've hired.
    public Dropdown characterDropdown;
    //Populated by the function that returns the list of currently hired npc.
    public List<GameObject> characterHolder;
    //Just gets the script that will populate characterHolder
    public ButtonListControl scriptGetter;
    public Sprite tempimage;
    //List of the currently hired villagers.
    public List<GameObject> currentRecruitedVill = new List<GameObject>();
    //Contains scripts and information for making the quest.
    public QuestGenerator questGenerator;

    public void GenerateList()
    {
        foreach(GameObject child in QuestGenerator.listOfGoQuests)
        {
            qList.Add(child.gameObject);
        }

        foreach (var i in QuestGenerator.questList)
        {
            GameObject button = Instantiate(buttonTemplate) as GameObject;
            button.SetActive(true);

            button.GetComponent<QuestButtonListButton>().SetText(i);

            button.transform.SetParent(buttonTemplate.transform.parent, false);
        }
    }

    public void ButtonClicked()
    {
        //go is the button playerh as clicked.
        var go = EventSystem.current.currentSelectedGameObject;
        string name = go.ToString();
        //Name of the gameobject that is compared later.
        string testName = go.GetComponentInChildren<Text>().text;
        for (int i = 0; i < qList.Count; i++)
        {
            //Check that the quest is valid and in the list.
            if (qList[i].name.Contains(testName))
            {
                //Open up the quest information.
                questMenu.SetActive(!questMenu.activeSelf);

                //Set the quest from the list.
                GameObject thisQuest = qList[i];

                //Get a quest name string to use for populating later.
                string thisQuestname = thisQuest.GetComponent<testquest>().questname;

                //Actually displays the quest name in the UI.
                questNameDisplay.text = thisQuestname;

                //Populates list of villagers the player has hired.
                characterHolder = scriptGetter.returnGameObjects(currentRecruitedVill);

                //Allows access to the dropdown in a variable.
                var dropdown = characterDropdown.transform.GetComponent<Dropdown>();
                dropdown.options.Clear();
                dropdown.options.Add(new Dropdown.OptionData() { text = "Select who will go" });

                //Populates the drop down with who the playerh as recruited.
                foreach (GameObject questParticipant in characterHolder)
                {
                    //create holder for dropdown data
                    var tempDropDownOption = new Dropdown.OptionData();

                    //sets the name of the option
                    tempDropDownOption.text = questParticipant.name;
                    //adds the tearDownOption
                    dropdown.options.Add(tempDropDownOption);
                }
            }
        }
    }
}

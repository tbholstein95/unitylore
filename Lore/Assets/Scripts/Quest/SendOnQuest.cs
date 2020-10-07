using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendOnQuest : MonoBehaviour
{
    //Attached to ALLOWME.

    //Gives access to the dropdown for heroselect
    public Dropdown heroSelector;

    //gets script holding quest info
    public QuestButtonListControl scriptHoldsQuestInfo;

    //Gets the script checker
    public QuestChecker questchecker;


    /*private List<GameObject> listofQuests = new List<GameObject>();*/

    //Puts in the quest name in the quest UI.  
    public Text questName;

    public void AllowMe()
    {
        /*listofQuests = scriptHoldsQuestInfo.sendCurrentQuests(listofQuests);*/
        string currentQuestName = questName.text;
        string currentSelected = heroSelector.options[heroSelector.value].text;
        Debug.Log(currentSelected);
        GameObject newquest = GameObject.Find(currentQuestName);
        GameObject goingOn = GameObject.Find(currentSelected);
        Debug.Log(goingOn.name + "going on");
        questchecker.QuestCalculation(goingOn, newquest);
 
    }


}

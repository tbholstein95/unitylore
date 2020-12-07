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


    public int sec;

    public int comeBack;

    public int set;

    GameObject goingOn;

    public void OnTheQuest(GameObject heroLeaving)
    {
        heroLeaving.transform.position = new Vector3(-100, -100);
        set = sec;
    }

    public void comeOnBack()
    {
        string currentSelected = heroSelector.options[heroSelector.value].text;
        GameObject comingHome = GameObject.Find(currentSelected);
        comingHome.transform.position = new Vector3(0, 0);
        Debug.Log("EXECUTED COME ON BACK");
    }


    public void AllowMe()
    {
        /*listofQuests = scriptHoldsQuestInfo.sendCurrentQuests(listofQuests);*/
        string currentQuestName = questName.text;
        string currentSelected = heroSelector.options[heroSelector.value].text;
        Debug.Log(currentSelected);
        GameObject newquest = GameObject.Find(currentQuestName);
        goingOn = GameObject.Find(currentSelected);
        /*Debug.Log(goingOn.name + "going on");*/
        OnTheQuest(goingOn);
        questchecker.QuestCalculation(goingOn, newquest);
        comeBack = sec + newquest.GetComponent<testquest>().secondsToComplete;

        newquest.GetComponent<SendingManager>().hero = goingOn;
        newquest.GetComponent<SendingManager>().timeToComeBack = comeBack;
        
 
    }


    // Currently only works while questboard is open. Need to make a placeholder gameobject that has this portion of the script and receives input from this.
    public void Update()
    {
        sec = GameTime.returnTime();
/*        Debug.Log(set + "set");
        Debug.Log(comeBack + "comeback");
       
        Debug.Log(sec + "sec");
        if (sec == comeBack)
        {
            Debug.Log("Dangit yall");
            comeOnBack();
        }*/
    }

}

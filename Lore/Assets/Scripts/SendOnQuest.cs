using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendOnQuest : MonoBehaviour
{
    public Dropdown heroSelector;
    public QuestButtonListControl scriptHoldsQuestInfo;
    public List<GameObject> whoWeCanSend;
    public QuestChecker questchecker;
    private List<GameObject> listofQuests = new List<GameObject>();
    public Text questName;
    public GameObject quest;

    public void AllowMe()
    {
        whoWeCanSend = scriptHoldsQuestInfo.sendCurrentRecruited(whoWeCanSend);
        /*listofQuests = scriptHoldsQuestInfo.sendCurrentQuests(listofQuests);*/
        string currentQuestName = questName.text;
        string currentSelected = heroSelector.options[heroSelector.value].text;
        Debug.Log(currentSelected);
        GameObject newquest = GameObject.Find(currentQuestName);
        GameObject goingOn = GameObject.Find(currentSelected);
        Debug.Log(whoWeCanSend + "Who we can send");
        Debug.Log(goingOn.name + "going on");
        questchecker.QuestCalculation(goingOn, newquest);
 
    }


}

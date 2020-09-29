using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QuestButtonListControl : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonTemplate;

    public List<GameObject> questList;
    public List<GameObject> qList = new List<GameObject>();
    public List<GameObject> acceptedQuests;
    public GameObject questMenu;
    public Text questNameDisplay;

    // Start is called before the first frame update

    public void Awake()
    {
        //questMenu = GameObject.Find("QuestHolder");
        //questMenu.SetActive(false);
    }
    public void GenerateList()
    {
        foreach(GameObject child in QuestGenerator.listOfGoQuests)
        {
            qList.Add(child.gameObject);
            //goList.Add((GameObject)Instantiate(child.gameObject));
            //child.gameObject.SetActive(false);

        }

        foreach (var x in qList)
        {
            Debug.Log(x.name);
        }

        foreach (var i in QuestGenerator.questList)
        {
            GameObject button = Instantiate(buttonTemplate) as GameObject;
            button.SetActive(true);

            button.GetComponent<QuestButtonListButton>().SetText(i);
            //button.GetComponenet<ButtonListButton>().

            button.transform.SetParent(buttonTemplate.transform.parent, false);

            //button.GetComponent<ButtonListButton>().OnClick(i);
            //GameTime.refreshList = false;
        }
    }


    public void ButtonClicked()
    {
        var go = EventSystem.current.currentSelectedGameObject;
        string name = go.ToString();
        string testName = go.GetComponentInChildren<Text>().text;
        for (int i = 0; i < qList.Count; i++)
        {

            foreach (var x in qList)
            {
                Debug.Log(x.name + "checking on click for names");
            }

            if (qList[i].name.Contains(testName))
            {
                Debug.Log("This is the name of the quest" + qList[i].name);
                /*GameObject testSpawn = GameObject.Find(testName);
                GameObject spawnInnPerson = Instantiate(testSpawn, new Vector3(0, 0, 0), Quaternion.identity)*/;

                questMenu.SetActive(!questMenu.activeSelf);
                GameObject test = qList[i];
                string temp = test.GetComponent<testquest>().questname;
                questNameDisplay.text = temp;
            }

            
        }

        

        //Debug.Log(testName);

    }
}

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
    public List<GameObject> qList;
    public List<GameObject> acceptedQuests;
    public GameObject questMenu;
    public Text questNameDisplay;
    public Dropdown characterDropdown;
    public List<GameObject> characterHolder;
    public List<Sprite> spriteHolder = new List<Sprite>();
    public ButtonListControl scriptGetter;
    public Image testImage;
    public Sprite tempimage;
    public List<GameObject> currentRecruitedVill = new List<GameObject>();
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
                characterHolder = scriptGetter.returnGameObjects(currentRecruitedVill);
                spriteHolder = scriptGetter.returnSprite();
                var dropdown = characterDropdown.transform.GetComponent<Dropdown>();
                dropdown.options.Clear();
                dropdown.options.Add(new Dropdown.OptionData() { text = "Select who will go" });

                foreach (GameObject questParticipant in characterHolder)
                {
                    var x = 0;
                    var tempDropDownOption = new Dropdown.OptionData();
                    //tempDropDownOption.text = questParticipant.name;
                    GameObject testGet = GameObject.Find(questParticipant.name);
                    tempimage = questParticipant.GetComponent<Sprite>();
                    Debug.Log(questParticipant.name + "QUEST PARTICIPANT AND NAME");
                    //testImage.sprite = objectsprite.sprite;
                    tempDropDownOption.text = questParticipant.name;
                    tempDropDownOption.image = spriteHolder[x];
                    x++;

                    dropdown.options.Add(tempDropDownOption);
                    /*dropdown.options.Add(new Dropdown.OptionData() { text = questParticipant.name, image = objectsprite });*/


                }
            }
        }
    }

    public List<GameObject> sendCurrentRecruited(List<GameObject>fillMe)
    {
        for(var x = 0; x < characterHolder.Count; x++)
        {
            fillMe.Add(scriptGetter.goList[x]);
            Debug.Log("Added" + scriptGetter.goList[x]);
        }

        return fillMe;
    }

    public List<GameObject> sendCurrentQuests(List<GameObject>listofQuests)
    {
        for(var x = 0; x < qList.Count; x++)
        {
            listofQuests.Add(qList[x]);

        }

        return listofQuests;
    }
}

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
    public List<Object> qList;
    public List<GameObject> acceptedQuests;
    // Start is called before the first frame update

    public void GenerateList()
    {
        foreach (var x in QuestGenerator.listOfGoQuests)
        {
            qList.Add(x);
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

            button.GetComponent<ButtonListButton>().SetText(i);
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
                GameObject testSpawn = GameObject.Find(testName);
                GameObject spawnInnPerson = Instantiate(testSpawn, new Vector3(0, 0, 0), Quaternion.identity);
            }
        }

        //Debug.Log(testName);

    }
}

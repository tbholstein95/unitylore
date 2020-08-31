using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class ButtonListControl : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonTemplate;

    //public GameObject button;

    public GameObject innPerson;

    


    public void GenerateList()
    {
        /*for (int i = 1; i <= 20; i++)
        {
            GameObject button = Instantiate(buttonTemplate) as GameObject;
            button.SetActive(true);

            button.GetComponent<ButtonListButton>().SetText("Button # " + i);

            button.transform.SetParent(buttonTemplate.transform.parent, false);
        }*/

        foreach(var i in Recruitment.InnRecruits)
        {
            GameObject button = Instantiate(buttonTemplate) as GameObject;
            button.SetActive(true);

            button.GetComponent<ButtonListButton>().SetText(i);
            //button.GetComponenet<ButtonListButton>().

            button.transform.SetParent(buttonTemplate.transform.parent, false);

            //button.GetComponent<ButtonListButton>().OnClick(i);
            GameTime.refreshList = false;
        }
    }

    public void DestroyList()
    {
        GameObject[] recruitButtons = GameObject.FindGameObjectsWithTag("recruitButton");
        foreach(GameObject button in recruitButtons)
        {
            GameObject.Destroy(button);
        }
    }

    public void ButtonClicked()
    {
        var go = EventSystem.current.currentSelectedGameObject;
        string name = go.ToString();
        string testName = go.GetComponentInChildren<Text>().text;
        GameObject testSpawn = GameObject.Find(testName);
        Debug.Log(testName);
        GameObject spawnInnPerson = Instantiate(testSpawn);
    }
}

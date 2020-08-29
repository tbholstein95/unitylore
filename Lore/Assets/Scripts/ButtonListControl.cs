using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonListControl : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonTemplate;


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

            button.GetComponent<ButtonListButton>().SetText("Button # " + i);

            button.transform.SetParent(buttonTemplate.transform.parent, false);
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

    public void ButtonClicked(string myTextString)
    {
        Debug.Log(myTextString);
    }

}

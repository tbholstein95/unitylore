using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildButtonListControl : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonTemplate;

    public Transform buildingHolder;
    public List<GameObject> buildingList;
    public List<string> buildingNameList;

    private void Awake()
    {
        foreach (Transform child in buildingHolder.transform)
        {
            buildingList.Add(child.gameObject);
            buildingNameList.Add(child.name);
            
        }
    }
    void Start()
    {

        foreach (GameObject i in buildingList)
        {
            GameObject button = Instantiate(buttonTemplate) as GameObject;
            button.SetActive(true);


            button.GetComponent<BuildButtonListButton>().SetText(i.name);
            //button.GetComponenet<ButtonListButton>().

            button.transform.SetParent(buttonTemplate.transform.parent, false);
        }
    }
}


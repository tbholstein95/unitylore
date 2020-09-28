using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildButtonListControl : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonTemplate;

    public Transform buildingHolder;
    public List<GameObject> buildingList;
    public List<string> buildingNameList;

    private Construction construction;
    public GameObject objectwithconstruction;


    private GameObject[] buildList;
    public static int buildIndex;

    public BuildMenu m_BuildMenuScript;


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
        objectwithconstruction = GameObject.FindGameObjectWithTag("Player");
        construction = objectwithconstruction.GetComponent<Construction>();

        foreach (GameObject i in buildingList)
        {
            GameObject button = Instantiate(buttonTemplate) as GameObject;
            button.SetActive(true);
            button.name = i.name;

            button.GetComponent<BuildButtonListButton>().SetText(i.name);
            //button.GetComponenet<ButtonListButton>().

            button.transform.SetParent(buttonTemplate.transform.parent, false);

        }
    }

    public void ButtonClicked()
    {
        var go = EventSystem.current.currentSelectedGameObject;
        string name = go.ToString();
        string testName = go.GetComponentInChildren<Text>().text;

        Debug.Log(go.name);
        foreach(GameObject gobject in buildingList)
        {
            Debug.Log(gobject.name + go.name);
            if(gobject.name == go.name)
            {
                construction.SetItem(gobject);
                Debug.Log("Made it with" + gobject);
                BuildingSelect.buildIndex = gobject;
                TileHighlight.turnOn = 1;
                
            }
        }
        /*for (int i = 0; i < buildingList.Count; i++)
        {
            foreach (var x in buildingList)
            {
                Debug.Log(x.name + "checking on click for names");
            }*/


        /*if (buildingList[i].name.Contains(testName))
        {

            buildIndex = (i + 1);
            //buildingList[i].SetActive(true);
            GameObject testSpawn = GameObject.Find(testName);
            GameObject spawnInnPerson = Instantiate(testSpawn, new Vector3(0, 0, 0), Quaternion.identity);
            //buildingList[i].SetActive(false);
        }*/
        /*}*/

    }
}


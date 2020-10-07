using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildButtonListControl : MonoBehaviour
{
    //This allows buttons to fill the template.
    public GameObject buttonTemplate;

    //Has the building obejcts inside of it
    public Transform buildingHolder;
    //Holds GameObjects of Buildings
    public List<GameObject> buildingList;

    private Construction construction;
    public GameObject objectwithconstruction;


    private GameObject[] buildList;
    public static int buildIndex;

    public BuildMenu m_BuildMenuScript;


    private void Awake()
    {
        //On start up, all transforms in buildingHolder are put into the buildingList and the name is put into the list of names.
        foreach (Transform child in buildingHolder.transform)
        {
            buildingList.Add(child.gameObject);
        }
    }
    void Start()
    {
        objectwithconstruction = GameObject.FindGameObjectWithTag("Player");
        construction = objectwithconstruction.GetComponent<Construction>();

        foreach (GameObject i in buildingList)
        {
            //Instantiate button with name of game object.
            GameObject button = Instantiate(buttonTemplate) as GameObject;
            button.SetActive(true);
            button.name = i.name;

            //Sets name of the button
            button.GetComponent<BuildButtonListButton>().SetText(i.name);
            button.transform.SetParent(buttonTemplate.transform.parent, false);
        }
    }

    public void ButtonClicked()
    {
        //go is the button you have clicked on.
        var go = EventSystem.current.currentSelectedGameObject;
        foreach(GameObject gobject in buildingList)
        {
            //If your gameobject is the list of Buildings, set the variables in BuildingSelect as well as turn on the tile highlight.
            if(gobject.name == go.name)
            {
                //First, generate preview
                construction.SetItem(gobject);
                //Set the index
                BuildingSelect.buildIndex = gobject;
                //Turn on Tile highlight.
                TileHighlight.turnOn = 1;
            }
        }
    }
}


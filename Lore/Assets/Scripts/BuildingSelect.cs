using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSelect : MonoBehaviour
{
    private GameObject[] buildList;
    public static int buildIndex;

    public BuildMenu m_BuildMenuScript;


    void Start()
    {
        m_BuildMenuScript = GameObject.FindObjectOfType(typeof(BuildMenu)) as BuildMenu;

        buildList = new GameObject[transform.childCount];
        //fill array with building models
        for (int i = 0; i < transform.childCount; i++)
        {
            buildList[i] = transform.GetChild(i).gameObject;
        }
    }
    public void selectBuilding1()
    {
        buildIndex = 1;
        Debug.Log("Selected Big Building");
        m_BuildMenuScript.test();
    }

    public void selectBuilding2()
    {
        buildIndex = 2;
        Debug.Log("Selected Small Building");
        m_BuildMenuScript.test();
    }


    void Update()
    {
        
    }
}

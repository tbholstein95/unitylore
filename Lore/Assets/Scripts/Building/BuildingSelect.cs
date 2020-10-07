using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSelect : MonoBehaviour
{
    private GameObject[] buildList;
    public static GameObject buildIndex;
    public BuildMenu m_BuildMenuScript;


    void Start()
    {
        //Finds container that has all the building GameObjects.
        m_BuildMenuScript = GameObject.FindObjectOfType(typeof(BuildMenu)) as BuildMenu;

        buildList = new GameObject[transform.childCount];

        //fill array with building models
        for (int i = 0; i < transform.childCount; i++)
        {
            buildList[i] = transform.GetChild(i).gameObject;
        }
    }
}

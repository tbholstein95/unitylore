using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildMenu : MonoBehaviour
{
    public GameObject buildMenuUI;
    

    //Sets buildUI to false from the start.
    private void Start()
    {
        buildMenuUI.SetActive(false);
    }

    //Does the opposite of whatever the board is at.
    public void test()
    {
        buildMenuUI.SetActive(!buildMenuUI.activeSelf);
    }
}

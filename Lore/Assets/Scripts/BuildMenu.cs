using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildMenu : MonoBehaviour
{
    public GameObject buildMenuUI;
    

    private void Start()
    {
        buildMenuUI.SetActive(false);
    }


    public void test()
    {
        Debug.Log("I will open the menu!");
        buildMenuUI.SetActive(!buildMenuUI.activeSelf);
    }


}

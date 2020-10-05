﻿using System.Collections;
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
    public Transform NPCHolder;
    public List<GameObject> goList;
    private GameObject[] m_gameObjects;

    public List<GameObject> recruitedVillagers;
    public List<Sprite> recruitedSprites;
    public List<GameObject> currentRecruitedVillagers;


    public void GenerateList()
    {
        /*for (int i = 1; i <= 20; i++)
        {
            GameObject button = Instantiate(buttonTemplate) as GameObject;
            button.SetActive(true);

            button.GetComponent<ButtonListButton>().SetText("Button # " + i);

            button.transform.SetParent(buttonTemplate.transform.parent, false);
        }*/

        foreach (Transform child in NPCHolder.transform)
        {
            goList.Add(child.gameObject);
            //goList.Add((GameObject)Instantiate(child.gameObject));
            recruitedSprites.Add(child.gameObject.GetComponent<SpriteRenderer>().GetComponent<Sprite>());
            child.gameObject.SetActive(false);

            
        }

        foreach(var x in goList)
        {
            Debug.Log(x.name);
        }

        foreach (var i in Recruitment.InnRecruits)
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
        for(int i = 0; i<goList.Count; i++)
        {

            foreach (var x in goList)
            {
                Debug.Log(x.name + "checking on click for names");
            }

            if (goList[i].name.Contains(testName))
            {
                goList[i].SetActive(true);
                GameObject testSpawn = GameObject.Find(testName);
                GameObject spawnInnPerson = Instantiate(testSpawn, new Vector3(0,0,0), Quaternion.identity);
                spawnInnPerson.name = testName;
                spawnInnPerson.GetComponent<Inventory>().SetInventorySize();
                currentRecruitedVillagers.Add(goList[i]);
                goList[i].SetActive(false);
                //recruitedVillagers.Add(testSpawn);
            }
        }
        
        //Debug.Log(testName);
        
    }

    public List<GameObject> returnMe()
    {
        foreach (GameObject people in goList)
        {
            recruitedVillagers.Add(people);
            //goList.Add((GameObject)Instantiate(child.gameObject));
            //child.gameObject.SetActive(false);

        }

        return recruitedVillagers;
    }

    public List<Sprite> returnSprite()
    {

        return recruitedSprites;
    }

    public List<GameObject> returnGameObjects(List<GameObject> fillMe)
    {
        for(var x = 0; x < currentRecruitedVillagers.Count; x++)
        {
            fillMe.Add(currentRecruitedVillagers[x]);
            Debug.Log("Added" + currentRecruitedVillagers[x]);
        }

        return fillMe;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class ButtonListControl : MonoBehaviour
{
    public GameObject buttonTemplate;

    //public GameObject button;

    public GameObject innPerson;
    public Transform NPCHolder;
    public List<GameObject> goList;
    /*private GameObject[] m_gameObjects;*/

    public List<GameObject> recruitedVillagers;
    public List<Sprite> recruitedSprites;
    public List<GameObject> currentRecruitedVillagers;
    Database adventurerStatsDatabase;

    public void GenerateList()
    {
        foreach (Transform child in NPCHolder.transform)
        {
            //Adds all the children in the NPC holder into goList
            goList.Add(child.gameObject);
            child.gameObject.SetActive(false);
        }

        foreach (var i in Recruitment.InnRecruits)
        {
            //Creates a button for each available adventurer/worker.
            GameObject button = Instantiate(buttonTemplate) as GameObject;
            button.SetActive(true);

            button.GetComponent<ButtonListButton>().SetText(i);

            button.transform.SetParent(buttonTemplate.transform.parent, false);

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
        //go is the current button clicked
        var go = EventSystem.current.currentSelectedGameObject;
        string adventurerName = go.GetComponentInChildren<Text>().text;
        for(int i = 0; i<goList.Count; i++)
        {
            // if the list of gameobjects contains that adventuerer it will spawn it, and set its inventory.
            if (goList[i].name.Contains(adventurerName))
            {
                goList[i].SetActive(true);
                GameObject testSpawn = GameObject.Find(adventurerName);
                GameObject spawnInnPerson = Instantiate(testSpawn, new Vector3(0,0,0), Quaternion.identity);
                spawnInnPerson.name = adventurerName;
                spawnInnPerson.GetComponent<Inventory>().SetInventorySize();
                string gameName = spawnInnPerson.GetComponent<adventurerStatHolder>().adventurerName;
                adventurerStatsDatabase = GetComponent<Database>();
                List<string> nameslist = adventurerStatsDatabase.characterNamesHolder;
                int tablelength = adventurerStatsDatabase.tablelength;
                int randomcharacterinteger = Random.Range(0, tablelength - 1);
                string nameSelected = nameslist[randomcharacterinteger];
                spawnInnPerson.GetComponent<adventurerStatHolder>().adventurerClass = adventurerName;
                spawnInnPerson.GetComponent<adventurerStatHolder>().adventurerName = nameSelected;
                spawnInnPerson.name = nameSelected;
                Debug.Log("Adventurer's name set to " + spawnInnPerson.GetComponent<adventurerStatHolder>().adventurerName);
                //currentRecruitedVillagers.Add(goList[i]);
                currentRecruitedVillagers.Add(spawnInnPerson);
                goList[i].SetActive(false);
            }
        } 
    }

    public List<GameObject> returnGameObjects(List<GameObject> fillMe)
    {
        for(var x = 0; x < currentRecruitedVillagers.Count; x++)
        {
            fillMe.Add(currentRecruitedVillagers[x]);
        }

        return fillMe;
    }
}

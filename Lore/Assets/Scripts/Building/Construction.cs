using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.XR.WSA;
using UnityEngine.UI;
using System;

public class Construction : MonoBehaviour
{
    public Grid grid;
    public Tilemap tilemap;

    //Rm is Resource Manager
    public Rm rm;

    //Cost of Building
    //TODO: Put building stats into own script/give own stats.
    int cost = 20;
    public int selectedBuildingNumber;

    GameObject buildMe;

    private GameObject currentBuilding;

    public Text goldDisplay;
    public Text rockDisplay;
    public Text woodDisplay;

    public Color highlightColor;

    private void Start()
    {
        goldDisplay = GameObject.FindGameObjectWithTag("goldDisplay").GetComponent<Text>();
        //goldDisplay.text = "Gold: " + rm.GetComponent<Rm>().getGoldUnits();

        rockDisplay = GameObject.FindGameObjectWithTag("rockDisplay").GetComponent<Text>();
        //rockDisplay.text = "Rocks: " + rm.GetComponent<Rm>().getRockUnits();

        woodDisplay = GameObject.FindGameObjectWithTag("woodDisplay").GetComponent<Text>();
        //woodDisplay.text = "Wood: " + rm.GetComponent<Rm>().getWoodUnits();

        BuildingSelect.buildIndex = null;
    }

    void Update()
    {
        //If a building is selected from the build menu, this creates a transparent preview.
        //TODO : Remove collider from preview.
        if(currentBuilding != null)
        {
            Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int coordinate = tilemap.WorldToCell(mouseWorldPos);
            Vector3 tilepos = grid.GetCellCenterWorld(coordinate);
            currentBuilding.transform.position = (tilepos);
            currentBuilding.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .5f);

            //Gets rid of building preview and the tilehighlight.
            if (Input.GetMouseButtonDown(0))
            {
                Destroy(currentBuilding);
                TileHighlight.turnOn = 0;
            }
        }
        
        //Builds buildings
        //TODO: Maybe a switch case for build mode.
        if (Input.GetMouseButtonDown(1))
        {
            if(BuildingSelect.buildIndex == null)
            {
                TileHighlight.turnOn = 0;
                return;
            }


            //If player has selected a building then it sets the int of buildMe to the index of what was selected and turns on tilehighlight
            if(BuildingSelect.buildIndex != null)
            {
                buildMe = BuildingSelect.buildIndex;
                TileHighlight.turnOn = 0;
            }
           
            //If player has enough resources it gets the position of the mouse, converts it to tile location and instantiates the building.
            if (rm.getWoodUnits() >= cost && rm.getRockUnits() >= cost && rm.getGoldUnits() >= cost)
            {
                removeCost();
                Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3Int coordinate = tilemap.WorldToCell(mouseWorldPos);
                Vector3 tilepos = grid.GetCellCenterWorld(coordinate);
                BuildingSelect.buildIndex = null;
                GameObject objectInstance = Instantiate(buildMe, tilepos, Quaternion.Euler(new Vector3(0, 0, 0)));
                goldDisplay.text = "Gold: " + rm.GetComponent<Rm>().getGoldUnits();
                rockDisplay.text = "Rocks: " + rm.GetComponent<Rm>().getRockUnits();
                woodDisplay.text = "Wood: " + rm.GetComponent<Rm>().getWoodUnits();
                TileHighlight.turnOn = 0;
            }
            else
            {
                Debug.Log("Not enough resources");
            }
        }
    }

    //This helps set the image preview by setting the object you are previewing.
    public void SetItem(GameObject b)
    {
        currentBuilding = GameObject.Instantiate(b);
    }

    //Removes the cost for player
    public void removeCost()
    {
        rm.removeWood(cost);
        rm.removeGold(cost);
        rm.removeRock(cost);
    }
}

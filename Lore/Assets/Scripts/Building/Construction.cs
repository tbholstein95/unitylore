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
    public GameObject buildingOne;
    public GameObject buildingTwo;
    public Vector2 mousepos;
    public Grid grid;
    public Tilemap tilemap;
    public Rm rm;
    int cost = 20;
    public int selectedBuildingNumber;
    GameObject buildMe;

    private GameObject currentBuilding;

    public Text goldDisplay;
    public Text rockDisplay;
    public Text woodDisplay;

    public Color highlightColor;
    Color normalColor;

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
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(string.Concat("wood: ", rm.getWoodUnits(), " ", "gold: ", rm.getGoldUnits(), " ",  "rock: ", rm.getRockUnits()));
        }

        if(currentBuilding != null)
        {
            Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int coordinate = tilemap.WorldToCell(mouseWorldPos);
            Vector3 tilepos = grid.GetCellCenterWorld(coordinate);
            currentBuilding.transform.position = (tilepos);
            currentBuilding.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .5f);

            if (Input.GetMouseButtonDown(0))
            {
                Destroy(currentBuilding);
                TileHighlight.turnOn = 0;
            }

        }
        

        if (Input.GetMouseButtonDown(1))
        {
            if(BuildingSelect.buildIndex == null)
            {
                TileHighlight.turnOn = 0;
                return;

            }

            if(BuildingSelect.buildIndex != null)
            {
                
                buildMe = BuildingSelect.buildIndex;
                TileHighlight.turnOn = 0;
                
                


            }
           
            if (rm.getWoodUnits() >= cost && rm.getRockUnits() >= cost && rm.getGoldUnits() >= cost)
            {
                removeCost();
                Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                //Vector3Int coordinate = grid.LocalToCell(mouseWorldPos);
                Vector3Int coordinate = tilemap.WorldToCell(mouseWorldPos);
                Vector3 tilepos = grid.GetCellCenterWorld(coordinate);
                BuildingSelect.buildIndex = null;
                

                Debug.Log(coordinate);

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

    public void SetItem(GameObject b)
    {
        currentBuilding = ((GameObject.Instantiate(b)));
    }

    public void removeCost()
    {
        rm.removeWood(cost);
        rm.removeGold(cost);
        rm.removeRock(cost);
    }
}

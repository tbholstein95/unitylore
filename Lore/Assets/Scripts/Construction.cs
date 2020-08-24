using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.XR.WSA;

public class Construction : MonoBehaviour
{
    public GameObject wallPrefab;
    public Vector2 mousepos;
    public Grid grid;
    public Rm rm;
    int cost = 20;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Wood Units" + rm.getWoodUnits());
            if (rm.getWoodUnits() == cost && rm.getRockUnits() == cost && rm.getGoldUnits() == cost)
            {
                removeCost();
                Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3Int coordinate = grid.LocalToCell(mouseWorldPos);
                Vector3 tilepos = grid.GetCellCenterWorld(coordinate);

                Debug.Log(coordinate);

                GameObject objectInstance = Instantiate(wallPrefab, tilepos, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            
        }
    }

    public void removeCost()
    {
        rm.removeWood(cost);
        rm.removeGold(cost);
        rm.removeRock(cost);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileHighlight : MonoBehaviour
{
    public Tilemap tilemap;
    public Grid grid;
    public static bool turnOn;
    public Vector3Int previousTileCoordinate;
    public Vector3Int coordinate;
    public Color color = new Color(128, 0, 128, 1);
    public GameObject preview;
    public Vector2 mousePoint;

    public Color colorOG;
    public Color highlightColor = new Color(128,0,128,1);


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int coordinate = tilemap.WorldToCell(mousePoint);
        Vector3 pos = tilemap.GetCellCenterWorld(coordinate);

        tilemap.SetTileFlags(coordinate, TileFlags.None);
        colorOG = tilemap.GetColor(coordinate);
        //tilemap.SetColor(coordinate, highlightColor);
        
        if(coordinate != previousTileCoordinate)
        {
            tilemap.SetColor(previousTileCoordinate, colorOG);
            tilemap.SetColor(coordinate, highlightColor);
            previousTileCoordinate = coordinate;
        }



        
        Debug.Log(pos);
        Debug.Log(tilemap.GetSprite(coordinate));
    }
}

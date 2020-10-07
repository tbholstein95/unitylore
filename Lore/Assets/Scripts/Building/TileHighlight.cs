using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileHighlight : MonoBehaviour
{
    public Tilemap tilemap;
    /*public Grid grid;*/
    public static int turnOn;
    public Vector3Int previousTileCoordinate;
    public Vector3Int twoBackCoordinate;
    /*public Vector3Int coordinate;*/
    /*public Color color = new Color(128, 0, 128, 1);*/
    public Color color1 = new Color(1, 1, 1, 0);
    /*public GameObject preview;*/
    public Vector2 mousePoint;

    public Color colorOG;
    public Color highlightColor = new Color(128,0,128,1);


    // Start is called before the first frame update
    void Start()
    {
        //Sets color alpha;
        color1.a = 0;
    }

    // Update is called once per frame
    void Update()
    {
        mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int coordinate = tilemap.WorldToCell(mousePoint);

        tilemap.SetTileFlags(coordinate, TileFlags.None);
        colorOG = tilemap.GetColor(coordinate);

        if (turnOn == 1)
        {
            if (coordinate != previousTileCoordinate)
            {

                //Changes tile color to purple.  Set's previous tile's coordinate back.
                tilemap.SetColor(previousTileCoordinate, colorOG);
                tilemap.SetColor(coordinate, highlightColor);
                //Remembers what the previous tile color value is supposed to be;
                twoBackCoordinate = previousTileCoordinate;
                previousTileCoordinate = coordinate;
            }
        }
        if (turnOn == 0)
        {
            //When turned off sets the original color back for whatever the tile's original color was.
            tilemap.SetColor(coordinate, tilemap.GetColor(twoBackCoordinate));
            turnOn = 2;
        }
    }
}

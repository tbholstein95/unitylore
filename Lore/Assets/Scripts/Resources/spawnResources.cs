using System.Collections;
using System.Collections.Generic;
using System.Drawing;
//using System.Numerics;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class spawnResources : MonoBehaviour
{
    //Attached to the GameObject Grid > Tilemap
    public Tilemap tilemap;
    public List<Vector3> randomOptions;
    public List<Vector3> tileWorldLocations;
    public Vector3 position;

    public GameObject treeReso;
    public int numberOfTrees = 5;

    public GameObject rockReso;
    public int numberOfRocks = 5;

    public GameObject goldReso;
    public int numberOfGold = 1;

    public bool spotAvailable;

    void Start()

    {
        GetAllTiles();

        // TODO: I think this is too slow, optimize.
        //Generates number of Trees Equal to numberOfTrees Variable
        for(int i = 0; i < numberOfTrees; i++)
        {
            Vector3 spawnHere = tileWorldLocations[Random.Range(0, tileWorldLocations.Count)];
            tileWorldLocations.Remove(spawnHere);
            GameObject objectInstance = Instantiate(treeReso, spawnHere, Quaternion.Euler(new Vector3(0, 0, 0)));
        }

        //Generates number of Rocks Equal to numberofTrees Variable
        for (int i = 0; i < numberOfRocks; i++)
        {
            Vector3 spawnHere = tileWorldLocations[Random.Range(0, tileWorldLocations.Count)];
            tileWorldLocations.Remove(spawnHere);
            GameObject objectInstance = Instantiate(rockReso, spawnHere, Quaternion.Euler(new Vector3(0, 0, 0)));
        }

        //Generates number of Gold Equal to numberofGold Variable.
        for (int i = 0; i < numberOfGold; i++)
        {
            Vector3 spawnHere = tileWorldLocations[Random.Range(0, tileWorldLocations.Count)];
            tileWorldLocations.Remove(spawnHere);
            GameObject objectInstance = Instantiate(goldReso, spawnHere, Quaternion.Euler(new Vector3(0, 0, 0)));
        }
    }

    public void GetAllTiles()
    {
        //Gets the size of the map from the cellbounds.
        BoundsInt size = (tilemap.cellBounds);


        /*TileBase[] allTiles = tilemap.GetTilesBlock(size);*/
        //Puts each tile in the map into a list in order to not use duplicate tiles when spawning resources.
        foreach (var pos in tilemap.cellBounds.allPositionsWithin)
        {
            Vector3Int localPlace = new Vector3Int(pos.x, pos.y, pos.z);
            Vector3 place = tilemap.CellToWorld(localPlace);
            if (tilemap.HasTile(localPlace))
            {
                tileWorldLocations.Add(place);
            }
        }
    }
}

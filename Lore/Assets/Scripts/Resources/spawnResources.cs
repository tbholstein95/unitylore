using System.Collections;
using System.Collections.Generic;
using System.Drawing;
//using System.Numerics;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class spawnResources : MonoBehaviour
{
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

    // Start is called before the first frame update
    void Start()

    {
        GetAllTiles();

        //Get size of tilemap.  Tilemap should be compressed from Inspector to keep it within the used tile range.
        /*BoundsInt size = (tilemap.cellBounds);*/

        /*for(int i = 0; i < (numberOfTrees + numberOfRocks + numberOfGold); i++)
        {
            GetCoords();
        }*/

        //Generates number of Trees Equal to numberOfTrees Variable
        for(int i = 0; i < numberOfTrees; i++)
        {

            Vector3 spawnHere = tileWorldLocations[Random.Range(0, tileWorldLocations.Count)];
            tileWorldLocations.Remove(spawnHere);
            //Vector3 spawnHere = randomOptions[Random.Range(0, randomOptions.Count)];
            //randomOptions.Remove(spawnHere);
            GameObject objectInstance = Instantiate(treeReso, spawnHere, Quaternion.Euler(new Vector3(0, 0, 0)));
        }

        for (int i = 0; i < numberOfRocks; i++)
        {
            Vector3 spawnHere = tileWorldLocations[Random.Range(0, tileWorldLocations.Count)];
            tileWorldLocations.Remove(spawnHere);
            /*Vector3 spawnHere = randomOptions[Random.Range(0, randomOptions.Count)];
            randomOptions.Remove(spawnHere);*/
            GameObject objectInstance = Instantiate(rockReso, spawnHere, Quaternion.Euler(new Vector3(0, 0, 0)));
        }

        for (int i = 0; i < numberOfGold; i++)
        {
            Vector3 spawnHere = tileWorldLocations[Random.Range(0, tileWorldLocations.Count)];
            tileWorldLocations.Remove(spawnHere);
            /*Vector3 spawnHere = randomOptions[Random.Range(0, randomOptions.Count)];
            randomOptions.Remove(spawnHere);*/
            GameObject objectInstance = Instantiate(goldReso, spawnHere, Quaternion.Euler(new Vector3(0, 0, 0)));
        }
    }

    /*public void GetCoords()
    {
        BoundsInt size = (tilemap.cellBounds);
        float randCol = Random.Range(size.yMin, size.yMax);
        float randRow = Random.Range(size.xMin, size.xMax);
        Vector3 position = new Vector3(randCol, randRow);
        
        if (randomOptions.Contains(position))
        {
            bool spotAvailable = false;
            if (spotAvailable == false)
            {
                GetCoords();
            }
        }

        if(randomOptions.Contains(position) == false)
        {
            randomOptions.Add(position);
            spotAvailable = true;
        }

        

    }*/

    public void GetAllTiles()
    {
        BoundsInt size = (tilemap.cellBounds);
        TileBase[] allTiles = tilemap.GetTilesBlock(size);
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

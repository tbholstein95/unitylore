using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class spawnResources : MonoBehaviour
{
    public Tilemap tilemap;
    public List<Vector3> randomOptions;
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

        //Get size of tilemap.  Tilemap should be compressed from Inspector to keep it within the used tile range.
        /*BoundsInt size = (tilemap.cellBounds);*/

        for(int i = 0; i < (numberOfTrees + numberOfRocks + numberOfGold); i++)
        {
            /*float randCol = Random.Range(size.yMin, size.yMax);
            float randRow = Random.Range(size.xMin, size.xMax);
            Vector3 position = new Vector3(randCol, randRow);*/
            GetCoords();
            
        }
        

        

        //Generates number of Trees Equal to numberOfTrees Variable
        for(int i = 0; i < numberOfTrees; i++)
        {
            /*float randCol = Random.Range(size.yMin, size.yMax);
            float randRow = Random.Range(size.xMin, size.xMax);*/
            Vector3 spawnHere = randomOptions[Random.Range(0, randomOptions.Count)];
            randomOptions.Remove(spawnHere);
            GameObject objectInstance = Instantiate(treeReso, spawnHere, Quaternion.Euler(new Vector3(0, 0, 0)));
        }

        for (int i = 0; i < numberOfRocks; i++)
        {
            Vector3 spawnHere = randomOptions[Random.Range(0, randomOptions.Count)];
            randomOptions.Remove(spawnHere);
            GameObject objectInstance = Instantiate(rockReso, spawnHere, Quaternion.Euler(new Vector3(0, 0, 0)));
        }

        for (int i = 0; i < numberOfGold; i++)
        {
            Vector3 spawnHere = randomOptions[Random.Range(0, randomOptions.Count)];
            randomOptions.Remove(spawnHere);
            GameObject objectInstance = Instantiate(goldReso, spawnHere, Quaternion.Euler(new Vector3(0, 0, 0)));
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetCoords()
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

        

    }
}

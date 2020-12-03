using System.Collections;
using System.Collections.Generic;
using UnityEditor.iOS;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class TreeControl : MonoBehaviour
{
    bool clicking = false;

    public int quantity = 10;

    public Text woodDisplay;

    // Reso is resource manager for UI later and resource total information
    public GameObject reso;

    public int treeHealth = 50;

    public GameObject destroy;

    public Tilemap tilemap;

    public spawnResources spawnRes;

    private void Start()
    {
        reso = GameObject.FindWithTag("resoman");
        woodDisplay = GameObject.FindGameObjectWithTag("woodDisplay").GetComponent<Text>();
        woodDisplay.text = "Wood: " + reso.GetComponent<Rm>().getWoodUnits();
        GameObject temp = GameObject.Find("Tilemap");
        tilemap = temp.GetComponent<Tilemap>();
        GameObject temptwo = GameObject.Find("Tilemap");
        spawnRes = temptwo.GetComponent<spawnResources>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            clicking = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            clicking = false;
            destroy = null;
        }
    }
    public void OnMouseDown()
    { 
        if (clicking == true)
        {
            reso.GetComponent<Rm>().addWood(amount: quantity);
            woodDisplay.text = "Wood: " + reso.GetComponent<Rm>().getWoodUnits();
            treeHealth -= 10;
        }
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            Vector3 otherHit = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (hit.collider != null && hit.collider.tag != "Player")
            {
            destroy = hit.transform.parent.gameObject;
            }

            if (treeHealth <= 0)
            {
                Vector3 newHit = tilemap.WorldToCell(otherHit);
                Debug.Log(newHit + "I'm NEW");
                spawnRes.tileWorldLocations.Add(otherHit);
                foreach ( var x in spawnRes.tileWorldLocations)
                {
                    Debug.Log(x + "I'm in the list!");
                }
                Destroy(destroy);
                
            }
        }
           
    }

}

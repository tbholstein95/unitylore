using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockControl : MonoBehaviour
{
    bool clicking = false;

    //Basically max amount rock will provide. Should be divisible by quantity optimally, but doens't have to be.
    public int rockHealth = 50;

    //Sets how much rock player gets each click
    public int quantity = 10;

    //Resource Manager
    public GameObject reso;

    public Text rockDisplay;

    public GameObject destroy;

    private void Start()
    {
        reso = GameObject.FindWithTag("resoman");
        rockDisplay = GameObject.FindGameObjectWithTag("rockDisplay").GetComponent<Text>();
        rockDisplay.text = "Rocks: " + reso.GetComponent<Rm>().getRockUnits();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {   
        //Allows resource gathering.
        if (collision.gameObject.tag == "Player")
        {
            clicking = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //Controls player range and ability to gather resources.
        if (collision.gameObject.tag == "Player")
        {
            clicking = false;
            destroy = null;
        }

    }
    public void OnMouseDown()
    {
        //Allows rock harvesting.
        if (clicking == true)
        {
            reso.GetComponent<Rm>().addRock(amount: quantity);
            rockDisplay.text = "Rocks: " + reso.GetComponent<Rm>().getRockUnits();
            rockHealth -= 10;
        }
    }

    //TODO: This can potentially get moved to OnMouseDown.
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.tag != "Player")
            {
                destroy = hit.transform.parent.gameObject;
            }

            //Destroy rock object when it's out of health.
            if (rockHealth <= 0)
            {
                Destroy(destroy);
            }
        }

    }
}

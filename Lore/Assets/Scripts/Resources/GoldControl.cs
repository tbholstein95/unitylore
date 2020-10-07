using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldControl : MonoBehaviour
{
    bool clicking = false;

    public int quantity = 10;

    public int goldHealth = 50;

    public GameObject reso;

    public Text goldDisplay;

    public GameObject destroy;


    private void Start()
    {
        //Sets resource manager script
        reso = GameObject.FindWithTag("resoman");

        //UI Variables
        goldDisplay = GameObject.FindGameObjectWithTag("goldDisplay").GetComponent<Text>();
        goldDisplay.text = "Gold: " + reso.GetComponent<Rm>().getGoldUnits();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //If the player is close enough to Gold it will allow gathering.
        if (collision.gameObject.tag == "Player")
        {
            clicking = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //If player leaves range they'll no longer be able to harvest
            clicking = false;
            destroy = null;
        }

    }
    public void OnMouseDown()
    {
        if (clicking == true)
        {
            //Adds gold
            reso.GetComponent<Rm>().addGold(amount: quantity);
            //TODO: Create function to modify UI or create the variable at the start to create faster times.
            goldDisplay.text = "Gold: " + reso.GetComponent<Rm>().getGoldUnits();
            goldHealth -= 10;
        }
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.tag != "Player")
            {
                destroy = hit.transform.parent.gameObject;
            }

            if (goldHealth <= 0)
            {
                Destroy(destroy);
            }
        }
    }
}

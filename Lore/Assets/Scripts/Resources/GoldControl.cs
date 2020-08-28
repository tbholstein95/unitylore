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
        reso = GameObject.FindWithTag("resoman");
        goldDisplay = GameObject.FindGameObjectWithTag("goldDisplay").GetComponent<Text>();
        goldDisplay.text = "Gold: " + reso.GetComponent<Rm>().getGoldUnits();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player in Tree Range of Gold");
            clicking = true;
            //Debug.Log(clicking);

        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            clicking = false;
            //Debug.Log(clicking);
            destroy = null;
        }

    }
    public void OnMouseDown()
    {
        if (clicking == true)
        {
            reso.GetComponent<Rm>().addGold(amount: quantity);
            //Debug.Log(reso.GetComponent<Rm>().getGoldUnits());
            goldDisplay.text = "Gold: " + reso.GetComponent<Rm>().getGoldUnits();
            goldHealth -= 10;
        }
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                destroy = hit.transform.parent.gameObject;
                /*if (hit.transform.parent.gameObject == gameObject) Destroy(gameObject);*/
            }

            if (goldHealth <= 0)
            {
                Destroy(destroy);
            }
        }

    }
}

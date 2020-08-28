using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockControl : MonoBehaviour
{
    bool clicking = false;

    public int rockHealth = 50;

    public int quantity = 10;

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
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player in Tree Range of Rock");
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

            reso.GetComponent<Rm>().addRock(amount: quantity);
            rockDisplay.text = "Rocks: " + reso.GetComponent<Rm>().getRockUnits();
            //Debug.Log(reso.GetComponent<Rm>().getRockUnits());
            rockHealth -= 10;

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

            if (rockHealth <= 0)
            {
                Destroy(destroy);
            }
        }

    }
}

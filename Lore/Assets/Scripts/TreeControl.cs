using System.Collections;
using System.Collections.Generic;
using UnityEditor.iOS;
using UnityEngine;
using UnityEngine.UI;

public class TreeControl : MonoBehaviour
{
    bool clicking = false;

    public int quantity = 10;

    public Text woodDisplay;

    // Reso is resource manager for UI later and resource total information
    public GameObject reso;

    public int treeHealth = 50;

    public GameObject destroy;

    private void Start()
    {
        reso = GameObject.FindWithTag("resoman");
        woodDisplay = GameObject.FindGameObjectWithTag("woodDisplay").GetComponent<Text>();
        woodDisplay.text = "Wood: " + reso.GetComponent<Rm>().getWoodUnits();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Player in Tree Range of Tree");
            clicking = true;
            //Debug.Log(clicking);

        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
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
            reso.GetComponent<Rm>().addWood(amount: quantity);
            woodDisplay.text = "Wood: " + reso.GetComponent<Rm>().getWoodUnits();
            //Debug.Log(reso.GetComponent<Rm>().getWoodUnits());
            treeHealth -= 10;
            
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

            if (treeHealth <= 0)
            {
                Destroy(destroy);
            }
        }
           
    }

}

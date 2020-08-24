using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldControl : MonoBehaviour
{
    bool clicking = false;
    public int quantity = 10;
    public GameObject reso;

    private void Start()
    {
        reso = GameObject.FindWithTag("resoman");
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player in Tree Range of Gold");
            clicking = true;
            Debug.Log(clicking);

        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            clicking = false;
            Debug.Log(clicking);

        }

    }
    public void OnMouseDown()
    {
        if (clicking == true)
        {

            reso.GetComponent<Rm>().addGold(amount: quantity);
            Debug.Log(reso.GetComponent<Rm>().getGoldUnits());

        }

    }
}

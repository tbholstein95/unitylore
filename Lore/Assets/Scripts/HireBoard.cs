using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HireBoard : MonoBehaviour
{
    bool clicking = false;

    public GameObject HireBoardUI;
    // Start is called before the first frame update
    void Start()
    {
        HireBoardUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggle()
    {
        Debug.Log("I turned the hire board on!");
        HireBoardUI.SetActive(!HireBoardUI.activeSelf);
    }

    private void OnCollisionEnter2D(Collision2D collision)
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
            toggle();
        }
    }

    public void OnMouseDown()
    {
        if(clicking == true)
        {
            toggle();
        }
    }


}

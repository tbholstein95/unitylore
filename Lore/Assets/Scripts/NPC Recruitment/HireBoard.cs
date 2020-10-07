using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HireBoard : MonoBehaviour
{
    bool clicking = false;

    public GameObject HireBoardUI;

    public ButtonListControl BLC;

    //Turns off the UI at the start of the game.
    void Start()
    {
        HireBoardUI.SetActive(false);
    }

    void Update()
    {
        //If proper time, set the List, then after clear it.
        if(GameTime.refreshList == true)
        {
            GetDayList();
        }

        if(GameTime.clearList == true)
        {
            ClearList();
        }
    }

    //Turn UI on and off.
    public void toggle()
    {
        HireBoardUI.SetActive(!HireBoardUI.activeSelf);
    }

    public void GetDayList()
    {
        BLC.GenerateList();
        GameTime.refreshList = false;
    }

    public void ClearList()
    {
        BLC.DestroyList();
        Recruitment.InnRecruits.Clear();
        GameTime.clearList = false;
    }

    //If player is close enough to the board they can open it.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            clicking = true;
        }
    }

    //If player walks away it closes.
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            HireBoardUI.SetActive(false);
        }
    }

    //Does the clicking.
    public void OnMouseDown()
    {
        if(clicking == true)
        {
            toggle();
        }
    }


}

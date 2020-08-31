using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HireBoard : MonoBehaviour
{
    bool clicking = false;

    public GameObject HireBoardUI;

    public ButtonListControl BLC;

    // Start is called before the first frame update
    void Start()
    {
        HireBoardUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameTime.refreshList == true)
        {
            GetDayList();
        }

        if(GameTime.clearList == true)
        {
            ClearList();
        }
    }

    public void toggle()
    {
        Debug.Log("I turned the hire board on!");
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
            HireBoardUI.SetActive(false);
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

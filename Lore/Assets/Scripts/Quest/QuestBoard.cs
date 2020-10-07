using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestBoard : MonoBehaviour
{
    //Sets status of whether or not the player is able to open the board.
    bool clicking = false;

    //Controls if the board will display or not.
    public GameObject QuestBoardUI;

    //Allows the generation of buttons onto the board.
    public QuestButtonListControl QLC;

    void Start()
    {
        QuestBoardUI.SetActive(false);
    }

    void Update()
    {
        if (GameTime.refreshList == true)
        {
            GetQuestList();
        }
    }

    public void toggle()
    {
        Debug.Log("I turned the hire board on!");
        QuestBoardUI.SetActive(!QuestBoardUI.activeSelf);
    }

    public void GetQuestList()
    {
        QLC.GenerateList();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            clicking = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            QuestBoardUI.SetActive(false);
        }
    }

    public void OnMouseDown()
    {
        if (clicking == true)
        {
            toggle();
        }
    }




}

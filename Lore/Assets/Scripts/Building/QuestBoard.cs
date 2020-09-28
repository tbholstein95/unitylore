using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestBoard : MonoBehaviour
{
    bool clicking = false;

    public GameObject QuestBoardUI;

    public QuestButtonListControl QLC;
    // Start is called before the first frame update
    void Start()
    {
        QuestBoardUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameTime.refreshList == true)
        {
            GetQuestList();
        }

       /* if (GameTime.clearList == true)
        {
            ClearList();
        }*/


    }

    public void toggle()
    {
        Debug.Log("I turned the hire board on!");
        QuestBoardUI.SetActive(!QuestBoardUI.activeSelf);
    }

    public void GetQuestList()
    {
        QLC.GenerateList();
        //GameTime.refreshList = false;
    }

/*    public void ClearList()
    {
        QLC.DestroyList();
        Recruitment.InnRecruits.Clear();
        GameTime.clearList = false;
    }*/

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendingManager : MonoBehaviour
{
    public GameObject hero;

    public int timeToComeBack;

    public int secs;

    public int set;


    public void Sending()
    {
        hero.transform.position = new Vector3(-100, -100);
    }

    public void Returning()
    {
        hero.transform.position = new Vector3(0, 0);
    }





    // Update is called once per frame
    void Update()
    {
        Debug.Log(timeToComeBack + "time to comeback");
        secs = GameTime.returnTime();
        Debug.Log(secs + "sec");
        if (secs == timeToComeBack)
        {
            Debug.Log("Dangit yall");
            Returning();
        }
    }
}

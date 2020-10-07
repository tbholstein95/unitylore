using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildButtonListButton : MonoBehaviour
{
    //Name of button generated
    public Text myText;



    private string myTextString;


    //Sets button texts
    public void SetText(string textString)
    {
        //Names generated button
        myTextString = textString;
        myText.text = textString;
    }


}

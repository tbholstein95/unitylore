using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestButtonListButton : MonoBehaviour
{
    //Holds info for instantiating quest name buttons.
    public Text myText;

    private string myTextString;
    public void SetText(string textString)
    {
        myTextString = textString;
        myText.text = textString;
    }

    public void SetName(string text)
    {
        myTextString = text;
    }
}

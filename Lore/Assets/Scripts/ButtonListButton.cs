using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonListButton : MonoBehaviour
{

    [SerializeField]
    private Text myText;

    [SerializeField]
    private ButtonListControl buttonControl;

    GameObject innPerson;

    private string myTextString;
    public void SetText(string textString)
    {
        myTextString = textString;
        myText.text = textString;
    }

    public void OnClick(string text)
    {
        /*GameObject innPerson = GameObject.Find(myTextString);
        GameObject spawnPerson = Instantiate(innPerson);*/
        //buttonControl.ButtonClicked(myTextString);
        Debug.Log(myTextString);

    }

    public void SetName(string text)
    {
        myTextString = text;

    }
}

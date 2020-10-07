using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIclose : MonoBehaviour
{
    //Used for General UI Panel closing.
    public GameObject UIPanel;
    
    public void OnClick()
    {
        UIPanel.SetActive(false);
    }
}

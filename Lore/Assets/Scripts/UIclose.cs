using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIclose : MonoBehaviour
{
    public GameObject UIPanel;
    
    public void OnClick()
    {
        UIPanel.SetActive(false);
    }
}

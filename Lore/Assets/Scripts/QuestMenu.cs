using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestMenu : MonoBehaviour
{
    public GameObject questMenuUI;
    // Start is called before the first frame update
    private void Start()
    {
        questMenuUI.SetActive(false);
    }

    public void toggle()
    {
        questMenuUI.SetActive(!questMenuUI.activeSelf);
    }


}

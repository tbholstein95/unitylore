using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rewards : MonoBehaviour
{
    public List<GameObject> rewardItems;
    public Transform RewardsContainer;
    public List<GameObject> ListOfRewards;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform child in RewardsContainer.transform)
        {
            ListOfRewards.Add(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

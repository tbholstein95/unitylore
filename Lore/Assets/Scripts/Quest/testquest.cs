using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testquest : MonoBehaviour
{
    //Attached to the quest that is generated. Holds values to be used by quest checker.
    public string questname;
    public int combatants;
    public int difficulty;
    public List<GameObject> ListOfRewards;
}

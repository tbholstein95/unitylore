using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //Put on each NPC in order to have inventory system.
    public List<RewardStats> inventorySlots;


    public GameObject Adventurer;

    public int inventory_size = 10;

    public void AddItem(GameObject Addingitem)
    {
        RewardStats itemToAdd = Addingitem.GetComponent<RewardStats>();
        Debug.Log(inventorySlots.Count + "INVENTORY SLOTS");

        for(var i = 0; i + 1 <= inventory_size; i++)
        {
            if(inventorySlots[inventorySlots.Count - 1] != null)
            {
                Debug.Log("Inventory Full");
            }
            else if (inventorySlots[i] != null)
            {
                Debug.Log("Inventory slot " + i + " full");
            }
            else if (inventorySlots[i] == null)
            {
                Debug.Log("Adding this bad boy at " + i);
                inventorySlots[i] = itemToAdd;
                break;
            }



        }
    }

    public void ListAllItems()
    {
        foreach(RewardStats item in inventorySlots)
        {
            Debug.Log(item.name + "IN HIS INVENTORY");
        }
    }

    public void SetInventorySize()
    {
        for(var x = 0; x < inventory_size; x++)
        {
            inventorySlots.Add(null);
        }
    }
}

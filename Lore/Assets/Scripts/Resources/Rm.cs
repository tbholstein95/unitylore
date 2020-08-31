using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Rm : MonoBehaviour
{
    public static int woodUnits = 0;
    public static int rockUnits = 0;
    public static int goldUnits = 0;
    public int amount;
    
    public void addWood(int amount)
    {
        woodUnits += amount;
    }

    public void removeWood(int amount)
    {
        woodUnits -= amount;
    }

    public int getWoodUnits()
    {
        return woodUnits;
    }

    public void addRock(int amount)
    {
        rockUnits += amount;
    }

    public void removeRock(int amount)
    {
        rockUnits -= amount;
    }

    public int getRockUnits()
    {
        return rockUnits;
    }

    public void addGold(int amount)
    {
        goldUnits += amount;
    }

    public void removeGold(int amount)
    {
        goldUnits -= amount;
    }

    public int getGoldUnits()
    {
        return goldUnits;
    }
}

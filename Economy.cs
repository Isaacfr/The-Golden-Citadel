using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Economy : MonoBehaviour
{
    public int cash;
    public Text cashText;

    TowerManager towerManager;
    
    void Start()
    {
        cash = 50;
        towerManager = TowerManager.instance;
    }

    void Update()
    {
        cashText.text = "Gold: " + cash;
    }

    public void AddCash(int amount)
    {
        cash = cash + amount;  
    }

    public void BuySoldier()
    {
        if (cash >= 10)
        {
            towerManager.SetTowerToBuild(towerManager.standardWarriorPrefab);
            cash = cash - 10;
        }
        else
        {
            Debug.Log("Cannot buy warrior");
        }
    }

    public void BuyGolden()
    {
        if (cash >= 100)
        {
            towerManager.SetTowerToBuild(towerManager.standardGoldenPrefab);
            cash = cash - 100;
        }
        else
        {
            Debug.Log("caanot buy archer");
        }

    }
}

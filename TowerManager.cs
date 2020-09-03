using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public static TowerManager instance;

    void Awake()
    {
        instance = this;
    }

    public GameObject standardWarriorPrefab;
    public GameObject standardGoldenPrefab;

    void Start()
    {
        towerToBuild = null;
    }

    private GameObject towerToBuild;

    public GameObject GetTowerToBuild()
    {
        return towerToBuild;
    }

    public void SetTowerToBuild(GameObject tower)
    {
        towerToBuild = tower;
    }
}

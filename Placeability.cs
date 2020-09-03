using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Placeability : MonoBehaviour
{
    private bool isPlaceable = true;

    GameObject economySystem;
    Economy economy;

    [SerializeField] private Color hoverColor;
    Renderer rend;
    private Color startColor = Color.white;

    private GameObject tower;

    TowerManager towerManager;

    void Start()
    {
        economySystem = GameObject.Find("EconomySystem");
        economy = economySystem.GetComponent<Economy>();

        rend = GetComponent<Renderer>();

        towerManager = TowerManager.instance;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tower")
        {
            isPlaceable = false;
        }
    }
    
    void OnMouseEnter()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (towerManager.GetTowerToBuild() == null)
        {
            return;
        }

        rend.material.color = hoverColor;

        if(isPlaceable == false)
        {
            rend.material.color = Color.red;
        }
    }
    
    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    void OnMouseOver()
    {
        if (isPlaceable == false)
        {
            return;
        }
        else
        {
            if(Input.GetMouseButtonDown(0))
            {
                if (towerManager.GetTowerToBuild() == null)
                {
                    return;
                }

                if (tower != null)
                {
                    return;
                }
                
                GameObject towerToBuild = towerManager.GetTowerToBuild();
                if(Input.GetMouseButtonUp(0) == false)
                {
                    tower = (GameObject)Instantiate(towerToBuild, transform.position, Quaternion.identity);
                    towerManager.SetTowerToBuild(null);
                    isPlaceable = false;
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Base1 : MonoBehaviour
{
    [SerializeField] int baseHP = 1;
    public Text hpText;
    private int addToEnemyCount;

    GameObject enemySpawn;

    void Start()
    {
        hpText.text = "HP: " + baseHP;
        enemySpawn = GameObject.Find("EnemySpawn");
        addToEnemyCount = enemySpawn.GetComponent<TutorialSpawn>().enemyCount;
    }
    void Update()
    {
        hpText.text = "HP: " + baseHP;
        if (baseHP <= 0)
        {
            SceneManager.LoadScene("Title_Scene");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Debug.Log("Base is hit");
            baseHP = baseHP - 1;
            Destroy(other);
            addToEnemyCount++;

            if(baseHP <= 0)
            {
                Debug.Log("GameOver");
            }
        }
    }
}

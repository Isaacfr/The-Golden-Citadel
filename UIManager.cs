using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject spawner;
    public GameObject startButton;
    public Text startText;
    public int roundNumber = 0;

    GameObject enemySpawnObject;
    public bool spawnEnemies;

    void Start()
    {
        startText.text = ("Round " + roundNumber);
        enemySpawnObject = GameObject.Find("EnemySpawn");
        spawnEnemies = enemySpawnObject.GetComponent<EnemySpawn>().enemySpawn;
        //StartRound();
    }
    void Update()
    {
        startText.text = ("Round " + roundNumber);
        if (spawnEnemies == false)
        {
            StartRound();
        }
        Debug.Log(spawnEnemies);
    }


    public void StartButton()
    {
        roundNumber++;
        enemySpawnObject.GetComponent<EnemySpawn>().spawnAtAll = true;
        spawnEnemies = true;
        spawner.SetActive(true);
        startButton.SetActive(false);
    }

    public void StartRound()
    {
        startButton.SetActive(true);
        spawnEnemies = false;
        spawner.SetActive(false);
    }
}

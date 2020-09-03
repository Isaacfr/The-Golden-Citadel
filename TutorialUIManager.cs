using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialUIManager : MonoBehaviour
{
    public GameObject spawner;
    public GameObject startButton;

    GameObject enemySpawnObject;
    public bool spawnEnemies;

    void Start()
    {
        enemySpawnObject = GameObject.Find("EnemySpawn");
        spawnEnemies = enemySpawnObject.GetComponent<TutorialSpawn>().enemySpawn;
        //StartRound();
    }
    void Update()
    {
        if (spawnEnemies == false)
        {
            StartRound();
        }
        Debug.Log(spawnEnemies);
    }


    public void StartButton()
    {
        enemySpawnObject.GetComponent<TutorialSpawn>().spawnAtAll = true;
        spawnEnemies = true;
        spawner.SetActive(true);
        startButton.SetActive(false);
    }

    public void StartRound()
    {
        Debug.Log("startRound");
        spawnEnemies = false;
        spawner.SetActive(false);
    }
}

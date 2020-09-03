using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] float secondsBeforeSpawn = 2f;
    public EnemyMovement enemyPrefab;
    public EnemyMovement enemy2Prefab;
    public EnemyMovement enemy3Prefab;
    public int enemyCount = 0;

    public bool spawnAtAll = true;
    public bool enemySpawn;

    bool spawnWin = true;

    GameObject spawnManager;
    UIManager uiManager;

    public GameObject winText;

    void Start()
    {
        winText.SetActive(false);
        enemySpawn = true;
        spawnManager = GameObject.Find("SpawnSystem");
        uiManager = spawnManager.GetComponent<UIManager>();
    }

    void Update()
    {

        if (enemyCount == 3)
        {
            StallSpawning();
        }
        else if(enemyCount == 8)
        {
            StallSpawning();
        }
        else if (enemyCount == 15)
        {
            StallSpawning();
        }
        else if (enemyCount == 25)
        {
            StallSpawning();
        }
        else if (enemyCount == 36)
        {
            StallSpawning();
        }
        else if (enemyCount == 45)
        {
            StallSpawning();
        }
        else
        {
            StartCoroutine(SpawnEnemy());
            Debug.Log(enemyCount);
        }
        if(uiManager.roundNumber == 6 && spawnWin == true)
        {
            winText.SetActive(true);
            spawnWin = false;
        }
    }

    public void StallSpawning()
    {
        spawnManager.GetComponent<UIManager>().spawnEnemies = false;
        spawnAtAll = false;
        enemyCount++;
    }

    public void SetWinOff()
    {
        winText.SetActive(false);
    }

    IEnumerator SpawnEnemy()
    {
        while (spawnAtAll == true && enemySpawn == true)
        {

            if (enemyCount % 5 == 0 && enemyCount != 0)
            {
                Instantiate(enemy2Prefab, transform.position, Quaternion.identity);
                spawnAtAll = false;
                enemyCount++;
            }

            else if (enemyCount % 12 == 0 && enemyCount != 0)
            {
                Instantiate(enemy3Prefab, transform.position, Quaternion.identity);
                spawnAtAll = false;
                enemyCount++;
            }
            else
            {
                Instantiate(enemyPrefab, transform.position, Quaternion.identity);
                spawnAtAll = false;
                enemyCount++;
            }
            yield return new WaitForSeconds(secondsBeforeSpawn);
            spawnAtAll = true;
        }
    }
}

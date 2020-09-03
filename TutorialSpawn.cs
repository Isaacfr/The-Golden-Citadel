using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSpawn : MonoBehaviour
{
    [SerializeField] float secondsBeforeSpawn = 2f;
    public EnemyMovement enemyPrefab;
    public int enemyCount = 0;

    public bool spawnAtAll = true;
    public bool enemySpawn;

    GameObject spawnManager;
    public int enemyDeath = 0;

    public GameObject winStatus;

    void Start()
    {
        winStatus.SetActive(false);
        enemySpawn = true;
        spawnManager = GameObject.Find("SpawnSystem");
    }

    void Update()
    {

        if (enemyDeath >= 5)
        {
            StallSpawning();
        }
        else
        {
            StartCoroutine(SpawnEnemy());
            Debug.Log(enemyCount);
        }

        Debug.Log("number" + enemyDeath);
        if (enemyDeath >= 5)
        {
            winStatus.SetActive(true);
        }
    }

    public void StallSpawning()
    {
        spawnManager.GetComponent<TutorialUIManager>().spawnEnemies = false;
        spawnAtAll = false;
        enemyCount++;
    }

    IEnumerator SpawnEnemy()
    {
        while (spawnAtAll == true && enemySpawn == true)
        {

            if (enemyDeath >= 5 )
            {
                spawnAtAll = false;
                enemySpawn = false;
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

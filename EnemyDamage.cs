using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hp = 10;
    private int damage = 1;
    public int money = 1;
    public int enemyDeaths = 0;

    GameObject economySystem;
    Economy economy;

    GameObject EnemySpawn;
    TutorialSpawn tutorialSpawn;

    Tower tower;

    [SerializeField] private Slider slider;
    [SerializeField] private Gradient gradient;
    [SerializeField] private Image fill;

    void Start()
    {
        economySystem = GameObject.Find("EconomySystem");
        economy = economySystem.GetComponent<Economy>();

        EnemySpawn = GameObject.Find("EnemySpawn");
        tutorialSpawn = EnemySpawn.GetComponent<TutorialSpawn>();
        

        slider.maxValue = hp;
        fill.color = gradient.Evaluate(1f);

    }

    public void EnemyHit(int damage)
    {
        hp = hp - damage;
        slider.value = hp;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        if (hp <= 0)
        {
            KillEnemy();
        }
    }

    public void KillEnemy()
    {
        Destroy(gameObject);
        economy.AddCash(money);
        if (tutorialSpawn != null)
        {
            tutorialSpawn.enemyDeath++;
        }
        Debug.Log("deaths" + enemyDeaths);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Damage")
        {
            tower = other.gameObject.transform.root.GetComponent<Tower>();
            int towerDamage = Mathf.RoundToInt(tower.atkDamage);
            EnemyHit(towerDamage);
        }
        if(other.tag == "Base")
        {
            Destroy(gameObject);
        }
    }
}

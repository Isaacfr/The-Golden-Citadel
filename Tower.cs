using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    Vector3 enemyPosition;

    [SerializeField] float attackRange = 150f;
    [SerializeField] float atkSpeed = 1f;
    public float atkDamage = 4f;
    private bool isAttacking;
    Animator myAnimator;
    Collider boxCollider;

    void Start()
    {
        myAnimator = this.GetComponentInChildren<Animator>();
        boxCollider = this.GetComponentInChildren<BoxCollider>();
    }
    void Update()
    {
        SetEnemy();
    }

    void SetEnemy()
    {
        EnemyDamage[] allEnemies = GameObject.FindObjectsOfType<EnemyDamage>();
        if (allEnemies.Length <= 0)
        {
            myAnimator.SetBool("isAttacking", false);
        }
        else
        {
            float enemyDistance = Mathf.Infinity;
            EnemyDamage closestEnemy;

            foreach (EnemyDamage nearestEnemy in allEnemies)
            {

                float distanceToEnemy = (nearestEnemy.transform.position - this.transform.position).sqrMagnitude;
                if (distanceToEnemy < enemyDistance)
                {
                    enemyDistance = distanceToEnemy;
                    closestEnemy = nearestEnemy;
                    enemyPosition = closestEnemy.transform.position;
                }

            }
            float closestDistance = Vector3.Distance(enemyPosition, this.transform.position);

            if (closestDistance <= attackRange)
            {
                objectToPan.LookAt(enemyPosition);
                myAnimator.SetBool("isAttacking", true);
            }
            else
            {
                myAnimator.SetBool("isAttacking", false);
            }
        }
        Debug.DrawLine(enemyPosition, this.transform.position);
    }

}


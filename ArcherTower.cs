using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherTower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    Vector3 enemyPosition;

    [SerializeField] float attackRange = 150f;
    [SerializeField] float atkSpeed = 1f;
    public float atkDamage = 4f;
    private bool isAttacking;
    Animator myAnimator;
    Collider boxCollider;

    Vector3 arrowPostion = new Vector3(0f, 65f, -55f);

    [SerializeField] GameObject arrowPrefab;
    float arrowImpulse = 10f;

    float arrowTime = 0.0f;

    void Start()
    {
        myAnimator = this.GetComponentInChildren<Animator>();
        boxCollider = this.GetComponentInChildren<BoxCollider>();
    }
    void Update()
    {
        arrowTime = Time.deltaTime;
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
                if(arrowTime > 0.01f)
                {
                    arrowTime -= 0.01f;
                    GameObject arrow = (GameObject)Instantiate(arrowPrefab, transform.position + arrowPostion, Quaternion.identity);
                    arrow.GetComponent<Rigidbody>().AddForce(transform.forward * arrowImpulse, ForceMode.Impulse);
                }
                //StartCoroutine(FireArrow());
            }
            else
            {
                myAnimator.SetBool("isAttacking", false);
            }
        }
        Debug.DrawLine(enemyPosition, this.transform.position);
    }
    /*
    IEnumerator FireArrow()
    {
        if (arrow)
        GameObject arrow = (GameObject)Instantiate(arrowPrefab, transform.position + arrowPostion, Quaternion.identity);
        arrow.GetComponent<Rigidbody>().AddForce(transform.forward * arrowImpulse, ForceMode.Impulse);
        yield return new WaitForSeconds(1f);
    }
    */
}


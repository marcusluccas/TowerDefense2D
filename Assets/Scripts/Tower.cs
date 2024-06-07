using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float attackDemage;
    public float attackSpeed;
    public float attackRange;
    public GameObject projetile;
    public float attackCooldown = 0;
    public GameObject targetEnemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Shoot();
    }

    void Shoot()
    {
        attackCooldown += Time.deltaTime;
        if (attackCooldown > attackSpeed)
        {
            if (targetEnemy == null)
            {
                targetEnemy = FindTarget();
            }
            else
            {
                GameObject projetileInstance = Instantiate(projetile, transform.position, Quaternion.identity);
                projetileInstance.GetComponent<Projectile>().projectileDemage = attackDemage;
                projetileInstance.GetComponent<Projectile>().target = targetEnemy.transform;
                attackCooldown = 0;
            }
        }
    }

    GameObject FindTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            if (Vector2.Distance(transform.position, enemy.transform.position) < attackRange)
            {
                return enemy;
            }
        }
        return null;
    }
}

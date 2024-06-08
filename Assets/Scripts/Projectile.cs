using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileDemage;
    public Transform target;

    public bool isCanon = false;
    public float projectileRadius;

    public bool isSlow = false;

    public bool isPoison = false;
    public float poisonStacks;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, 5 * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyMovement>().TakeDemage(projectileDemage);

            if (isCanon)
            {
                Collider2D[] enemys = Physics2D.OverlapCircleAll(transform.position, projectileRadius);

                foreach (Collider2D col in enemys)
                {
                    if (col.gameObject.tag == "Enemy")
                    {
                        col.gameObject.GetComponent<EnemyMovement>().TakeDemage(projectileDemage);
                    }
                }
            }

            if (isSlow)
            {
                collision.gameObject.GetComponent<EnemyMovement>().speed *= 0.8f;
            }

            if (isPoison)
            {
                collision.gameObject.GetComponent<EnemyMovement>().poisonStacks += poisonStacks;
            }

            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public int towerPrice;
    public float attackDemage;
    public float attackSpeed;
    public float attackRange;
    public GameObject projetile;
    public float attackCooldown = 0;
    public GameObject targetEnemy;

    public bool isBuilding = false;
    int blockCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isBuilding == false)
        {
            Shoot();
        }
    }

    private void Update()
    {
        if (isBuilding)
        {
            BuildingMode();
        }
    }

    void Shoot()
    {
        attackCooldown += Time.deltaTime;
        if (attackCooldown > attackSpeed)
        {
            if (targetEnemy == null || Vector3.Distance(transform.position, targetEnemy.transform.position) > attackRange)
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

    void BuildingMode()
    {
        transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0f);

        if (blockCount <= 0 && WaveManager.instance.playerMoney >= towerPrice)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;

            if (Input.GetMouseButtonUp(0))
            {
                isBuilding = false;
                WaveManager.instance.playerMoney -= towerPrice;
                WaveManager.instance.UpdateHUD();
                BuildingManager.instance.buildingUI.SetActive(true);
                gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BuildingManager.instance.buildingUI.SetActive(true);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Blocked")
        {
            blockCount++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Blocked")
        {
            blockCount--;
        }
    }
}

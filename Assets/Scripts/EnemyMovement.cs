using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    int nextPoint;

    public float maxHP;
    public float currHP;

    public int enemyGold;

    public float speed;

    public float poisonStacks;
    public float poisonCooldown;

    // Start is called before the first frame update
    void Start()
    {
        currHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == MapPointManager.instance.mapPoints[nextPoint].position) { nextPoint++; }
        transform.position = Vector3.MoveTowards(transform.position, MapPointManager.instance.mapPoints[nextPoint].position, speed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        IsPoisoned();
    }

    public void TakeDemage(float demage)
    {
        currHP -= demage;
        if (currHP <= 0)
        {
            WaveManager.instance.nMonsterLeft--;
            WaveManager.instance.playerMoney += enemyGold;
            WaveManager.instance.UpdateHUD();
            Destroy(gameObject);
        }
    }

    void IsPoisoned()
    {
        if (poisonStacks > 0)
        {
            poisonCooldown += Time.deltaTime;
            if (poisonCooldown > 1)
            {
                TakeDemage(poisonStacks);
                poisonCooldown = 0;
            }
        }
    }
}

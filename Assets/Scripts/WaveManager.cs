using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance { get; private set; }

    public int playerHP;
    public int playerMoney;
    public int wave;
    int nMonsterSpawned;
    public List<WaveScriptable> waves;
    public int nMonsterLeft;
    public Transform spawnLocation;

    public TMP_Text playerHPText;
    public TMP_Text playerMoneyText;
    public TMP_Text waveText;

    public GameObject gameOverScreen;

    public GameObject victoryScreen;

    float spawnCooldownCount;
    public float spawnCooldown;
    bool canSpawnEnemies = false;
    public GameObject startWaveButton;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateHUD();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canSpawnEnemies)
        {
            SpawnEnemies(waves[wave - 1].monster);
        }
    }

    public void UpdateHUD()
    {
        playerHPText.text = "HP: " + playerHP.ToString();
        playerMoneyText.text = "$" + playerMoney.ToString();
        waveText.text = "Wave: " + wave.ToString();
    }

    public void RemoveHP()
    {
        playerHP--;
        UpdateHUD();

        if (playerHP <= 0)
        {
            gameOverScreen.SetActive(true);
        }
    }

    public void StartWave()
    {
        nMonsterLeft = waves[wave - 1].nMonsters;
        nMonsterSpawned = 0;
        startWaveButton.SetActive(false);
        canSpawnEnemies = true;
    }

    void SpawnEnemies(GameObject enemy)
    {
        spawnCooldownCount -= Time.deltaTime;
        if (nMonsterSpawned < waves[wave - 1].nMonsters && spawnCooldownCount <= 0)
        {
            Instantiate(enemy, spawnLocation.position, Quaternion.identity);
            spawnCooldownCount = spawnCooldown;
            nMonsterSpawned++;
        }

        if (nMonsterLeft <= 0)
        {
            if (wave >= waves.Count)
            {
                victoryScreen.SetActive(true);
                gameObject.SetActive(false);
            }

            wave++;
            UpdateHUD();
            startWaveButton.SetActive(true);
            canSpawnEnemies = false;
        }
    }
}

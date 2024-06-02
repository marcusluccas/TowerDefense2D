using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance { get; private set; }

    public int playerHP;
    public int playerMoney;
    public int wave;

    public TMP_Text playerHPText;
    public TMP_Text playerMoneyText;
    public TMP_Text waveText;

    public GameObject gameOverScreen;

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
    void Update()
    {

    }

    void UpdateHUD()
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
}

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //[SerializeField] private string playerName;
    [SerializeField] private int startingClics;
    [SerializeField] private int gold;
    private int goldMultiplier;
    [SerializeField] private int runs;
    [SerializeField] public float damage;
    [SerializeField] public float bombDamage;

    [Header("Prices")]
    [SerializeField] private int clicPrice;
    [SerializeField] private int damagePrice;
    [SerializeField] private int bombDamagePrice;

    //Current Run
    private int clics;

    private void Awake()
    {
        GetPlayerData();
    }

    private void GetPlayerData()
    {
        startingClics = PlayerPrefs.GetInt("StartingClics", 20);
        clics = startingClics;
        gold = PlayerPrefs.GetInt("Gold", 0);
        damage = PlayerPrefs.GetFloat("Damage", 1f);
        bombDamage = PlayerPrefs.GetFloat("BombDamage", 3f);

        clicPrice = PlayerPrefs.GetInt("ClicPrice", 10);
        damagePrice = PlayerPrefs.GetInt("DamagePrice", 2500);
        bombDamagePrice = PlayerPrefs.GetInt("BombDamagePrice", 1000);
    }

    public int GetClics()
    {
        return clics;
    }
    public void RestClics()
    {
        clics -= 1;
        if (clics <= 0)
        {
            StartCoroutine(RestartLevel());
        }
    }

    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void AddClics(int amount)
    {
        clics += amount;
    }

    public void RestartClics()
    {
        clics = startingClics;
    }

    public int GetGold()
    {
        return gold;
    }

    public void AddGold(int amount)
    {
        if (goldMultiplier > 0) 
        { 
            gold += amount * 2; 
            goldMultiplier -= 1; 
        }
        else gold += amount;

        PlayerPrefs.SetInt("Gold", gold);
    }

    public void AddGoldMultiplier()
    {
        goldMultiplier += 10;
    }

    public int GetRuns()
    {
        return runs;
    }

    public int GetClicPrice()
    {
        return clicPrice;
    }
    public int GetClicDamagePrice()
    {
        return damagePrice;
    }
    public int GetBombDamagePrice()
    {
        return bombDamagePrice;
    }

    //Incremental functions
    public void IncreaseClics()
    {
        if (gold < clicPrice) return;

        startingClics += 1;
        gold -= clicPrice;

        clicPrice += 5;

        PlayerPrefs.SetInt("Gold", gold);
        PlayerPrefs.SetInt("StartingClics", startingClics);
        PlayerPrefs.SetInt("ClicPrice", clicPrice);
    }

    public void IncreaseClicDamage()
    {
        if (gold < damagePrice) return;

        damage += 1;
        gold -= damagePrice;

        damagePrice *= 2;

        PlayerPrefs.SetInt("Gold", gold);
        PlayerPrefs.SetFloat("Damage", damage);
        PlayerPrefs.SetInt("DamagePrice", damagePrice);
    }

    public void IncreaseBombDamage()
    {
        if (gold < bombDamagePrice) return;

        bombDamage += 3;
        gold -= bombDamagePrice;           

        bombDamagePrice *= 2;

        PlayerPrefs.SetInt("Gold", gold);
        PlayerPrefs.SetFloat("BombDamage", bombDamage);
        PlayerPrefs.SetInt("BombDamagePrice", bombDamagePrice);
    }
}

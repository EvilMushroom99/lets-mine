using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI clicsUI;
    [SerializeField] private TextMeshProUGUI goldUI;
    [SerializeField] private GameObject storeUI;
    [SerializeField] private TextMeshProUGUI clicPriceUI;
    [SerializeField] private TextMeshProUGUI clicDamagePriceUI;
    [SerializeField] private TextMeshProUGUI BombDamagePriceUI;
    [SerializeField] private Color negativeColor;
    private Player player;

    private void Start()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        clicsUI.text = player.GetClics().ToString();
        goldUI.text = player.GetGold().ToString();
        clicPriceUI.text = player.GetClicPrice().ToString();
        clicDamagePriceUI.text = player.GetClicDamagePrice().ToString();
        BombDamagePriceUI.text = player.GetBombDamagePrice().ToString();
        CheckPrices();
    }

    private void CheckPrices()
    {
        if (player.GetGold() < player.GetClicPrice())
        {
            clicPriceUI.color = negativeColor;
        }
        else
        {
            clicPriceUI.color = Color.white;
        }

        if (player.GetGold() < player.GetClicDamagePrice())
        {
            clicDamagePriceUI.color = negativeColor;
        }
        else
        {
            clicDamagePriceUI.color = Color.white;
        }

        if (player.GetGold() < player.GetBombDamagePrice())
        {
            BombDamagePriceUI.color = negativeColor;
        }
        else
        {
            BombDamagePriceUI.color = Color.white;
        }
    }

    public void RestClic()
    {
        player.RestClics();
        clicsUI.text = player.GetClics().ToString();
    }

    public void AddClics(int clics)
    {
        player.AddClics(clics);
        clicsUI.text = player.GetClics().ToString();
    }

    public void AddGold(int amount)
    {
        player.AddGold(amount);
        goldUI.text = player.GetGold().ToString();
    }

    public void BuyClics()
    {
        player.IncreaseClics();
        clicsUI.text = player.GetClics().ToString();
        goldUI.text = player.GetGold().ToString();
    }

    public void BuyClicDamage()
    {
        player.IncreaseClicDamage();
        clicsUI.text = player.GetClics().ToString();
        goldUI.text = player.GetGold().ToString();
    }

    public void BuyBombDamage()
    {
        player.IncreaseBombDamage();
        clicsUI.text = player.GetClics().ToString();
        goldUI.text = player.GetGold().ToString();
    }

    public void OpenStore()
    {
        if (storeUI.activeInHierarchy) storeUI.SetActive(false);
        else storeUI.SetActive(true);
    }
}

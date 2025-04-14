using DG.Tweening;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private Transform canvas;
    public RectTransform coinTargetUI; // Referencia al contador de monedas en la UI
    public GameObject coinPrefab; // Prefab de la moneda animada
    [SerializeField] private float duration;
    [SerializeField] private float delay;
    [SerializeField] private Ease ease;

    public void CollectCoins(Vector3 startPosition, int amount)
    {

        Vector3 screenPosition = Camera.main.WorldToScreenPoint(startPosition);

        for (int i = 0; i < amount; i++)
        {
            Vector3 offsetPosition = new Vector3(Random.Range(0f, 50f), Random.Range(0f, 50f), 0f) + screenPosition;

            GameObject coin = Instantiate(coinPrefab, offsetPosition, Quaternion.identity);
            coin.transform.SetParent(canvas, true);
            float currentDelay = delay * i;

            coin.transform.DOMove(coinTargetUI.position, duration).SetEase(ease).SetDelay(currentDelay).OnComplete(() =>
            {
                audioManager.PlayCoins();
                Destroy(coin);
            }); ;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    [SerializeField] private GameObject collectCoinSound;
    private void OnTriggerEnter2D(Collider2D coin)
    {
        if (coin.gameObject.CompareTag("Coin"))
        {
            Instantiate(collectCoinSound);
            Destroy(coin.gameObject);
        }
    }
}

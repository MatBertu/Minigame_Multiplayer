using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int collectedCoins;

    private void OnTriggerEnter(Collider other)
    {
        Coin coin = other.GetComponent<Coin>();
        if (coin != null)
        {
            Destroy(coin.gameObject);
            collectedCoins++;
            RefreshCoinText();
        }
    }

    private void RefreshCoinText()
    {
        GetComponentInChildren<TextMeshPro>().text = collectedCoins.ToString();
    }
}

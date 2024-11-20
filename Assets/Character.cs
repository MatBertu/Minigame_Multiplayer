using Fusion;
using System;
using TMPro;
using UnityEngine;

public class Character : NetworkBehaviour
{


    [Networked, OnChangedRender(nameof(CollectedCoinsChanged))]
    public int CollectedCoins { get; set; }

    public void CollectedCoinsChanged()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        Coin coin = other.GetComponent<Coin>();
        if (coin == null) { return; }
        if (GetComponent<NetworkObject>().HasStateAuthority)
        {
            FindObjectOfType<NetworkRunner>().Despawn(coin.GetComponent<NetworkObject>());
            CollectedCoins++;
            RefreshCoinText();

        }
        else
        {
            coin.gameObject.SetActive(false);
        }

    }

    private void RefreshCoinText()
    {
        GetComponentInChildren<TextMeshPro>().text = CollectedCoins.ToString();
    }
}

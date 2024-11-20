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
        RefreshCoinText();
    }

    public override void Spawned()
    {
        base.Spawned();
        CollectedCoinsChanged();
    }

    private void OnTriggerEnter(Collider other)
    {

        Coin coin = other.GetComponent<Coin>();
        if (coin == null) { return; }
        if (coin.GetComponent<NetworkObject>().HasStateAuthority)
        {

            coin.GetComponent<NetworkObject>().Runner.Despawn(coin.GetComponent<NetworkObject>());
            CollectedCoins++;

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

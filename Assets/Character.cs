using Fusion;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Character : NetworkBehaviour
{
    public int collectedCoins;

    private void OnTriggerEnter(Collider other)
    {

        Coin coin = other.GetComponent<Coin>();
        if (GetComponent<NetworkObject>().Runner.IsSharedModeMasterClient)
        {
            if (coin != null)
            {
               
                FindObjectOfType<NetworkRunner>().Despawn(coin.GetComponent<NetworkObject>());
                collectedCoins++;
                RefreshCoinText();
            }
        }
        else
        {
            coin.gameObject.SetActive(false);
        }

    }

    private void RefreshCoinText()
    {
        GetComponentInChildren<TextMeshPro>().text = collectedCoins.ToString();
    }
}

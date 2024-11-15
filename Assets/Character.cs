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

        if (GetComponent<NetworkObject>().Runner.IsSharedModeMasterClient)
        {
            Coin coin = other.GetComponent<Coin>();
            if (coin != null)
            {
               
                FindObjectOfType<NetworkRunner>().Despawn(coin.GetComponent<NetworkObject>());
                collectedCoins++;
                RefreshCoinText();
            }
        }
        else
        {
            gameObject.SetActive(false);
        }

    }

    private void RefreshCoinText()
    {
        GetComponentInChildren<TextMeshPro>().text = collectedCoins.ToString();
    }
}

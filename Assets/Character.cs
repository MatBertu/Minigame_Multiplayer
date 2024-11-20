using Fusion;
using System;
using TMPro;
using UnityEngine;

public class Character : NetworkBehaviour
{

    [Networked]
    public string PlayerName { get; set; }


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
            RPC_AddCoin(); 
            CheckEndGame();
            coin.GetComponent<NetworkObject>().Runner.Despawn(coin.GetComponent<NetworkObject>());


        }
        else
        {
            coin.gameObject.SetActive(false);
        }

    }

    private void CheckEndGame()
    {
        int leftCoins = FindObjectsOfType<Coin>().Length;
        if (leftCoins <= 1) 
        {
            Character winner = this;
            foreach (Character character in FindObjectsOfType<Character>())
            {
                if (character.CollectedCoins > winner.CollectedCoins)
                {
                    winner = character;
                }
            }
            FindObjectOfType<VictoryText>().RPC_ChangeText("Ha vinto " + winner.PlayerName);
        }
    }

    private void RefreshCoinText()
    {
        GetComponentInChildren<TextMeshPro>().text = CollectedCoins.ToString();
    }

    [Rpc(RpcSources.All, RpcTargets.StateAuthority)]
    public void RPC_AddCoin()
    {
        Debug.Log(nameof(RPC_AddCoin) + " WAS CALLED");
        CollectedCoins++;
    }
}

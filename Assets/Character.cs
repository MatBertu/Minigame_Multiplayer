using Fusion;
using TMPro;
using UnityEngine;

public class Character : NetworkBehaviour
{
    public int collectedCoins;

    private void OnTriggerEnter(Collider other)
    {

        Coin coin = other.GetComponent<Coin>();
        if (coin == null) { return; }
        if (GetComponent<NetworkObject>().HasStateAuthority)
        {


            FindObjectOfType<NetworkRunner>().Despawn(coin.GetComponent<NetworkObject>());
            collectedCoins++;
            RefreshCoinText();

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

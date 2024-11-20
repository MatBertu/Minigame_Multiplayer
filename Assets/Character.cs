using Fusion;
using TMPro;
using UnityEngine;

public class Character : NetworkBehaviour
{
    public int collectedCoins;

    private void OnTriggerEnter(Collider other)
    {
        Coin coin = other.GetComponent<Coin>();
        if (coin != null)
        {
            if (coin.GetComponent<NetworkObject>().HasStateAuthority)
            {
                    FindObjectOfType<NetworkRunner>().Despawn(coin.GetComponent<NetworkObject>());
                    collectedCoins++;
                    RefreshCoinText();
            }
            else
            {
                gameObject.SetActive(false);
            }
        }

    }

    private void RefreshCoinText()
    {
        GetComponentInChildren<TextMeshPro>().text = collectedCoins.ToString();
    }
}

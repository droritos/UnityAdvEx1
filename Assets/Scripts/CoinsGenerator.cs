using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "CoinsGenerator", menuName = "Scriptable Objects/Coins/CoinsGenerator")]
public class CoinsGenerator : ScriptableObject
{
    [SerializeField] List<Coin> coins = new List<Coin>();

    public Coin GenerateCoin() //generates a random coin based on the probability that was given by the player
    {
        List<Coin> coinsTemp = new List<Coin>();
        foreach (Coin coin in coins)
        {
            for(int i = 0; coin.info.probability  > i; i++)
            {
                coinsTemp.Add(coin);
            }
        }
        int selected = Random.Range(0, coinsTemp.Count - 1);
        return coinsTemp[selected];
    }

    public Coin GenerateCoin(CoinsInfo.CoinSize size) //generate coin by enum definition
    {
        foreach (Coin coin in coins)
        {
            if(coin.info.coinSize == size)
                return coin;
        }
        Debug.Log("Not found");
        return null;
    }
}

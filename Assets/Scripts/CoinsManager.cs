using UnityEngine;

public class CoinsManager : MonoBehaviour
{
    [SerializeField] Coin[] coins;
    void Start()
    {
        
    }

    private void GetCoinInteracted(Coin[] coins)
    {
        foreach (Coin coin in coins)
        {
            //coin.OnTriggerEnterAction 
        }
    }



}

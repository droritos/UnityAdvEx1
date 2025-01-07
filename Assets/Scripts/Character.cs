using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    public event UnityAction<int> OnCoinCollected;

    [SerializeField] Collider myCollider;

    [SerializeField] int _coinsGathered = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Coin coinColided = other.GetComponent<Coin>();
            if (coinColided != null) // For safty
            {
                //OnCoinCollected?.Invoke(coinColided.CoinValue);
            }
        }
    }
}

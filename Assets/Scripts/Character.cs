using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    public event UnityAction<int> OnCoinCollected;

    [SerializeField] Collider myCollider;

    [SerializeField] int _coinsGathered = 0;
    private void Start()
    {
        Coin.OnTriggerEnterAction += CoinCollided;
    }
    private void CoinCollided(Coin coin)
    {
        coin.SetGFX(false);
        _coinsGathered++;
        OnCoinCollected.Invoke(_coinsGathered);
        print($"Character Collide With {coin.gameObject.name}");
    }
}

using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    public event UnityAction<Coin> OnCoinCollected;
    public UnityEvent<bool> OnBushEnterEvent;
    public event UnityAction<bool> OnBushEnterEventAction;

    [SerializeField] Collider myCollider;
    [SerializeField] int _coinsGathered = 0;
    [SerializeField] ParticleSystem bushEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Coin coinColided = other.GetComponent<Coin>();
            if (coinColided != null) // For safty
            {
                OnCoinCollected?.Invoke(coinColided);
            }
        }
        if (other.CompareTag("Bush"))
        {
            Bush bushColided = other.GetComponent<Bush>();
            OnBushEnterEvent.Invoke(true);
            //OnBushEnterEventAction.Invoke(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bush"))
        {
            Bush bushColided = other.GetComponent<Bush>();
            OnBushEnterEvent.Invoke(false);
        }
    }
}

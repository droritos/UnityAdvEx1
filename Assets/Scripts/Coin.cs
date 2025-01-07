using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    //public event UnityAction<Coin> OnTriggerEnterAction; // Bonus transfer this.class parameter
    public UnityEvent OnTriggerEnterEvent;

    [SerializeField] GameObject coinGFX;

    public int CoinValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SetGFX(false);
            OnTriggerEnterEvent?.Invoke();
        }
    }

    public void SetGFX(bool state)
    {
        coinGFX.SetActive(state);
    }
}

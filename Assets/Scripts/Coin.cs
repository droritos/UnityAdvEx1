using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    public  UnityEvent OnTriggerEnterEvent;
    public static event UnityAction<Coin> OnTriggerEnterAction; // Bonus transfer this.class parameter

    [SerializeField] GameObject coinGFX;

    private void OnTriggerEnter(Collider other)
    {
        //print($"Enter {other.gameObject.name}");
        OnTriggerEnterAction?.Invoke(this);
        OnTriggerEnterEvent.Invoke();
    }

    public void SetGFX(bool state)
    {
        coinGFX.SetActive(state);
    }
}

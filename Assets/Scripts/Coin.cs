using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{

    //public event UnityAction<Coin> OnTriggerEnterAction; // Bonus transfer this.class parameter
    public UnityEvent OnTriggerEnterEvent;

    [SerializeField] public CoinsInfo info; //The value of the coin is here, Second scriptable object to link the values of the coins
    [SerializeField] private GameObject coinGFX;

    private void Start()
    {
        transform.localScale = new Vector3(1, info.sizeMultiplier, info.sizeMultiplier); //Make them largerrr
    }
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

    public int GetValue()
    {
        return info.coinValue;
    }
}

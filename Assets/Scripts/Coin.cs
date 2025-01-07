using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    private UnityEvent<int> OnTriggerEnterEvent;
    public event UnityAction<int> IncreseSpeedActionEvent;
    public int CoinValue = 1;

    private int _speed = 1;

    [SerializeField] GameObject coinGFX;

    private void Start()
    {
        //OnTriggerEnterEvent?.AddListener(IncreseSpeedActionEvent);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SetGFX(false);
            OnTriggerEnterEvent?.Invoke(_speed);
        }
    }

    public void SetGFX(bool state)
    {
        coinGFX.SetActive(state);
    }
}

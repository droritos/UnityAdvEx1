using Unity.Multiplayer.Center.Common;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    public event UnityAction<InformationSend> OnCoinCollected;
    public UnityEvent<SurfaceType> OnEventSurfaceEnterEvent;
    public UnityEvent OnEventSurfaceExitEvent;

    [SerializeField] Collider myCollider;
    [SerializeField] ParticleSystem particalEffect;

    private int _coinsCounter = 0;

    private void OnTriggerEnter(Collider other)
    {
        string otherTag = other.tag;
        if (other.CompareTag("Coin"))
        {
            Coin coinColided = other.GetComponent<Coin>();
            if (coinColided != null) // For safty
            {
                _coinsCounter++;
                InformationSend send = new InformationSend(coinColided,_coinsCounter);
                OnCoinCollected?.Invoke(send);
            }
        }
        else if (other.CompareTag("Surfaces"))
        {
            SurfaceType surfaceType = other.GetComponent<SurfaceType>();
            SetEffectColor(surfaceType.ColorEffect);
            //SetEffect(surfaceType.effect);
            OnEventSurfaceEnterEvent.Invoke(surfaceType);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Surfaces"))
        {
            OnEventSurfaceExitEvent.Invoke();
        }
    }

    private void SetEffectColor(Color color)
    {
        var mainModule = particalEffect.main; // Access the Main Module
        mainModule.startColor = color; // Set the start color    }
    }

    public struct InformationSend 
    {
        public Coin Coin;
        public int CollectedAmount;

        public InformationSend(Coin coin, int counter)
        {
            this.Coin = coin;
            this.CollectedAmount = counter;
        }
    };
}


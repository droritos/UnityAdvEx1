using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Character elfCharacter;
    [SerializeField] TextMeshProUGUI coinCollectedText;
    [SerializeField] GameObject bushOverlay;

    private int coins = 0;
    void Start()
    {
        coinCollectedText.SetText("0");
        //UpdateCoinBalance(coins); // First, initialize the coin balance
        elfCharacter.OnCoinCollected += UpdateCoinBalance;
        elfCharacter.OnBushEnterEvent.AddListener(BushFog);
    }

    private void UpdateCoinBalance(Coin coin)
    {
        coins += coin.CoinValue;
        coinCollectedText.SetText(coins.ToString());
    }

    private void BushFog(bool state)
    {
        bushOverlay.gameObject.SetActive(state);
    }
}

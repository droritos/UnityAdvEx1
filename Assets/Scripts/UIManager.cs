using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Character elfCharacter;
    [SerializeField] TextMeshProUGUI coinCollectedText;

    private int coins = 0;
    void Start()
    {
        coinCollectedText.SetText("0");
        //UpdateCoinBalance(coins); // First, initialize the coin balance
        elfCharacter.OnCoinCollected += UpdateCoinBalance;
    }

    private void UpdateCoinBalance(int coinValue)
    {
        coins += coinValue;
        coinCollectedText.SetText(coins.ToString());
    }
}

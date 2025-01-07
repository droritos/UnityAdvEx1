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
        UpdateCoinBalance(coins); // First, initialize the coin balance
        elfCharacter.OnCoinCollected += UpdateCoinBalance;
    }

    private void UpdateCoinBalance(int totalCoins)
    {
        coins = totalCoins;
        coinCollectedText.text = coins.ToString();
    }
}

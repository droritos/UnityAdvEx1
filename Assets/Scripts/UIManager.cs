using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Character elfCharacter;
    [SerializeField] AgentMovement elfMovement;
    [SerializeField] TextMeshProUGUI coinCollectedText;
    [SerializeField] TextMeshProUGUI destinationText;

    private int coins = 0;
    void Start()
    {
        elfMovement.OnAgentReachDestinationActionEvent += ShowDestenationText;
        //coinCollectedText.SetText("0");
        //UpdateCoinBalance(coins); // First, initialize the coin balance
        elfCharacter.OnCoinCollected += UpdateCoinBalance;
        elfCharacter.OnBushEnterEvent.AddListener(BushFog);
        //elfCharacter.OnCoinCollected += UpdateCoinBalance;
    }

    private void UpdateCoinBalance(Coin coin)
    {
        coins += coin.CoinValue;
        coinCollectedText.SetText(coins.ToString());
    }

    private void BushFog(bool state)
    {
        bushOverlay.gameObject.SetActive(state);
    private void ShowDestenationText()
    {
        if (destinationText != null)
        {
            destinationText.enabled = true;
            Debug.Log("yes");
        }
    }
}

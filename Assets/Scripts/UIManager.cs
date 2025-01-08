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
        //elfCharacter.OnCoinCollected += UpdateCoinBalance;
    }

    private void UpdateCoinBalance(int coinValue)
    {
        coins += coinValue;
        coinCollectedText.SetText(coins.ToString());
    }

    private void ShowDestenationText()
    {
        if (destinationText != null)
        {
            destinationText.enabled = true;
            Debug.Log("yes");
        }
    }
}

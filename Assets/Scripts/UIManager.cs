using TMPro;
using UnityEngine;
using UnityEngine.Events;
using static Character;
using System.Collections;


public class UIManager : MonoBehaviour
{
    public event UnityAction<float , AgentMovement> DecreaseSpeed; //Sends the UImanager the agent that needs speed reduction and the amount based on the surface

    [Header("References")]
    [SerializeField] GameObject bushOverlay;
    [SerializeField] BoxCollider finishCollider;

    [Header("Main Player")]
    [SerializeField] Character elfCharacter;
    [SerializeField] AgentMovement elfMovement;

    [Header("Texts")]
    [SerializeField] TextMeshProUGUI finishObjectText;
    [SerializeField] TextMeshProUGUI finishCollectedText;
    [SerializeField] TextMeshProUGUI coinCollectedText;
    [SerializeField] TextMeshProUGUI destinationText;

    [SerializeField] float delayTime = 1.5f;

    private int coins;
    void Start()
    {
        coinCollectedText.SetText("0");
        elfMovement.OnAgentReachDestinationActionEvent += ShowDestenationText;
        elfCharacter.OnCoinCollected += UpdateCoinBalance;
        elfCharacter.OnEventSurfaceEnterEvent.AddListener(HandleFogEnter);
        elfCharacter.OnEventSurfaceExitEvent.AddListener(HandleFogExit);
    }

    public void SetCollectedText(bool state) //When you collect all the coins, spawn the finish text and trigger
    {
        finishObjectText.gameObject.SetActive(state);
        finishCollider.enabled = state;
        StartCoroutine(ClearTextAfterDelay());
    }

    private void UpdateCoinBalance(InformationSend sent) //Updates the coin balance based on the coinValue it got from the struct
    {
        coins += sent.Coin.info.coinValue;
        coinCollectedText.SetText(coins.ToString());
    }

    private void HandleFogEnter(SurfaceType surface) //Based on the surface, add a color to the partical effect. Bush gets an overlay as well.
    {
        if (surface.MyType == SurfaceKind.Bush)
        {
            bushOverlay.gameObject.SetActive(true);
        }
        DecreaseSpeed.Invoke(surface.SpeedModifier, elfMovement);
    }
    private void HandleFogExit() //Reset the player's speed to the original, remove the overlays and the partical effect
    {
        bushOverlay.gameObject.SetActive(false);
        DecreaseSpeed.Invoke(1, elfMovement);
    }


    private void ShowDestenationText() //Enables the final text
    {
        if (destinationText != null)
        {
            destinationText.enabled = true;
        }
    }

     private IEnumerator ClearTextAfterDelay() 
    {
        finishCollectedText.enabled = true;
        yield return new WaitForSeconds(delayTime); // Wait for the specified time
        finishCollectedText.enabled = false;
    }

    
}

using TMPro;
using UnityEngine;
using UnityEngine.Events;
using static Character;
using System.Collections;


public class UIManager : MonoBehaviour
{
    public event UnityAction<float , AgentMovement> DecreaseSpeed;

    [Header("References")]
    [SerializeField] GameObject bushOverlay;
    [SerializeField] GameObject finishObject;
    [SerializeField] BoxCollider finishCollider;

    [Header("Main Player")]
    [SerializeField] Character elfCharacter;
    [SerializeField] AgentMovement elfMovement;

    [Header("Texts")]
    [SerializeField] TextMeshProUGUI finishObjectText;
    [SerializeField] TextMeshProUGUI finishCollectedText;
    [SerializeField] TextMeshProUGUI coinCollectedText;

    [SerializeField] float delayTime = 1.5f;

    private int coins = 0;
    void Start()
    {
        elfMovement.OnAgentReachDestinationActionEvent += ShowDestenationText;
        coinCollectedText.SetText("0");
        elfCharacter.OnCoinCollected += UpdateCoinBalance;
        elfCharacter.OnEventSurfaceEnterEvent.AddListener(HandleFogEnter);
        elfCharacter.OnEventSurfaceExitEvent.AddListener(HandleFogExit);
    }
    public void QuitGameButton()
    {
        Application.Quit();
        Debug.Log("Exitign Game");
    }
    public void SetCollectedText(bool state)
    {
        finishObjectText.gameObject.SetActive(state);
        finishCollider.enabled = state;
        StartCoroutine(ClearTextAfterDelay());
    }

    private void UpdateCoinBalance(InformationSend sent)
    {
        coins += sent.Coin.info.coinValue;
        coinCollectedText.SetText(coins.ToString());
    }

    private void HandleFogEnter(SurfaceType surface)
    {
        if (surface.MyType == SurfaceKind.Bush)
        {
            bushOverlay.gameObject.SetActive(true);
        }
        DecreaseSpeed.Invoke(surface.SpeedModifier, elfMovement);
    }
    private void HandleFogExit()
    {
        bushOverlay.gameObject.SetActive(false);
        DecreaseSpeed.Invoke(1, elfMovement);
    }


    private void ShowDestenationText()
    {
        if (finishObject != null)
        {
            finishObject.SetActive(true);
        }
    }

     private IEnumerator ClearTextAfterDelay()
    {
        finishCollectedText.enabled = true;
        yield return new WaitForSeconds(delayTime); // Wait for the specified time
        finishCollectedText.enabled = false;
    }

    
}

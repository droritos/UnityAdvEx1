using UnityEngine;

[CreateAssetMenu(fileName = "CoinsInfo", menuName = "Scriptable Objects/Coins/CoinsInfo")]
public class CoinsInfo : ScriptableObject
{
    [Range(1,100)] public float probability;
    public enum CoinSize
    {
        Small,
        Medium,
        Large
    }

    public CoinSize coinSize;
    public int coinValue = 1;
    public float sizeMultiplier = 1;
    
}

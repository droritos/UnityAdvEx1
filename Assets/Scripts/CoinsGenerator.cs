using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CoinsGenerator", menuName = "Scriptable Objects/CoinsGenerator")]
public class CoinsGenerator : ScriptableObject
{
    [SerializeField] GameObject coin;
    [SerializeField] List<CoinsInfo> coins = new List<CoinsInfo>();

    public GameObject GenerateCoin()
    {
        int selected = Random.Range(0, coins.Count);
        return coin;
    }
}

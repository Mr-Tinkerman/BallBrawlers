using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
    public Coin coin;
    public SaveManager sm;

    void Awake()
    {
        sm = GameObject.FindObjectOfType<SaveManager>();
    }

    void OnTriggerEnter()
    {
        sm.AddCoins(coin.Value());
        sm.Save();

        Destroy(this.gameObject);
    }
}

[System.Serializable]
public class Coin
{
    public CoinType coinType;

    static int[] CoinValue = { 1, 10 };
    
    public int Value()
    {
        return CoinValue[((int)coinType)];
    }
}

[System.Serializable]
public enum CoinType
{
    Coin = 0,
    Pouch = 1
}
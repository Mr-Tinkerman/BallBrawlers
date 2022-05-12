using UnityEngine;

public class CoinItem : MonoBehaviour
{
    [SerializeField]
    private int coinValue = 1;

    void OnTriggerEnter()
    {
        SaveManager.Instance.AddCoins(coinValue);
        SaveManager.Instance.Save();

        Destroy(this.gameObject);
    }
}
using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
    public int coinValue = 1;
    public SaveManager sm;

    void Awake() 
    {
        sm = GameObject.FindObjectOfType<SaveManager>();
    }

    void OnTriggerEnter()
    {
        sm.AddCoins(coinValue);
        sm.Save();

        Destroy(this.gameObject);
    }
}
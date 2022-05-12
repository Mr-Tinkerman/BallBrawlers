using UnityEngine;

public class SpikeHazard : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        // Destroy(col.gameObject);
        GameStateManager.Instance.GameOver();
    }
}

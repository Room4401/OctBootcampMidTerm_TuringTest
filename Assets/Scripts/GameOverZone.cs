using UnityEngine;
using UnityEngine.Events;

public class GameOverZone : MonoBehaviour
{
    public UnityEvent OnEnterZone;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.GetInstance().Changestate(GameManager.GameState.GameOver);
            OnEnterZone?.Invoke();
        }
    }
}
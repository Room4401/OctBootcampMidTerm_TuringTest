using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private bool isFinalLevel = false;
    public UnityEvent onLevelStart, onLevelEnd;

    public void StartLevel()
    {
        onLevelStart?.Invoke();
    }

    public void EndLevel()
    {
        onLevelEnd?.Invoke();
        if (isFinalLevel)
            GameManager.GetInstance().Changestate(GameManager.GameState.GameEnd);
        else
            GameManager.GetInstance().Changestate(GameManager.GameState.LevelEnd);
    }
}
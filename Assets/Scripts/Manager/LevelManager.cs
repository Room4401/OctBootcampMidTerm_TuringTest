using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    public UnityEvent onLevelStart, onLevelEnd;

    public void StartLevel()
    {
        onLevelStart?.Invoke();
    }

    public void EndLevel()
    {
        onLevelEnd?.Invoke();
    }
}
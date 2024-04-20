using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PathPuzzle : MonoBehaviour
{
    public UnityEvent OnSolved;
    public UnityEvent OnFailed;

    private Dictionary<int, bool> pathPads = new Dictionary<int, bool>();

    private void Start()
    {
        foreach (PathPad pad in GetComponentsInChildren<PathPad>())
        {
            pathPads.Add(pad.GetInstanceID(), pad.isToggled);
            pad.OnTriggered += UpdatePuzzleState;
        }
    }

    private void UpdatePuzzleState(PathPad pad)
    {
        if (!pathPads[pad.GetInstanceID()])
        {
            pathPads[pad.GetInstanceID()] = pad.isToggled;
            CheckForSolve();
        }
        else
        {
            GameManager.GetInstance().Changestate(GameManager.GameState.GameOver);
            OnFailed?.Invoke();
            return;
        }
    }

    private void CheckForSolve()
    {
        foreach (var pad in pathPads)
        {
            if (!pad.Value)
            {
                return;
            }
        }
        OnSolved?.Invoke();
    }
}
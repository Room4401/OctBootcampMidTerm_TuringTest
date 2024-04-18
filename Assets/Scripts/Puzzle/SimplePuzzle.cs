using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimplePuzzle : MonoBehaviour
{
    public UnityEvent OnSolved;
    public UnityEvent OnUnsolved;

    private Dictionary<int, bool> pressurePads = new Dictionary<int, bool>();

    private void Start()
    {
        foreach (PressurePad pad in GetComponentsInChildren<PressurePad>())
            pressurePads.Add(pad.GetInstanceID(), pad.isToggled);
    }

    public void UpdatePuzzleState(PressurePad pad)
    {
        pressurePads[pad.GetInstanceID()] = pad.isToggled;
        CheckForSolve();
    }

    private void CheckForSolve()
    {
        foreach (var pad in pressurePads)
        {
            if (!pad.Value)
            {
                OnUnsolved?.Invoke();
                return;
            }
        }
        OnSolved?.Invoke();
    }
}
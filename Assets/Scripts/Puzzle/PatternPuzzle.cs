using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PatternPuzzle : MonoBehaviour
{
    public UnityEvent OnSolved;
    public UnityEvent OnUnsolved;

    public bool isSolved {  get; private set; }

    private Dictionary<int, bool> pressurePads = new Dictionary<int, bool>();

    private void Start()
    {
        foreach (PressurePad pad in GetComponentsInChildren<PressurePad>())
        {
            if (pad.gameObject.CompareTag("CorrectAnswer"))
                pressurePads.Add(pad.GetInstanceID(), pad.isToggled);
        }
    }

    public void UpdatePuzzleState(PressurePad pad)
    {
        if (pressurePads.TryGetValue(pad.GetInstanceID(), out _))
        {
            pressurePads[pad.GetInstanceID()] = pad.isToggled;
            CheckForSolve();
        }
    }

    private void CheckForSolve()
    {
        foreach (var pad in pressurePads)
        {
            if (!pad.Value)
            {
                isSolved = false;
                OnUnsolved?.Invoke();
                return;
            }
        }
        isSolved = true;
        OnSolved?.Invoke();
    }
}
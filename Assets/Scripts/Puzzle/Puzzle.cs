using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Puzzle : MonoBehaviour
{
    public UnityEvent OnSolved, OnUnsolved;
    public bool isSolved { get; private set; }

    protected Dictionary<int, bool> pads = new Dictionary<int, bool>();

    private void Start()
    {
        foreach (Pad pad in GetComponentsInChildren<Pad>())
            AddPad(pad);
    }

    protected virtual void AddPad(Pad pad)
    {
        pads.Add(pad.GetInstanceID(), pad.isToggled);
        pad.OnToggled.AddListener(UpdatePuzzleState);
    }

    protected virtual void UpdatePuzzleState(Pad pad)
    {
        pads[pad.GetInstanceID()] = pad.isToggled;
        CheckForSolve();
    }

    protected virtual void CheckForSolve()
    {
        foreach (var pad in pads)
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
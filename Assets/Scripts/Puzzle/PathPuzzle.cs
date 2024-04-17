using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PathPuzzle : MonoBehaviour
{
    public UnityEvent OnSolved;
    public UnityEvent OnUnsolved;
    public bool puzzleSolved { get; private set; }

    private List<PathPad> togglePads = new List<PathPad>();

    private void Start()
    {
        puzzleSolved = false;
        foreach (PathPad pad in GetComponentsInChildren<PathPad>())
            togglePads.Add(pad);
    }

    public void UpdatePuzzleState()
    {
        int count = 0;
        foreach (PathPad pad in togglePads)
        {
            if (pad.GetComponent<PathPad>().isToggled)
                count++;
        }
        if (count < togglePads.Count)
        {
            puzzleSolved = false;
            OnUnsolved?.Invoke();
        }
        else if (count == togglePads.Count)
        {
            puzzleSolved = true;
            OnSolved?.Invoke();
        }
    }
}
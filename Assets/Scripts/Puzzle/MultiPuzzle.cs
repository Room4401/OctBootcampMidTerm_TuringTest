using UnityEngine;
using UnityEngine.Events;

public class MultiPuzzle : MonoBehaviour
{
    [SerializeField] private PatternPuzzle[] puzzles;

    public UnityEvent OnAllSolved, OnUnsolved;

    public void CheckForSolve()
    {
        Debug.Log("Start check for solve");
        foreach (PatternPuzzle _puzzle in puzzles)
        {
            if (!_puzzle.isSolved)
            {
                Debug.Log("checking:" + _puzzle.GetInstanceID() + _puzzle.isSolved);
                OnUnsolved?.Invoke();
                return;
            }
        }
        Debug.Log("All puzzle checked");
        OnAllSolved?.Invoke();
    }
}
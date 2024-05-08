using UnityEngine;
using UnityEngine.Events;

public class MultiPuzzle : MonoBehaviour
{
    [SerializeField] private Puzzle[] puzzles;

    public UnityEvent OnAllSolved, OnUnsolved;

    private void Start()
    {
        puzzles = GetComponentsInChildren<Puzzle>();
        foreach (Puzzle _puzzle in puzzles)
        {
            _puzzle.OnSolved.AddListener(CheckForSolve);
            _puzzle.OnUnsolved.AddListener(CheckForSolve);
        }
    }

    public void CheckForSolve()
    {
        foreach (Puzzle _puzzle in puzzles)
        {
            if (!_puzzle.isSolved)
            {
                OnUnsolved?.Invoke();
                return;
            }
        }
        OnAllSolved?.Invoke();
    }
}
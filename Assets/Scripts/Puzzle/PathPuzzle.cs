using UnityEngine.Events;

public class PathPuzzle : Puzzle
{
    public UnityEvent OnFailed;

    protected override void UpdatePuzzleState(Pad pad)
    {
        if (pads[pad.GetInstanceID()])
        {
            GameManager.GetInstance().Changestate(GameManager.GameState.GameOver);
            OnFailed?.Invoke();
            return;
        }
        else
        {
            base.UpdatePuzzleState(pad);
        }
    }
}
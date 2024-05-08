public class PatternPuzzle : Puzzle
{
    protected override void AddPad(Pad pad)
    {
        pad.OnToggled.AddListener(UpdatePuzzleState);
        if (pad.gameObject.CompareTag("CorrectAnswer"))
            pads.Add(pad.GetInstanceID(), pad.isToggled);
    }

    protected override void UpdatePuzzleState(Pad pad)
    {
        if (pads.TryGetValue(pad.GetInstanceID(), out _))
            base.UpdatePuzzleState(pad);
    }
}
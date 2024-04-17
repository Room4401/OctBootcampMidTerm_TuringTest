using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoorIndicator : MonoBehaviour
{
    [SerializeField] private Door door;
    [SerializeField] private TMP_Text indicatorTxt;
    [SerializeField] private Color unlockedColor;

    private Color lockedColor;

    private void Start()
    {
        lockedColor = indicatorTxt.color;
        ChangeState();
    }

    public void ChangeState()
    {
        indicatorTxt.text = door.isLocked ? "Locked" : "Unlocked";
        indicatorTxt.color = door.isLocked ? lockedColor : unlockedColor;
    }
}
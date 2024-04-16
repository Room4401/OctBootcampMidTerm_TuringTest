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
    private bool isLocked;

    private void Start()
    {
        lockedColor = indicatorTxt.color;
        isLocked = door.isLocked;
    }

    private void Update()
    {
        ChangeState();
    }

    public void ChangeState()
    {
        isLocked = door.isLocked;
        indicatorTxt.text = isLocked ? "Locked" : "Unlocked";
        indicatorTxt.color = isLocked ? lockedColor : unlockedColor;
    }
}
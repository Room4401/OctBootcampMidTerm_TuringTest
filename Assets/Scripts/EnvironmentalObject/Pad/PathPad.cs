using UnityEngine;

public class PathPad : Pad
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!isToggled)
            {
                TogglePad(true);
            }
            OnToggled?.Invoke(this);
        }
    }
}
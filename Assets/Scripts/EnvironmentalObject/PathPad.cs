using System;
using UnityEngine;

public class PathPad : MonoBehaviour
{
    [SerializeField] private Color toggledColor;

    public Action<PathPad> OnTriggered;
    public bool isToggled { get; private set; }

    private Renderer padRenderer;

    private void Awake()
    {
        isToggled = false;
        padRenderer = GetComponentInChildren<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!isToggled)
            {
                isToggled = true;
                padRenderer.material.color = toggledColor;
            }
            OnTriggered(this);
        }
    }
}
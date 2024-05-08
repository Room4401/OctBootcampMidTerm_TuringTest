using UnityEngine;
using UnityEngine.Events;

public class Pad : MonoBehaviour
{
    [SerializeField] private Color toggledColor;
    [HideInInspector] public UnityEvent<Pad> OnToggled;

    public bool isToggled { get; private set; }

    private Renderer padRenderer;
    private Color defaultColor;

    private void Awake()
    {
        isToggled = false;
        padRenderer = GetComponentInChildren<Renderer>();
        defaultColor = padRenderer.material.color;
    }

    public void TogglePad(bool _isToggled)
    {
        isToggled = _isToggled;
        padRenderer.material.color =
            _isToggled ? toggledColor : defaultColor;
    }
}
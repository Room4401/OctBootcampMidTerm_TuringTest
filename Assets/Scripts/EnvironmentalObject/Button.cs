using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour, ISelectable
{
    [SerializeField] private Renderer buttonRenderer;
    [SerializeField] private Color hoverColor;

    private Color defaultColor;
    public UnityEvent OnPushButton;

    void Start()
    {
        if(buttonRenderer != null)
        {
            defaultColor = buttonRenderer.material.color;
        }
    }

    public void OnHoverEnter()
    {
        buttonRenderer.material.color = hoverColor;
    }

    public void OnHoverExit()
    {
        buttonRenderer.material.color = defaultColor;
    }

    public void OnSelect()
    {
        OnPushButton?.Invoke();
    }
}
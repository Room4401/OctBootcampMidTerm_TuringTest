using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PressurePad : MonoBehaviour
{
    [SerializeField] private LayerMask pickUpLayer;
    [SerializeField] private Color toggledColor;
    [SerializeField] private float checkRange;

    public UnityEvent OnPlaced, OnRemoved;
    public bool isToggled { get; private set; }

    private Color defaultColor;
    private Renderer padRenderer;

    private void Start()
    {
        isToggled = false;
        padRenderer = GetComponentInChildren<Renderer>();
        defaultColor = padRenderer.material.color;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 checkBox = GetComponent<Collider>().bounds.extents / 2;
        checkBox.y *= 3;

        Collider[] colliders = Physics.OverlapBox(transform.position, checkBox, Quaternion.identity, pickUpLayer);

        foreach (Collider collider in colliders)
        {
            if (collision.gameObject.CompareTag("Pickable"))
            {
                isToggled = true;
                padRenderer.material.color = toggledColor;
                OnPlaced?.Invoke();
                break;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pickable"))
        {
            isToggled = false;
            padRenderer.material.color = defaultColor;
            OnRemoved?.Invoke();
        }
    }
}
using UnityEngine;
using UnityEngine.Events;

public class PathPad : MonoBehaviour
{
    [SerializeField] private Material toggledMaterial;

    public UnityEvent OnStepped;
    public UnityEvent OnRepeatedStep;
    public bool isToggled { get; private set; }

    private Renderer padRenderer;

    private void Start()
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
                Debug.Log("Steped");
                isToggled = true;
                padRenderer.material = toggledMaterial;
                OnStepped?.Invoke();
            }
            else
            {
                OnRepeatedStep?.Invoke();
            }
        }
    }
}
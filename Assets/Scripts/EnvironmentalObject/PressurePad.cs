using UnityEngine;
using UnityEngine.Events;

public class PressurePad : MonoBehaviour
{
    [SerializeField] private LayerMask pickUpLayer;
    [SerializeField] private Material toggledMaterial;
    [SerializeField] private float checkRange;

    public UnityEvent OnPlaced;
    public UnityEvent OnRemoved;
    public bool isToggled { get; private set; }

    private Material defaultMaterial;
    private Renderer padRenderer;

    private void Start()
    {
        padRenderer = GetComponentInChildren<Renderer>();
        defaultMaterial = padRenderer.material;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, checkRange, pickUpLayer);

        Debug.Log(colliders.Length);

        foreach (Collider collider in colliders)
        {
            Debug.Log(collider.gameObject.name);

            if (collision.gameObject.CompareTag("Pickable"))
            {
                Debug.Log("Placed");
                isToggled = true;
                padRenderer.material = toggledMaterial;
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
            padRenderer.material = defaultMaterial;
            OnRemoved?.Invoke();
        }
    }
}
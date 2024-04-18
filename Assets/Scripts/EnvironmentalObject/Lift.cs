using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class Lift : MonoBehaviour
{
    [SerializeField] private float moveDistance, moveSpeed;
    [SerializeField] private bool isUp;

    private bool isMoving;
    private Vector3 targetPostion;

    public void ToggleLift()
    {
        if (isMoving) { return; }
        if (isUp)
        {
            targetPostion = transform.localPosition - new Vector3(0, moveDistance, 0);
            isUp = false;
        }
        else
        {
            targetPostion = transform.localPosition + new Vector3(0, moveDistance, 0);
            isUp = true;
        }
        isMoving = true;
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition,
                targetPostion, moveSpeed * Time.deltaTime);
        }

        if (Vector3.Distance(transform.localPosition, targetPostion) < 0.02f)
        {
            isMoving = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            other.transform.SetParent(transform);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            other.transform.SetParent(null);
    }
}
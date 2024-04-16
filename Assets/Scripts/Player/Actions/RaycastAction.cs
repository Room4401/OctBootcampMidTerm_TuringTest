using System;
using UnityEngine;

[Serializable]
public class RaycastAction
{
    [Header("Action Settings")]
    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask actionLayer;
    [SerializeField] private float actionDistance;
    [HideInInspector] public RaycastHit hit;

    public bool RayActionCheck()
    {
        //Cast a ray from middle of camera
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        return Physics.Raycast(ray, out hit, actionDistance, actionLayer);
    }
}
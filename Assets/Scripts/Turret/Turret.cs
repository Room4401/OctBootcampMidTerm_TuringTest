using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Turret : MonoBehaviour
{
    public Transform turretEye;
    public LayerMask layer;
    public float attackDistance;

    [HideInInspector] public RaycastHit hit;

    private LineRenderer AimLine;
    private TurretState currentState;
    void Start()
    {
        currentState = new TurretIdleState(this);
        currentState.OnStateEnter();
        AimLine = GetComponentInChildren<LineRenderer>();
        AimLine.SetPosition(0, turretEye.localPosition);
        SetAimLineEnd(attackDistance);
    }
    void Update()
    {
        currentState.OnStateUpdate();
    }

    public void ChangeState(TurretState _state)
    {
        currentState.OnStateExit();
        currentState = _state;
        currentState.OnStateEnter();
    }

    public bool RaycastCheck()
    {
        return Physics.Raycast(turretEye.position,
                    turretEye.TransformDirection(Vector3.forward),
                    out hit, attackDistance, layer);
    }
    public void SetAimLineEnd(float _distance)
    {
        AimLine.SetPosition(1, turretEye.localPosition
            + Vector3.forward * _distance);
    }
}
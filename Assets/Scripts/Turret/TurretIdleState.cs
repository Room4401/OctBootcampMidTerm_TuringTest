using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class TurretIdleState : TurretState
{
    public TurretIdleState(Turret _turret) : base(_turret)
    {
    }

    public override void OnStateEnter()
    {
        Debug.Log("Enter idle state");
    }

    public override void OnStateExit()
    {
        Debug.Log("Exit idle state");
    }

    public override void OnStateUpdate()
    {
        if (!turret.RaycastCheck() && turret != null)
        {
            turret.SetAimLineEnd(turret.attackDistance);
            return;
        }
        if (turret.RaycastCheck())
        {
            if (turret.hit.transform.CompareTag("Player"))
                turret.ChangeState(new TurretAttackState(turret));
            turret.SetAimLineEnd(turret.hit.distance);

            Debug.DrawRay(turret.turretEye.position,
                turret.turretEye.TransformDirection(Vector3.forward)
                * turret.hit.distance);
        }
    }
}
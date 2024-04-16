using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class TurretAttackState : TurretState
{
    public TurretAttackState(Turret _turret) : base(_turret)
    {
    }

    public override void OnStateEnter()
    {
        Debug.Log("Enter attack state");
    }

    public override void OnStateExit()
    {
        turret.SetAimLineEnd(turret.attackDistance);
    }

    public override void OnStateUpdate()
    {
        if (!turret.RaycastCheck())
            turret.ChangeState(new TurretIdleState(turret));
        if (turret.RaycastCheck())
        {
            if (turret.hit.transform.CompareTag("Player"))
                turret.hit.transform.GetComponent<Health>().DeductHealth(1 * Time.deltaTime);
            turret.SetAimLineEnd(turret.hit.distance);

            Debug.DrawRay(turret.turretEye.position,
                turret.turretEye.TransformDirection(Vector3.forward)
                * turret.hit.distance);
        }
    }
}
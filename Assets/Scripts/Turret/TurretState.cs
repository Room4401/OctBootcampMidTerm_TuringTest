public abstract class TurretState
{
    protected Turret turret;

    public TurretState(Turret _turret)
    {
        turret = _turret;
    }

    public abstract void OnStateEnter();

    public abstract void OnStateExit();

    public abstract void OnStateUpdate();
}
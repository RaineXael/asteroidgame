using UnityEngine;

public class Enemy : Ship
{
    //Enemy Baseclass
    private EnemyState currentState;

    public override void Start()
    {
        base.Start();
        currentState = new EnemyStateIdle();
    }

    public void SwitchState(EnemyState state)
    {
        currentState.OnExit(this);
        currentState = state;
        state.OnEnter(this);
    }

    public override void Update()
    {
        base.Update();
        currentState.OnUpdate(this);
    }

}

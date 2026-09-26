using UnityEngine;

public class Enemy : Ship
{
    private Player target;
    public EnemySightDetector sightDetector;

    //Enemy Baseclass
    private EnemyState currentState;

    public override void Start()
    {
        base.Start();
        currentState = new EnemyStateIdle();
        sightDetector.AddMethodToPlayerEvent(OnFriendlyNearby);
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

    public override void OnTouchDamageable(float amount)
    {
        //Send it to the state. The state determines if the enemy takes damage
        //in case there's a state that needs invulnerability.
        currentState.OnTouchDamageable(this, amount);
    }

    //Callback method for when the detection radius detects a player.
    //Does different things depending on state.
    public void OnFriendlyNearby(Player player)
    {
        target = player;
        currentState.OnFriendlyNearby(this);
    }

}

using UnityEngine;

public class EnemyStateIdle : EnemyState
{
    //Enemy State before they see the player.
    public override void OnEnter(Enemy enemy)
    {
        
    }
    public override void OnExit(Enemy enemy)
    {
        
    }
    public override void OnUpdate(Enemy enemy)
    {
        // Test behaviour. In reality we should either have them sit
        //still, thrust against the gravity of a planet if any are nearby
        //or have them move around a pre-determined radius.
        enemy.ChangeRotation(1.0f);
        
    }
    public override void OnTouchDamageable(Enemy enemy, float amount)
    {
        enemy.TakeDamage(amount);
    }

    public override void OnFriendlyNearby(Enemy enemy)
    {
        Debug.Log("Switch To Aggressivbe");
        enemy.SwitchState(new EnemyStateAggressive());
    }
}


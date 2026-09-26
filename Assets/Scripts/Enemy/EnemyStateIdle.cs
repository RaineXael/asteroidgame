using UnityEngine;

public class EnemyStateIdle : EnemyState
{
    public override void OnEnter(Enemy enemy)
    {
        
    }
    public override void OnExit(Enemy enemy)
    {
        
    }
    public override void OnUpdate(Enemy enemy)
    {
        // Test behaviour
        enemy.ChangeRotation(1.0f);
        // Debug.LogWarning("AAAA!!");
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


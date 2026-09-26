using UnityEngine;

public class EnemyStateAggressive : EnemyState
{
    //Example empty State Machine class (template).
    public override void OnEnter(Enemy enemy)
    {
        Debug.Log("Enemy Switched To Aggressive");
    }
    public override void OnExit(Enemy enemy)
    {
        
    }
    public override void OnUpdate(Enemy enemy)
    {
        enemy.Thrust(1);
    }
    public override void OnTouchDamageable(Enemy enemy, float amount)
    {
        enemy.TakeDamage(amount);
    }

    public override void OnFriendlyNearby(Enemy enemy)
    {
        
    }
}


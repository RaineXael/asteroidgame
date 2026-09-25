using UnityEngine;

public class EnemyStateAggressive : EnemyState
{
    //Example empty State Machine class (template).
    public override void OnEnter(Enemy enemy)
    {
        
    }
    public override void OnExit(Enemy enemy)
    {
        
    }
    public override void OnUpdate(Enemy enemy)
    {
        
    }
    public override void OnTouchDamageable(Enemy enemy, float amount)
    {
        enemy.TakeDamage(amount);
    }


}


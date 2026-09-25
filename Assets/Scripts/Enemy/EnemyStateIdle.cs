using UnityEngine;

public class EnemyStateIdle : EnemyState
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
        enemy.ChangeRotation(1.0f);
        Debug.LogWarning("AAAA!!");
    }
    public override void OnTouchDamageable(Enemy enemy, float amount)
    {
        enemy.TakeDamage(amount);
    }


}


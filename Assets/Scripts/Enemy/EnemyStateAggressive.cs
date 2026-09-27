using UnityEngine;

public class EnemyStateAggressive : EnemyState
{
    //Enemy State after they see the player. Use enemy.target to reference
    //the player for angle calculations.
    public override void OnEnter(Enemy enemy)
    {
        Debug.Log("Enemy Switched To Aggressive");
    }
    public override void OnExit(Enemy enemy)
    {
        
    }
    public override void OnUpdate(Enemy enemy)
    {
        //TO-DO: Use enemy.Thrust and enemy.Rotate functions
        //to orient themselvs toward the player and jet toward them.

        //They should also be able to spawn their own bullets, which could be
        //done similarly to the player. 
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


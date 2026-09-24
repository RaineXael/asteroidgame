using UnityEngine;

public abstract class EnemyState
{
    //Player State Machine template, in case we want to implement
    //it into the Player script (different states per different moves)
    public abstract void OnEnter(Enemy enemy);
    public abstract void OnExit(Enemy enemy);
    public abstract void OnUpdate(Enemy enemy);
    public abstract void OnTakeDamage(Enemy enemy);


}


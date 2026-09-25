using UnityEngine;

public abstract class PlayerState : MonoBehaviour
{
    //Player State Machine template, in case we want to implement
    //it into the Player script (different states per different moves)
    public abstract void OnEnter(Player player);
    public abstract void OnExit(Player player);
    public abstract void OnUpdate(Player player);
    public abstract void OnTakeDamage(Player player);


}


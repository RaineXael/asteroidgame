using UnityEngine;

public abstract class PlayerState : MonoBehaviour
{
    public abstract void OnEnter(Player player);
    public abstract void OnExit(Player player);
    public abstract void OnUpdate(Player player);
    public abstract void OnTakeDamage(Player player);


}


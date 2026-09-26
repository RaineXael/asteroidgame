
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SphereCollider))]
public class EnemySightDetector : MonoBehaviour
{
    //Class attatched to a trigger around the Enemy that keeps track of ships that come in and out of it.
    //Once a friendly ship enters the radius, make the Enemy aggressive and do the same for all the other "ENEMY" aligned ships.

    private UnityEvent<Player> OnPlayerTouch = new UnityEvent<Player>();

    private List<Enemy> enemiesInsideTrigger = new List<Enemy>();

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Ship ship))
        {
            if(ship is Enemy)
            {
                enemiesInsideTrigger.Add((Enemy)ship);
            }
            else if (ship is Player)
            {
                OnPlayerTouch.Invoke((Player)ship);
            }
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Ship ship))
        {
            if(ship is Enemy)
            {
                enemiesInsideTrigger.Remove((Enemy)ship);
            }
           
        }

    }

    public void AddMethodToPlayerEvent(UnityAction<Player> action)
    {
        OnPlayerTouch.AddListener(action);
    }

    public void MakeNearbyEnemiesAggressive()
    {
        foreach (Enemy e in enemiesInsideTrigger)
        {
            
        }
    }
}
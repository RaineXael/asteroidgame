using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public float maxHealth = 100f;
    private float health;
    public float maxEnergy = 100f;
    private float energy;
    //Gravitational pull of the planets. A velocity vector added to
    //the ship after their thrust (after player input in the Player's case)
    protected List<Planet> planetsInside = new List<Planet>(); 
    // protected Vector3 planetGrav;
    public virtual void Start()
    {
        health = maxHealth;
        energy = maxEnergy;
    }


    /// <summary>
    /// Triggered when the ship takes damage.
    /// </summary> 
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            OnDeath();
        }
    }
    /// <summary>
    /// Triggered when the ship takes damage that kills it.
    /// By default, destroys the GameObject.
    /// </summary>
    public void OnDeath()
    {
        Destroy(gameObject);
    }

    public Vector3 GetTotalPlanetGravity()
    {
        Vector3 totalGravity = Vector3.zero;

        foreach(Planet planet in planetsInside)
        {
            Vector3 offset = (planet.transform.position - transform.position).normalized;
            totalGravity += offset * planet.gravForce;
         
        }

        return totalGravity;
    }


    public void AddToPlanetList(Planet planet)
    {
        planetsInside.Add(planet);
    }
    public void RemoveFromPlanetList(Planet planet)
    {
        planetsInside.Remove(planet);
    }

}

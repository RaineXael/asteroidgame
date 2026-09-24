using System.Collections.Generic;
using UnityEngine;

public enum Alignment
{
    ENEMY,
    FRIENDLY
}

[RequireComponent(typeof(Rigidbody))]
public class Ship : MonoBehaviour
{
    [Header("Ship Baseclass Variables")]
    public Alignment alignment;
    public float maxHealth = 100f;
    private float health;
    public float maxEnergy = 100f;
    private float energy;
    //List of the planets that are affecting the ship. Used to calculate
    //extra velocities for their gravity.
    protected List<Planet> planetsInside = new List<Planet>(); 
    [SerializeField] protected float rotateSpeed = 10.0f;
    //Acceleration of the forward / backward thrust.
    [SerializeField] protected float thrustAcceleration = 15.0f;
    //The max magnitude the player's velocity can have by input.
    //Additional planet velocity go beyond this limit. 
    public float maxThrustSpeed = 30.0f;
    protected Rigidbody rb;

    public virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
        health = maxHealth;
        energy = maxEnergy;
    }

    public virtual void Update()
    {
        
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

    /// <summary>
    /// Iterates through all the planets in the planetsInside list and
    /// calculates the sum of their gravity as a vector.
    /// </summary>
    /// <returns>The vector for the gravity of all the planets in the planetsInside list. </returns>
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

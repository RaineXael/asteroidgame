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
    [SerializeField] protected float rotateSpeed = 180.0f;
    //Acceleration of the forward / backward thrust.
    [SerializeField] protected float thrustAcceleration = 15.0f;
    [SerializeField] protected Transform modelTransform; //Transform of the mesh that gets rotated to indicate direction
    //The max magnitude the player's velocity can have by input.
    //Additional planet velocity go beyond this limit. 
    public float maxThrustSpeed = 30.0f;
    protected Rigidbody rb;
    //Current Angle the player is facing (in radians)
    protected float currentAngle;

    public virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
        health = maxHealth;
        energy = maxEnergy;
    }

    public virtual void Update()
    {
        //Add any planet gravity to the velocity
        rb.linearVelocity += GetTotalPlanetGravity() * Time.deltaTime;

        if (modelTransform != null)
        {
            //Set model rotation to currentAngle
            modelTransform.eulerAngles = new Vector3(modelTransform.eulerAngles.x, modelTransform.eulerAngles.y, Mathf.Rad2Deg * currentAngle);
        }

    }

    /// <summary>
    /// Triggered when touching a damaging object (bullets, planets at high velocity, etc).
    /// Can be overridden to set custom behaviour on hit.
    /// </summary>
    public virtual void OnTouchDamageable(float amount)
    {
        TakeDamage(amount);
    }

    /// <summary>
    /// Method that gives damage to the ship. Triggers "OnDeath()" when health is less than 0
    /// after subtraction.
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

        foreach (Planet planet in planetsInside)
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

    //Movement Methods
    public void Thrust(float thrustInput)
    {
        //Forward & Backward thrust on Vertical input
        if (thrustInput != 0)
        {
            rb.linearVelocity += new Vector3(Mathf.Cos(currentAngle), Mathf.Sin(currentAngle), 0) * thrustAcceleration * thrustInput * Time.deltaTime;
            rb.linearVelocity = Vector3.ClampMagnitude(rb.linearVelocity, maxThrustSpeed);
        }
    }

    public void ChangeRotation(float rotationInput)
    {
        //Changing the currentAngle based on input (in radians)
        currentAngle -= Mathf.Deg2Rad * rotateSpeed * rotationInput * Time.deltaTime;
    }

}

using UnityEngine;

public class Ship : MonoBehaviour
{
    public float maxHealth = 100f;
    private float health;
    public float maxEnergy = 100f;
    private float energy;
    //Gravitational pull of the planets. A velocity vector added to
    //the ship after their thrust (after player input in the Player's case)
    protected Vector3 planetGrav;
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

    /// <summary>
    /// Sets the planetGrav vector of this object.
    /// We may need to change this if we have multiple planets
    /// interacting with the same ship.
    /// </summary>
    public void SetPlanetGravity(Vector3 gravVelocity)
    {
        planetGrav = gravVelocity;
    }

}

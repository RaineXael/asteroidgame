using UnityEngine;

public class Ship : MonoBehaviour
{
    public float maxHealth = 100f;
    private float health;
    public float maxEnergy = 100f;
    private float energy;

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
}

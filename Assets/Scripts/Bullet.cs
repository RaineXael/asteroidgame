using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Alignment alignment;
    [SerializeField] private float maxLifetime = 5.0f;
    [SerializeField] private float speed = 10.0f;
    private Rigidbody rb;
    private Vector3 directionVector;
    private Vector3 extraVelocity;
    [SerializeField] private float damage = 10.0f;
    void Start()
    {
        Destroy(gameObject,maxLifetime);
        rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Set nessecary parameters, typically ran at bullet spawn.
    /// </summary>
    /// <param name="direction">Normalized direction vector the bullet will move.</param>
    /// <param name="extraVelocity">Velocity vector to add to movement. Usually for
    /// adding the spawner's velocity for accuracy.</param>
    /// <param name="alignment">Alignment of the owner of the bullet.</param>
    public void SetData(Vector3 direction, Vector3 extraVelocity, Alignment alignment)
    {
        directionVector = direction;
        this.extraVelocity = extraVelocity;
        this.alignment = alignment;
    }

    public void Update()
    {
        rb.linearVelocity = (directionVector * speed) + extraVelocity;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Ship ship))
        {
            if (ship.alignment != alignment)
            {
                ship.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}

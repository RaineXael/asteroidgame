using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float maxLifetime = 5.0f;
    public float speed = 10.0f;
    private Rigidbody rb;
    private Vector3 directionVector;
    private Vector3 extraVelocity;
    public float damage = 10.0f;
    void Start()
    {
        Destroy(gameObject,maxLifetime);
        rb = GetComponent<Rigidbody>();
    }
    public void SetData(Vector3 direction, Vector3 extraVelocity)
    {
        directionVector = direction;
        this.extraVelocity = extraVelocity;
    }

    public void Update()
    {
        rb.linearVelocity = (directionVector * speed) + extraVelocity;
    }

    void OnTriggerEnter(Collider other)
    {
        
    }
}

using UnityEngine;

public class Planet : MonoBehaviour
{
    // //ZScale. Set this low so the camera can render the whole planet.
    // public float depth = 3f;
    //Total radius of the planet (the solid part, not the grav. field.)
    public float radius = 2f;
    //Radius (not including planet radius) that the gravitational field will have.
    public float gravFieldRadius = 5f;
    //How much the planet's grav. field acts upon ships.
    public float gravForce;
    //Sphere model to scale up.
    public Transform modelTransform;
    ///Trigger that detects incoming and outgoing ships to apply gravity.
    public SphereCollider gravTrigger;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        modelTransform.localScale = Vector3.one * radius * 2;
        gravTrigger.radius = radius + gravFieldRadius;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Ship ship))
        {
            Vector3 offset = (transform.position - ship.transform.position).normalized;
            ship.SetPlanetGravity(offset * gravForce); // Safely execute methods on the class
        }

    }
    private void OnTriggerExit(Collider other)
    {
         if (other.TryGetComponent(out Ship ship))
        {
            //Should be changed if we want multiple grav. fields to touch.
            ship.SetPlanetGravity(Vector3.zero); // Safely execute methods on the class
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius + gravFieldRadius);
    }
}

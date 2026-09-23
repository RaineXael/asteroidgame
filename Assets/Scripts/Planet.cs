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
    public Transform gravRadiusModelTransform;
    ///Trigger that detects incoming and outgoing ships to apply gravity.
    public SphereCollider gravTrigger;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        modelTransform.localScale = Vector3.one * radius * 2;
        gravTrigger.radius = radius + gravFieldRadius;
        gravRadiusModelTransform.localScale = Vector3.one * (radius + gravFieldRadius) * 2;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Ship ship))
        {
            ship.AddToPlanetList(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Remove planet from the ship's list.
        if (other.TryGetComponent(out Ship ship))
        {
            ship.RemoveFromPlanetList(this);
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

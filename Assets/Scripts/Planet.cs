using UnityEngine;

public class Planet : MonoBehaviour
{
    // //ZScale. Set this low so the camera can render the whole planet.
    // public float depth = 3f;
    //Total radius of the planet (the solid part, not the grav. field.)
    public float radius = 2f;
    //Radius (not including planet radius) that the gravitational field will have.
    public float gravFieldRadius = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        transform.localScale = Vector3.one * radius * 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius + gravFieldRadius);
    }
}

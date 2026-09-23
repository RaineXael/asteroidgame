using UnityEngine;

public class Player : Ship
{

    [Header("Player Class Parameters")]
    
    [SerializeField] private float rotateSpeed = 10.0f;
    //Acceleration of the forward / backward thrust.
    [SerializeField] private float thrustAcceleration = 15.0f;
    //The max magnitude the player's velocity can have by input.
    //Additional planet velocity go beyond this limit. 
    public float maxThrustSpeed = 30.0f;
    //Ship's X Rotation, changes when turning. Visual only. 
    private float shootTimer;
    [SerializeField] private float shootCooldown = 0.166f;
    //Current Angle the player is facing (in radians)
    private float currentAngle;
    //X Rotation of the model, cosmetic only
    private float xRotation;

    [Header("Player Class Object References")]

    [SerializeField] private Transform modelTransform; //Transform of the mesh that gets rotated to indicate direction
    [SerializeField] private PlayerCamera playerCam;
    [SerializeField] private ParticleSystem thrustParticle;
    [SerializeField] private GameObject bulletPrefab;
    private Rigidbody rb;
    
    public override void Start()
    {
        rb = GetComponent<Rigidbody>();
        base.Start();
    }

    void Update()
    {
        //Player Input
        float thrust = Input.GetAxis("Vertical");
        float rotate = Input.GetAxis("Horizontal");

        //Changing the currentAngle based on input (in radians)
        currentAngle -= Mathf.Deg2Rad * rotateSpeed * rotate * Time.deltaTime;

        //Forward & Backward thrust on Vertical input
        if (thrust != 0)
        {
            rb.linearVelocity += new Vector3(Mathf.Cos(currentAngle), Mathf.Sin(currentAngle), 0) * thrustAcceleration * thrust * Time.deltaTime;
            rb.linearVelocity = Vector3.ClampMagnitude(rb.linearVelocity, maxThrustSpeed);
        }

        //Particle Systems
        if (thrust > 0)
        {
            if (!thrustParticle.isPlaying)
            {
                thrustParticle.Play();
            }
        }
        else
        {
            if (thrustParticle.isPlaying)
            {
                thrustParticle.Stop();
            }
        }

        //Add any planet gravity to the velocity
        rb.linearVelocity += GetTotalPlanetGravity() * Time.deltaTime;

        //Lerp Model's x rotation to the rotation speed (so rotations don't look static)
        xRotation = Mathf.Lerp(xRotation, rotate, Time.deltaTime * 2f);
        //Set model rotation to currentAngle
        modelTransform.eulerAngles = new Vector3(xRotation * -30.0f, 0, Mathf.Rad2Deg * currentAngle);

        //Mousecursor to world coordinate (for mouse shoot)
        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = 10f; // distance from camera, must be != 0 to work

        //The position of the mouse in global position.
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);

        //The offset of the mouse from the player (mouseposition in local space)
        Vector3 mouseLookVector = worldPosition - transform.position;


        //Shoot Logic
        if (Input.GetButton("Fire1"))
        {
            shootTimer -= Time.deltaTime;
            if (shootTimer <= 0)
            {
                SpawnBullet(new Vector3(mouseLookVector.x, mouseLookVector.y, 0).normalized, rb.linearVelocity);
                shootTimer = shootCooldown;
            }
        }
    }


    void SpawnBullet(Vector3 direction, Vector3 additionalVelocity)
    {
        GameObject instance = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        //Setup bullet params here
        Bullet bullet = instance.GetComponent<Bullet>();
        bullet.SetData(direction, additionalVelocity);
        Debug.Log(direction);
    }

}

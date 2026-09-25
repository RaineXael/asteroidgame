using UnityEngine;

public class Player : Ship
{

    [Header("Player Class Parameters")]
    
    
    [SerializeField] private float shootCooldown = 0.166f;
    private float shootTimer;
    
    //X Rotation of the model, cosmetic only
    private float xRotation;

    [Header("Player Class Object References")]

    
    [SerializeField] private PlayerCamera playerCam;
    [SerializeField] private ParticleSystem thrustParticle;
    [SerializeField] private GameObject bulletPrefab;
    
    
    public override void Start()
    {
        
        base.Start();
    }

    public override void Update()
    {
        //Player Input
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));


        ChangeRotation(input.x);
        Thrust(input.y);

        //Particle Systems
        if (input.y > 0)
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

        base.Update();

        //Lerp Model's x rotation to the rotation speed (so rotations don't look static)
        xRotation = Mathf.Lerp(xRotation, input.x, Time.deltaTime * 2f);
        
        //Set model rotation to currentAngle
        modelTransform.eulerAngles = new Vector3(xRotation * -30.0f, 0, modelTransform.eulerAngles.z);

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
        bullet.SetData(direction, additionalVelocity, alignment);
        Debug.Log(direction);
    }

}

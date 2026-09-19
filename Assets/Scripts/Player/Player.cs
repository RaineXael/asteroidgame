using UnityEngine;

public class Player : Ship
{

    public Rigidbody rb;
    public float rotateSpeed = 10.0f;
    //Acceleration of the forward / backward thrust.
    public float maxThrust = 10.0f;

    private float currentAngle;

    //Object that gets rotated to indicate direction
    public Transform modelTransform;

    //The max magnitude the player's velocity can have by input.
    //Additional planet velocity can bypass this (unimplemented yet)
    public float maxSpeed = 50.0f;

    //Ship's X Rotation, changes when turning. Visual only. 
    public float xRotation;

    
    public PlayerCamera playerCam;


    public GameObject bulletPrefab;
    private float shootTimer;
    public float shootTime = 0.166f;

    public override void Start()
    {
        base.Start();
    }

    void Update()
    {
        //Input & angle changes
        float thrust = Input.GetAxis("Vertical");
        float rotate = Input.GetAxis("Horizontal");
        currentAngle -= Mathf.Deg2Rad * rotateSpeed * rotate * Time.deltaTime;

        //Forward & Backward thrust on Vertical input
        if (thrust != 0)
        {
            rb.linearVelocity += new Vector3(Mathf.Cos(currentAngle), Mathf.Sin(currentAngle), 0) * maxThrust * thrust * Time.deltaTime;
            rb.linearVelocity = Vector3.ClampMagnitude(rb.linearVelocity, maxSpeed); 
        }

        rb.linearVelocity += planetGrav * Time.deltaTime;

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
            if(shootTimer <= 0)
            {
                SpawnBullet(mouseLookVector.normalized, rb.linearVelocity);
                shootTimer = shootTime;
            }
        }
    }


    void SpawnBullet(Vector3 direction, Vector3 additionalVelocity)
    {
        GameObject instance = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        //Setup bullet params here
        Bullet bullet = instance.GetComponent<Bullet>();
        bullet.SetData(direction, additionalVelocity);
    }

}

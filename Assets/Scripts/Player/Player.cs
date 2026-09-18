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
        

    }
}

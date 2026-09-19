using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    public bool effectsDisabled;

    private Camera cam;
    public float distance = -10f;
    public Player target;
    private Rigidbody targetRigidBody; //For tracking velocity for FOV changes (sauce)
    private float initialFOV;
    private float maxFOVAddition = 5.0f; //Max FOV that can be added to the initial FOV.
    public float fovLerpSpeed = 3.0f;


    //Camera Shake Vars
    private float camShakeTimer;
    private float camShakeMagnitude;

    void Start()
    {
        //Initialize all needed params
        cam = GetComponent<Camera>();
        initialFOV = cam.fieldOfView;
        targetRigidBody = target.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Screenshake example
        // if (Input.GetButtonDown("Fire1"))
        // {
        //     SetCameraShake(0.166f,0.15f);
        // }

        //Set position to target
        Vector3 targetPosition = target.transform.position;
        transform.position = new Vector3(targetPosition.x, targetPosition.y, distance);

        if (!effectsDisabled)
        {
            //Set FOV based on target velocity
            float targetFOV = initialFOV + targetRigidBody.linearVelocity.magnitude / target.maxSpeed * maxFOVAddition;
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, Mathf.Clamp(targetFOV, initialFOV,initialFOV+maxFOVAddition),Time.deltaTime * fovLerpSpeed);

            
        
            //Camera Shake + Timer Logic
            if (camShakeTimer > 0)
            {
                camShakeTimer -= Time.deltaTime;
                transform.position += new Vector3(Random.Range(-camShakeMagnitude,camShakeMagnitude),Random.Range(-camShakeMagnitude,camShakeMagnitude),0);
            }
        }

    }


    public void SetCameraShake(float time, float magnitude)
    {
        camShakeMagnitude = magnitude;
        camShakeTimer = time;
    }

}

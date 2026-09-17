using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody rb; 
    public float rotateSpeed = 10.0f;
    public float maxThrust = 10.0f;

    private float currentAngle;

    public Transform modelTransform;

    public float maxSpeed = 50.0f;


   
    void Update()
    {
        float thrust = Input.GetAxis("Vertical");
        float rotate = Input.GetAxis("Horizontal");
        
        currentAngle -= Mathf.Deg2Rad * (rotateSpeed) * rotate * Time.deltaTime;

       if(thrust != 0){
            rb.linearVelocity += new Vector3(Mathf.Cos(currentAngle), Mathf.Sin(currentAngle),0) * thrust;
            rb.linearVelocity = Vector3.ClampMagnitude(rb.linearVelocity, maxSpeed);
       }
        
        
        modelTransform.eulerAngles = new Vector3(0,0,Mathf.Rad2Deg * currentAngle);
        UnityEngine.Debug.Log(currentAngle);
        
    }
}

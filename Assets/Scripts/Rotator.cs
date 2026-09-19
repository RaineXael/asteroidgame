using UnityEngine;

public class Rotator : MonoBehaviour
{
    //Simple script to rotate a transform over time.
    //Intended for the skybox.

    public Vector3 rotationFactor; //Degrees per second

    void Update()
    {
        transform.eulerAngles += rotationFactor * Time.deltaTime;
    }
}

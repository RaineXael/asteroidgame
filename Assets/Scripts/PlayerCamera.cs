using UnityEngine;

public class PlayerCamera : MonoBehaviour
{


    public float distance = -10f;
    public GameObject target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = target.transform.position;
        transform.position = new Vector3(targetPosition.x, targetPosition.y, distance);
    }
}

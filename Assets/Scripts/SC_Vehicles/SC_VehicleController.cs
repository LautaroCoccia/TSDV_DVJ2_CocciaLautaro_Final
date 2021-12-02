using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_VehicleController : MonoBehaviour
{
    [SerializeField] float velocity;
    enum directionEnum
    {
        left,
        right
    }
    [SerializeField] directionEnum direction;
    Vector3 startPosition;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate() 
    {
        rb.velocity = velocity * GetDirection();
    }
    private void OnCollisionEnter(Collision other) 
    {
    
    }

    private void OnTriggerEnter(Collider other) 
    {
        transform.position = startPosition;    
    }

    Vector3 GetDirection()
    {
        if(direction == directionEnum.left)
        {
            return Vector3.left;
        }
        else
        {
            return Vector3.right;
        }
    }
}

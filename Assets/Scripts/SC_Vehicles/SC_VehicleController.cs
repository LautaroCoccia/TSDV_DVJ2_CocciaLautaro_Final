using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_VehicleController : MonoBehaviour
{
    [SerializeField] float velocity;
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
        rb.velocity = velocity * Vector3.right;
        Debug.Log("VELOCITY" + velocity * Vector3.right);
        Debug.Log("--------------");
        Debug.Log("RB.VELOCITY" + rb.velocity);
        Debug.Log("--------------");
    }
    private void OnCollisionEnter(Collision other) {
        Debug.Log(other.transform.name);
    }

    private void OnTriggerEnter(Collider other) 
    {
        transform.position = startPosition;    
    }
}

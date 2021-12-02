using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_VehicleController : MonoBehaviour
{
    //Podria ser tranquilamente un scriptable object 
    [SerializeField] float velocity;
    enum directionEnum
    {
        left,
        right
    }
    [SerializeField] directionEnum direction;
    [SerializeField] Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        if(startPosition == Vector3.zero)
        {
            startPosition = transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocity * GetDirection() * Time.deltaTime, Space.World);
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

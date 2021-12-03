using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
public class VehicleController : MonoBehaviour, IHitable
{
    public static Action OnHitPlayer; 
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
    public void OnHit()
    {
        OnHitPlayer?.Invoke();
    }
    public bool OnHitMovePoint()
    {
        return false;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePointController : MonoBehaviour
{
    Vector3 prevPos;
    // Start is called before the first frame update
    private void OnEnable() 
    {
        PlayerMovement.OnMovePointPosChange += SetPrevPos;
    }

    private void OnDisable() 
    {
        PlayerMovement.OnMovePointPosChange -= SetPrevPos;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetPrevPos()
    {
        prevPos = transform.position;
    }
    private void OnCollisionEnter(Collision other) 
    {
        if(8 == other.gameObject.layer)
        {
            if(other.gameObject.GetComponent<IHitable>().OnHitMovePoint())
            {
                transform.position = prevPos;
            }
        }
    }
}

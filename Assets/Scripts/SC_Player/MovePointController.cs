using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePointController : MonoBehaviour
{
    Vector3 prevPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetPrevPos(Vector3 newPrevPos)
    {
        prevPos = newPrevPos;
    }
    private void OnCollisionEnter(Collision other) {
        
    }
}

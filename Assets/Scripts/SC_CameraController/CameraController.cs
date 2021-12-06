using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Vector3 offset;
    [SerializeField] Transform playerPos;
    // Start is called before the first frame update
    void Start()
    {
        if(offset == Vector3.zero)
        {
            offset = transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerPos.position + offset;

        transform.LookAt(playerPos.position);
    }
}

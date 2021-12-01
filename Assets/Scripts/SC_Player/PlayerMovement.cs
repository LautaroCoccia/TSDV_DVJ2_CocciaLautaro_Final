using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 10;
    [SerializeField] Transform movePoint;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);
        
        if(Vector3.Distance(transform.position, movePoint.position) <= 0.05 && Input.anyKeyDown )
        {
            if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1)
            {
                //HACER ESTO UN ACTION
                movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal") * 2, 0, 0);
            }

            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1)
            {
                //HACER ESTO UN ACTION
                movePoint.position += new Vector3(0, 0, Input.GetAxisRaw("Vertical") * 2);
            }
        }
    }
}

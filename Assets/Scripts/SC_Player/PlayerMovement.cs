using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 10;
    [SerializeField] Transform movePoint;
    [SerializeField] Animator anim;
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
            float horizontalAxisValue = Input.GetAxisRaw("Horizontal");
            float verticalAxisValue = Input.GetAxisRaw("Vertical");
            if(Mathf.Abs(horizontalAxisValue) == 1)
            {
                if(horizontalAxisValue < 0)
                    transform.rotation = Quaternion.Euler(0, -90, 0);
                else
                    transform.rotation = Quaternion.Euler(0, 90, 0);
                //HACER ESTO UN ACTION
                anim.SetBool("IsMoving",true);
                movePoint.position += new Vector3(horizontalAxisValue * 2, 0, 0);
            }

            if (Mathf.Abs(verticalAxisValue) == 1)
            {
                if (verticalAxisValue < 0)
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                else
                    transform.rotation = Quaternion.identity;

                //HACER ESTO UN ACTION
                anim.SetBool("IsMoving",true);
                movePoint.position += new Vector3(0, 0, Input.GetAxisRaw("Vertical") * 2);
            }
        }
        else if(Vector3.Distance(transform.position, movePoint.position) <= 0.05)
        {
            anim.SetBool("IsMoving",false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    enum typeOfMovement
    {
        OnKey,
        OnKeyDown
    }
    [SerializeField] typeOfMovement moveType;
    [SerializeField] float speed = 10;
    [SerializeField] float movementDelay = 0.25f;
    float actualTime;
    [SerializeField] Transform movePoint;
    //[SerializeField] Animator anim;

    public static Action OnMovePointPosChange;
    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
    }
    // Update is called once per frame
    void Update()
    {
        if(moveType == typeOfMovement.OnKey && actualTime < movementDelay)
        {
            actualTime += Time.deltaTime;
        }
        
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);
        
        if(GetMovementType())
        {
            float horizontalAxisValue = Input.GetAxisRaw("Horizontal");
            float verticalAxisValue = Input.GetAxisRaw("Vertical");

            if(Mathf.Abs(horizontalAxisValue) == 1)
            {
                actualTime = 0;
                if(horizontalAxisValue < 0)
                    transform.rotation = Quaternion.Euler(0, -90, 0);
                else
                    transform.rotation = Quaternion.Euler(0, 90, 0);
                //HACER ESTO UN ACTION
                //anim.SetBool("IsMoving",true);
                OnMovePointPosChange?.Invoke();
                movePoint.position += new Vector3(horizontalAxisValue * 2, 0, 0);
            }
            else if (Mathf.Abs(verticalAxisValue) == 1)
            {
                actualTime = 0;
                if (verticalAxisValue < 0)
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                else
                    transform.rotation = Quaternion.identity;

                //HACER ESTO UN ACTION
                //anim.SetBool("IsMoving",true);
                OnMovePointPosChange?.Invoke();
                movePoint.position += new Vector3(0, 0, Input.GetAxisRaw("Vertical") * 2);
            }
        }
        else if(GetMovementType())
        {
            //anim.SetBool("IsMoving",false);
        }
    }
    bool GetMovementType()
    {
        if(moveType == typeOfMovement.OnKeyDown)
        {
            return Vector3.Distance(transform.position, movePoint.position) <= 0.05 && Input.anyKeyDown; 
        }
        else if(moveType == typeOfMovement.OnKey )
        {
            return (Vector3.Distance(transform.position, movePoint.position) <= 0.05 && actualTime > movementDelay);
        }
        else
        {
            return false;
        }
    }
    public void ResetPos()
    {
        transform.position = Vector3.zero;
        movePoint.position = Vector3.zero;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalSpotCollision : MonoBehaviour, IHitable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnHit()
    {
        //No hace nada
    }   
    public bool OnHitMovePoint()
    {
        return true;
    }
}

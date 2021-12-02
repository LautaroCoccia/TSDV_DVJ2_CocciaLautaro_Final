

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionManager : MonoBehaviour
{
    [SerializeField] int iHitableLayerValue;
    
    private void OnCollisionEnter(Collision other) 
    {
            if(iHitableLayerValue == other.gameObject.layer)
            {
                
            }
    }
}

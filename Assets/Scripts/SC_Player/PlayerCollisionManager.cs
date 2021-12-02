

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionManager : MonoBehaviour
{
    PlayerMovement playerMovement;
    private void Start() 
    {
        playerMovement = gameObject.GetComponent<PlayerMovement>();
    }
    [SerializeField] int iHitableLayerValue;
    
    private void OnCollisionEnter(Collision other) 
    {
            if(iHitableLayerValue == other.gameObject.layer)
            {
                other.gameObject.GetComponent<IHitable>().OnHit();
                playerMovement.ResetPos();
            }
    }
}

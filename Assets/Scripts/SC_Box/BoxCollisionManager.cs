using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BoxCollisionManager : MonoBehaviour, IHitable
{
    [SerializeField] int score = 500;

    public static Action<int> OnPlayerGoal;
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
        OnPlayerGoal?.Invoke(score);
        gameObject.SetActive(false);
    }   
    public bool OnHitMovePoint()
    {
        return false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidPassiveMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float maxForceUpdate;
    void Start()
    {
        InvokeRepeating("SlightMovementUpdate", 0f, 1f);
        rb = GetComponent<Rigidbody>();
    }

    void SlightMovementUpdate()
    {
        rb.AddRelativeForce(Random.Range(0,maxForceUpdate), Random.Range(0,maxForceUpdate), Random.Range(0,maxForceUpdate));
    }
}

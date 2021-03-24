using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidPassiveMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float maxForceUpdate;
    public float maxRotationUpdate;
    public float rotationSpeed = 1f;
    private Vector3 rotationVector;
    void Start()
    {
        InvokeRepeating("SlightMovementUpdate", 0f, 1f);
        rb = GetComponent<Rigidbody>();
        rotationVector = new Vector3(Random.Range(0, 30), Random.Range(0, 30), Random.Range(0, 30));
        maxForceUpdate *= (transform.localScale.z / 7);
    }

    void SlightMovementUpdate()
    {
        
        rb.AddRelativeForce(Random.Range(0,maxForceUpdate), Random.Range(0,maxForceUpdate), Random.Range(0,maxForceUpdate));
        
        
    }

    private void Update()
    {
        // Constantly rotate, might look weird?
        //transform.Rotate (rotationVector * Time.deltaTime); //rotates 50 degrees per second around z axis
    }
}

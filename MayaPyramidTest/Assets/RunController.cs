using System;
using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityEngine;

public class RunController : MonoBehaviour
{
    public PathCreator pathCreator;
    public float speed = 5;
    public float _distanceTravelled;
    private bool _running;
    private GameObject _player;
    
    public bool Running   // property
    {
        get { return _running; }   // get method
        set { _running = value; }  // set method
    }

    private void Start()
    {
        _running = true;
        _player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (_running)
        {
            _distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(_distanceTravelled);
            transform.rotation = pathCreator.path.GetRotationAtDistance(_distanceTravelled);
        }
        else
        {
            var step = speed * 100 * Time.deltaTime;
            Vector3 targetDirection = _player.transform.position - transform.position;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, step, 0f);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }
}

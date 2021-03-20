using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    public float sphereCastRadius;
    private RunController _runController;
    private Animator _animator;
    private int isRunningHash;
    void Start()
    {
        _runController = GetComponent<RunController>();
        _animator = GetComponent<Animator>();
        isRunningHash = Animator.StringToHash("isRunning");
        InvokeRepeating("CheckPlayerNearby", 0, 0.5f);
    }

    void CheckPlayerNearby()
    {
        bool isRunning = _animator.GetBool(isRunningHash);
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, sphereCastRadius);
        bool playerNearby = false;
        foreach (var hit in hitColliders)
        {
            if (hit.transform.CompareTag("Player"))
            {
                // This character is close enough to talk to, stop walking and turn towards them. 
                playerNearby = true;
                _runController.Running = false;
                if (isRunning)
                {
                    _animator.SetBool(isRunningHash, false);
                }
            }
        }
        if(!playerNearby)
        {   
            // The OverlapSphere did not find anything, start physically running again along bezier curve path
            _runController.Running = true;
            if (!isRunning)
            {
                _animator.SetBool(isRunningHash, true);
            }
        }
        
    }
}

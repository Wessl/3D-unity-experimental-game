using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    private Animator _animator;
    private int isWalkingHash;
    private int isRunningHash;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
    }

    // Update is called once per frame
    void Update()
    {
        bool isRunning = _animator.GetBool(isRunningHash);
        bool isWalking = _animator.GetBool(isWalkingHash);
        bool forwardPressed = Input.GetKey("t");
        bool runPressed = Input.GetKey("left shift");
        if (!isWalking && forwardPressed)
        {
            _animator.SetBool(isWalkingHash, true);
        }
        if (isWalking && !forwardPressed)
        {
            _animator.SetBool(isWalkingHash, false);
        }

        if (!isRunning && (forwardPressed && runPressed))
        {
            _animator.SetBool(isRunningHash, true);
        }

        if (isRunning && (!forwardPressed || !runPressed))
        {
            _animator.SetBool(isRunningHash, false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneController : MonoBehaviour
{
    public float forwardSpeed = 25f, strafeSpeed = 7.5f, hoverSpeed = 5f;
    private float _activeForwardSpeed, _activeStrafeSpeed, _activeHoverSpeed;
    void Start()
    {
        
    }

    void Update()
    {
        _activeForwardSpeed = Input.GetAxisRaw("Vertical") * forwardSpeed;
        _activeStrafeSpeed = Input.GetAxisRaw("Horizontal") * strafeSpeed;
        _activeHoverSpeed = Input.GetAxisRaw("Hover") * hoverSpeed;
        transform.position += _activeForwardSpeed * Time.deltaTime * transform.forward;
        transform.position += _activeStrafeSpeed * Time.deltaTime * transform.right;
        transform.position += _activeHoverSpeed * Time.deltaTime * transform.up;

    }
}

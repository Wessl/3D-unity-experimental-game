using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneController : MonoBehaviour
{
    public float forwardSpeed = 25f, strafeSpeed = 7.5f, hoverSpeed = 5f;
    private float _activeForwardSpeed, _activeStrafeSpeed, _activeHoverSpeed;
    private float _forwardAcceleration = 2.5f, _strafeAcceleration = 2f, _hoverAcceleration = 2f; 
    void Start()
    {
        
    }

    void Update()
    {
        _activeForwardSpeed = Mathf.Lerp(_activeForwardSpeed, Input.GetAxisRaw("Vertical") * forwardSpeed, _forwardAcceleration * Time.deltaTime);
        _activeStrafeSpeed = Mathf.Lerp(_activeStrafeSpeed, Input.GetAxisRaw("Horizontal") * strafeSpeed, _strafeAcceleration * Time.deltaTime);
        _activeHoverSpeed = Mathf.Lerp(_activeHoverSpeed, Input.GetAxisRaw("Hover") * hoverSpeed, _hoverAcceleration * Time.deltaTime);
        transform.position += _activeForwardSpeed * Time.deltaTime * transform.forward;
        transform.position += _activeStrafeSpeed * Time.deltaTime * transform.right;
        transform.position += _activeHoverSpeed * Time.deltaTime * transform.up;

    }
}

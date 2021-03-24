using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class AirplaneController : MonoBehaviour
{
    [SerializeField] private ParticleSystem exhaustFumes;
    [SerializeField] private AudioSource exhaustSound;
    public int exhaustRateOverTime = 10000;
    public float forwardSpeed = 25f, strafeSpeed = 7.5f, hoverSpeed = 5f;
    private float _activeForwardSpeed, _activeStrafeSpeed, _activeHoverSpeed;
    private float _forwardAcceleration = 2.5f, _strafeAcceleration = 2f, _hoverAcceleration = 2f;
    public float lookRateSpeed = 90f;
    private Vector2 lookInput, screenCenter, mouseDistance;
    private float rollInput;
    public float rollSpeed = 90f, rollAcceleration = 3.5f;
    public GameObject projectile;
    void Start()
    {
        screenCenter.x = Screen.width / 2f;
        screenCenter.y = Screen.height / 2f;
        Cursor.lockState = CursorLockMode.Confined;
    }

    void Update()
    {
        lookInput = Input.mousePosition;
        mouseDistance = (lookInput - screenCenter) / screenCenter;

        mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);

        rollInput = Mathf.Lerp(rollInput, Input.GetAxisRaw("Roll"), rollAcceleration * Time.deltaTime);
        
        transform.Rotate(-mouseDistance.y * lookRateSpeed * Time.deltaTime, mouseDistance.x * lookRateSpeed * Time.deltaTime, rollInput * rollSpeed * Time.deltaTime, Space.Self);

        _activeForwardSpeed = Mathf.Lerp(_activeForwardSpeed, Input.GetAxisRaw("Vertical") * forwardSpeed, _forwardAcceleration * Time.deltaTime);
        _activeStrafeSpeed = Mathf.Lerp(_activeStrafeSpeed, Input.GetAxisRaw("Horizontal") * strafeSpeed, _strafeAcceleration * Time.deltaTime);
        _activeHoverSpeed = Mathf.Lerp(_activeHoverSpeed, Input.GetAxisRaw("Hover") * hoverSpeed, _hoverAcceleration * Time.deltaTime);
        
        transform.position += _activeForwardSpeed * Time.deltaTime * transform.forward;
        transform.position += _activeStrafeSpeed * Time.deltaTime * transform.right;
        transform.position += _activeHoverSpeed * Time.deltaTime * transform.up;

        var exhaustEmission = exhaustFumes.emission;
        if (Input.GetAxisRaw("Vertical") != 0)
        {
            exhaustEmission.enabled = true;
            exhaustEmission.rateOverTime = Mathf.Lerp(100, 10000, 2);
            //exhaustSound.volume = Mathf.Lerp(0, 1, 0.1f);
        }
        else
        {
            //exhaustSound.volume = Mathf.Lerp(1, 0, 0.1f);
            exhaustEmission.enabled = false; 
        }

        if (Input.GetButtonDown("Fire1"))
        {
            var transRot = transform.rotation;
            var targetRotation = transform.rotation * Quaternion.Euler(90, 0, 0);
            //YIKES
            var targetLeftPos = transform.GetChild(3).position;
            var targetRightPos = transform.GetChild(4).position;
            Instantiate(projectile, targetLeftPos, targetRotation);
            Instantiate(projectile, targetRightPos, targetRotation);
        }
    }
}

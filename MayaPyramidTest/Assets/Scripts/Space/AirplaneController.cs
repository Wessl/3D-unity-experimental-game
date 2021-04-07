using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

// This class is a gigantic mess. TODO: Clean up
public class AirplaneController : MonoBehaviour
{
    // Exhaust particles
    [SerializeField] private ParticleSystem exhaustFumes;
    // Sound
    [SerializeField] private AudioSource airplaneSoundPlayer;
    public AudioClip shootSoundZap;
    private float _sfxVolume;
    // Plane movement variables
    public float forwardSpeed = 25f, strafeSpeed = 7.5f, hoverSpeed = 5f;
    private float _activeForwardSpeed, _activeStrafeSpeed, _activeHoverSpeed;
    private float _forwardAcceleration = 2.5f, _strafeAcceleration = 2f, _hoverAcceleration = 2f;
    public float lookRateSpeed = 90f;
    // Store script-wide variables relating to mouse, roll input and screen coordinates
    private Vector2 lookInput, screenCenter, mouseDistance;
    private float rollInput;
    public float rollSpeed = 90f, rollAcceleration = 3.5f;
    // Reference to the particle system that is triggered briefly whenever a shot is fired
    private ParticleSystem[] shootBlastPS;
    public GameObject projectile;
    public GameObject[] shootBlast;
    
    void Start()
    {
        shootBlastPS = new ParticleSystem[2];
        shootBlast = GameObject.FindGameObjectsWithTag("Blast");
        shootBlastPS[0] = shootBlast[0].GetComponent<ParticleSystem>();
        shootBlastPS[1] = shootBlast[1].GetComponent<ParticleSystem>();
        
        screenCenter.x = Screen.width / 2f;
        screenCenter.y = Screen.height / 2f;
        Cursor.lockState = CursorLockMode.Confined;

        _sfxVolume = PlayerPrefs.GetFloat("sfxSliderValue");
    }

    void Update()
    {
        // Store some mouse input data, vector to mouse pos from center of screen
        lookInput = Input.mousePosition;
        mouseDistance = (lookInput - screenCenter) / screenCenter;
        mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);

        // Rolling from side to side causes rotation along the Z axis
        rollInput = Mathf.Lerp(rollInput, Input.GetAxisRaw("Roll"), rollAcceleration * Time.deltaTime);
        // Align plane towards mouse position & apply potential roll input
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
        
        // Handles firing the main guns. 
        // Will occur when any button designated as Fire1 is down, 
        // as well as the timescale not being 0, i.e. game is not paused. 
        if (Input.GetButtonDown("Fire1") && Time.timeScale!=0)
        {
            var targetRotation = transform.rotation * Quaternion.Euler(90, 0, 0);
            //Get the child objects -> they are the 4th and 5th objects nested
            var targetLeftPos = transform.GetChild(3).position;
            var targetRightPos = transform.GetChild(4).position;
            Instantiate(projectile, targetLeftPos, targetRotation);
            Instantiate(projectile, targetRightPos, targetRotation);
            
            // Firing causes light to appear briefly
            var lightIntensity = Mathf.Lerp(0, 100f, 10);
            shootBlast[0].GetComponent<Light>().intensity = lightIntensity;
            shootBlast[1].GetComponent<Light>().intensity = lightIntensity;
            shootBlastPS[0].Play();
            shootBlastPS[1].Play();
            
            // The sound from shooting - need to get the float again 
            _sfxVolume = PlayerPrefs.GetFloat("sfxSliderValue");
            airplaneSoundPlayer.PlayOneShot(shootSoundZap, _sfxVolume);
        }
        else
        {
            // Linearly interpolate back down the light
            var lightIntensity = Mathf.Lerp(100f, 0, 10);
            shootBlast[0].GetComponent<Light>().intensity = lightIntensity;
            shootBlast[1].GetComponent<Light>().intensity = lightIntensity;
        }
    }
}

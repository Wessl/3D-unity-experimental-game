using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody bd;

    public float speed;
    void Start()
    {
        bd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        bd.AddForce(Input.GetAxisRaw("Horizontal") * speed, Input.GetAxisRaw("Vertical") * speed, 0, ForceMode.VelocityChange);

    }
}

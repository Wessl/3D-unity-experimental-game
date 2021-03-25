using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamMovement : MonoBehaviour
{
    public float speed;

    private Vector3 playerPos;
    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindWithTag("Player").transform.position;
        InvokeRepeating("CheckDistance", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * (speed * Time.deltaTime);
        
    }

    void CheckDistance()
    {
        if ((transform.position - playerPos).magnitude > 1000)
        {
            Destroy(gameObject);
        }
    }
}

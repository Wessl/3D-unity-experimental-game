using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDestructibility : MonoBehaviour
{
    public float hp = 1f;
    public GameObject fx;
    private void OnTriggerEnter(Collider other)
    {
        var particels = Instantiate(fx, transform.position, Quaternion.identity);
        particels.transform.localScale = transform.localScale;
        Destroy(gameObject);
        
    }
}

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
        Debug.Log("i am asteroid, i am hit");
        var particels = Instantiate(fx, transform.position, Quaternion.identity);
        particels.transform.localScale = transform.localScale;
        Destroy(gameObject);
        
    }
}

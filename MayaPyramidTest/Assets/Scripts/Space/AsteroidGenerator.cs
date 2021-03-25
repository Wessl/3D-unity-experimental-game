using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour
{
    public GameObject[] asteroidPrefabs;

    public float xBound = 1000f, yBound = 1000f, zBound = 1000f;
    [Range(0.0f, 300.0f)]
    public float lowerSize = 0.5f, higherSize = 8f;

    public int asteroidAmount = 100;
    
    public int AsteroidAmount   // property
    {
        get => asteroidAmount; // get method
        //set => asteroidAmount = value; // set method
    }
    // Start is called before the first frame update
    void Start()
    {
        // Spawn asteroids randomly in space
        for (int i = 0; i < asteroidAmount; i++)
        {
            var rndAsteroidP_Idx = Random.Range(0, asteroidPrefabs.Length);
            Debug.Log(rndAsteroidP_Idx);
            var rndxLoc = Random.Range(-xBound, xBound);
            var rndyLoc = Random.Range(-yBound, yBound);
            var rndzLoc = Random.Range(-zBound, zBound);
            var rndQuat = Quaternion.Euler(Random.Range(0,360), Random.Range(0,360), Random.Range(0,360));
            var rndScale = Random.Range(lowerSize, higherSize);
            var ast = Instantiate(asteroidPrefabs[rndAsteroidP_Idx], new Vector3(rndxLoc, rndyLoc, rndzLoc), rndQuat);
            ast.transform.localScale *= rndScale;
        }
    }
}

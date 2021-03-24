using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour
{
    public GameObject[] asteroidPrefabs;

    public float xBound = 1000f, yBound = 1000f, zBound = 1000f;

    public int asteroidAmount = 100;
    // Start is called before the first frame update
    void Start()
    {
        // Spawn asteroids randomly in space
        for (int i = 0; i < asteroidAmount; i++)
        {
            var rndAsteroidP_Idx = Random.Range(0, asteroidPrefabs.Length-1);
            var rndxLoc = Random.Range(-xBound, xBound);
            var rndyLoc = Random.Range(-yBound, yBound);
            var rndzLoc = Random.Range(-zBound, zBound);
            var rndQuat = Quaternion.Euler(Random.Range(0,360), Random.Range(0,360), Random.Range(0,360));
            var rndScale = Random.Range(0.5f, 5f);
            var ast = Instantiate(asteroidPrefabs[rndAsteroidP_Idx], new Vector3(rndxLoc, rndyLoc, rndzLoc), rndQuat);
            ast.transform.localScale *= rndScale;
        }
    }
}

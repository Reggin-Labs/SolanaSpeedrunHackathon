using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject planet;
    public float timeBtwSpawn;
    public float startTimeBtwSpawn=5;
    public float decreaseTime;
    public int radius=10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBtwSpawn <= 0) {
            Vector3 planetSpawnPoint=Random.onUnitSphere*radius;
            Instantiate(planet, new Vector3(planetSpawnPoint.x,0f,planetSpawnPoint.z), Quaternion.identity);
            timeBtwSpawn = startTimeBtwSpawn;
        } else {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}

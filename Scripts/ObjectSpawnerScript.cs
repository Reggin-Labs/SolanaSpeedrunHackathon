// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class ObjectSpawnerScript : MonoBehaviour
// {
//     // Start is called before the first frame update
//     public GameObject planet;
//     public float timeBtwSpawn;
//     public float startTimeBtwSpawn=5;
//     public float decreaseTime;
//     public float minTime=0.65f;
//     public int spawnSide;
//     void Start()
//     {
//         spawnSide = Random.Range(0, 4);
//     }
 
//     void Update()
//     {
//         if(timeBtwSpawn <= 0) {
//             if(spawnSide == 0) {
//                 public Vector3 radius=Random.onUnitSphere*10;
//                 Instantiate(planet, new Vector3(radius.x,radius.y, 0f), Quaternion.identity);
//                 spawnSide = Random.Range(0, 4);
//             }
//             timeBtwSpawn = startTimeBtwSpawn;
//         } else {
//             timeBtwSpawn -= Time.deltaTime;
//         }
//     }
// }

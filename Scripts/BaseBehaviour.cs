using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBehaviour : MonoBehaviour
{

    public int baseHealth;
    SpawnCard spawncard;
    EnemyController enemyController;
    // Start is called before the first frame update
    void Start()
    {
        spawncard=GameObject.FindGameObjectWithTag("GameController").GetComponent<SpawnCard>();
        enemyController=GameObject.Find("EnemyBoxes").GetComponent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            MovementController movScript=other.gameObject.GetComponent<MovementController>();
            int playerHealth=movScript.health;
            baseHealth-=playerHealth;

            if(baseHealth>0)
            {
                spawncard.movementController.Remove(movScript);
                Destroy(other.gameObject,3);
            }
            else 
                Destroy(gameObject,3);
        }
        else if(other.CompareTag("Enemy"))
        {
            MovementController movScript=other.gameObject.GetComponent<MovementController>();
            int playerHealth=movScript.health;
            baseHealth-=playerHealth;

            if(baseHealth>0)
            {
                enemyController.movementController.Remove(movScript);
                Destroy(other.gameObject,3);
            }
            else 
                Destroy(gameObject,3);
        }
    }
}

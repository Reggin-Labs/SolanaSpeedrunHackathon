using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public bool isMoving = false;
    public int health;

    public float rotationDuration = 0.5f;
    public float movementDuration = 1f;

    public int blockDistance = 1;

    SpawnCard spawncard;
    EnemyController enemyController;

    void Start()
    {
        spawncard=GameObject.FindGameObjectWithTag("GameController").GetComponent<SpawnCard>();
        enemyController=GameObject.Find("EnemyBoxes").GetComponent<EnemyController>();
    }

    void Update()
    {
        //isMoving = gameObject.GetComponent<iTween>() != null ? true : false;
    }

    public void triggerMovement()
    {
        RaycastHit raycastHit;

        //Debug.DrawRay(transform.position,transform.forward*1,Color.red,10);
        //Debug.Log("Ray drew");
        #region Forward Ray
        Ray forwardRay = new Ray(transform.position-new Vector3(0,0.6f,0), transform.forward);
        //Debug.Log(forwardRay);
        if(Physics.Raycast(forwardRay, out raycastHit, blockDistance))
        {
            
            if(raycastHit.transform.CompareTag("CheckBox") || raycastHit.transform.CompareTag("Base"))
            {
                //lookForward();
                iTween.MoveTo(gameObject, iTween.Hash("position", raycastHit.transform.position+new Vector3(0, 0.6f, 0), "time", movementDuration, "easetype", iTween.EaseType.linear, "delay", 0f));
                
            }
        }
        #endregion
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            Debug.Log("Collided with enemy");
            MovementController movScript=other.gameObject.GetComponent<MovementController>();
            int enemyHealth=movScript.health;
            if(enemyHealth>health)
            {
                movScript.health-=health;
                spawncard.movementController.Remove(this);
                Destroy(gameObject,1);
                Debug.Log("player destroyed");
            }
            else if(enemyHealth<health)
            {
                health-=enemyHealth;
                enemyController.movementController.Remove(movScript);
                Destroy(other.gameObject,1);
                Debug.Log("Enemy destroyed");
            }
            else{
                spawncard.movementController.Remove(this);
                enemyController.movementController.Remove(movScript);
                Destroy(gameObject,1);
                Destroy(other.gameObject,1);
                Debug.Log("Both destroyed");
            }
        }
    }

}

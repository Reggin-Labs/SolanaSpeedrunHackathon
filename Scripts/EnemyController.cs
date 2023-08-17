using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public string tagToAdd="Enemy";
    public GameObject[] Checkers;
    public GameObject[] enemyCards;
    public int[] coolDown=new int[] {1,2};
    public int[] disabledRound=new int[] {0,0};
    public Dictionary<GameObject, (int cooldown, int disabledround)> gameObjectCooldowns = new Dictionary<GameObject, (int, int)>();
    SpawnCard spawncard;
    public List<MovementController> movementController = new List<MovementController>();
    
    

    void Start()
    {
        spawncard=GameObject.FindGameObjectWithTag("GameController").GetComponent<SpawnCard>();
        for(int i=0;i<enemyCards.Length;i++)
        {
            gameObjectCooldowns.Add(enemyCards[i],(coolDown[i],disabledRound[i]));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkEmptyPlaces()
    {   
        List<GameObject> emptyBox=new List<GameObject>();
        List<GameObject> availableCards = new List<GameObject>();
        foreach(GameObject obj in Checkers)
        {
          RaycastHit raycastHit;  
          Ray ray=new Ray(obj.transform.position,Vector3.down);
          if(Physics.Raycast(ray,out raycastHit,Mathf.Infinity))
          {
            if(raycastHit.transform.CompareTag("CheckBox"))
            {
               
                emptyBox.Add(raycastHit.collider.gameObject);
            }
          }
        }
       
        int randomBox = Random.Range(0, emptyBox.Count);

        foreach(var dict in gameObjectCooldowns)
        {
            GameObject gameObject=dict.Key;
            (int coolDown,int disabledRound)=dict.Value;
            if(coolDown+disabledRound<spawncard.gameRound)
                availableCards.Add(gameObject);
        }
        if(availableCards.Count>0)
        {
            int randomCard=Random.Range(0,availableCards.Count);
            GameObject selectedGameObject=availableCards[randomCard];

            var selectedTuple=gameObjectCooldowns[selectedGameObject];
            selectedTuple.disabledround=spawncard.gameRound;
            gameObjectCooldowns[selectedGameObject]=selectedTuple;

            GameObject instantiate=Instantiate(selectedGameObject,emptyBox[randomBox].transform.position,Quaternion.Euler(0,0,0));
            instantiate.tag=tagToAdd;
            MovementController mov = instantiate.GetComponent<MovementController>();
            movementController.Add(mov);
        }
        StartCoroutine(moveForward());
    }

    IEnumerator moveForward()
    {
        yield return new WaitForSeconds(1);
        foreach(MovementController mov in movementController)
        {
            //Debug.Log(mov);
            mov.triggerMovement();
            
        }
    }
}

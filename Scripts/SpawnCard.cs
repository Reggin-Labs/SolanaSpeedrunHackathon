using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnCard : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] card;
    public GameObject selectedCard;
    int cardIndex;
    public int gameRound=1;
    public float timeLeft;
    public float enemyTime;
    public bool timerOn=false;
    private GameObject[] buttons;
    public GameObject[][] checkers;

    public TMP_Text timerTxt;
    public TMP_Text round;

    EnemyController enemyController;

    public List<MovementController> movementController = new List<MovementController>();

    void Start()
    {
        buttons=GameObject.FindGameObjectsWithTag("Card Button");
        enemyController=GameObject.Find("EnemyBoxes").GetComponent<EnemyController>();
        //movementController = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timerOn)
        {
            if(timeLeft>0)
            {
                timeLeft-=Time.deltaTime;
                updateTimer(timeLeft);
                if(Input.GetMouseButtonDown(0))
                {
                    CastRay();
                }
            }
            else
            {   
                //Debug.Log("Time is Up!");
                enemyTime=2;
                StartCoroutine(moveForward());
                timerOn=false;
                updateRound(gameRound);
            }
        }
        else{
            if(enemyTime>0)
            {
                enemyTime-=Time.deltaTime;
            }
            else
            {
                gameRound++;
                //Debug.Log("Enemy time Up!!");
                enemyController.checkEmptyPlaces();
                timeLeft=5;
                timerOn=true;
            }
        }
        updateRound(gameRound);
    }

    void CastRay()
    {
        RaycastHit raycastHit;
        Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray,out raycastHit,Mathf.Infinity)){
            // Debug.Log(raycastHit.collider.gameObject);
            // Debug.Log(raycastHit.transform.position);
            if(raycastHit.transform.CompareTag("CheckBox")){
                GameObject instantiate=Instantiate(selectedCard,raycastHit.transform.position,Quaternion.Euler(0,180,0));
                timeLeft=0;
                buttons[cardIndex].GetComponent<Button>().interactable=false;
                buttons[cardIndex].GetComponent<CardButton>().disabledRound=gameRound;
                MovementController mov = instantiate.GetComponent<MovementController>();
                movementController.Add(mov);
            }
        }
    }

    public void SelectCard(int cardIndex){
        this.cardIndex=cardIndex;
        selectedCard=card[this.cardIndex];
    }

    void updateTimer(float currentTime)
    {
        currentTime+=1;
        float minutes=Mathf.FloorToInt(currentTime/60);
        float seconds=Mathf.FloorToInt(currentTime%60);

        timerTxt.text=string.Format("{0:00} : {1:00}",minutes,seconds);
    }
    
    void updateRound(float currentRound)
    {
        round.text=$"{currentRound}";
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

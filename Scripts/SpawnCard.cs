using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnCard : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] card;
    public GameObject[] cardUI;
    public GameObject[] cardDeck;
    public GameObject selectedCard;
    int cardIndex;
    public int gameRound=1;
    public float timeLeft;
    public float enemyTime;
    public bool timerOn=false;
    public GameObject[] buttons;
    public GameObject[][] checkers;

    public TMP_Text timerTxt;
    public TMP_Text round;

    EnemyController enemyController;

    public List<MovementController> movementController = new List<MovementController>();
    private void Awake()
    {
        PlayerPrefs.SetString("Hero", "Anatoly Card");
        PlayerPrefs.SetString("Building", "SolanaBuilding Card");
        PlayerPrefs.SetString("Developer", "SolanaDeveloper Card");
        PlayerPrefs.SetString("User", "SolanaUser Card");
    }

    void Start()
    {
        
        enemyController=GameObject.Find("EnemyBoxes").GetComponent<EnemyController>();
        
        for(int i=0;i<5;i++)
        {
            string pref = PlayerPrefs.GetString("Hero", "Anatoly Card");
            if (pref == cardUI[i].name)
            {
                var card=Instantiate(cardUI[i], cardDeck[0].transform.position, Quaternion.identity);
                card.transform.parent = cardDeck[0].transform;
                card.GetComponent<Image>().rectTransform.localScale = new Vector2(1,1);
            } 
        }
        for(int i=5;i<7; i++)
        {
            string pref = PlayerPrefs.GetString("Building", "SolanaBuilding Card");
            if (pref == cardUI[i].name)
            {
                var card = Instantiate(cardUI[i], cardDeck[1].transform.position, Quaternion.identity);
                card.transform.parent = cardDeck[1].transform;
                card.GetComponent<Image>().rectTransform.localScale = new Vector2(1, 1);
            }
        }
        for (int i = 7; i < 9; i++)
        {
            string pref = PlayerPrefs.GetString("Developer", "SolanaDeveloper Card");
            if (pref == cardUI[i].name)
            {
                var card = Instantiate(cardUI[i], cardDeck[2].transform.position, Quaternion.identity);
                card.transform.parent = cardDeck[2].transform;
                card.GetComponent<Image>().rectTransform.localScale = new Vector2(1, 1);
            }
        }
        for (int i = 9; i < 11; i++)
        {
            string pref = PlayerPrefs.GetString("User", "SolanaUser Card");
            if (pref == cardUI[i].name)
            {
                var card = Instantiate(cardUI[i], cardDeck[3].transform.position, Quaternion.identity);
                card.transform.parent = cardDeck[3].transform;
                card.GetComponent<Image>().rectTransform.localScale = new Vector2(1, 1);
            }
        }
        buttons = GameObject.FindGameObjectsWithTag("Card Button");


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
                GameObject instantiate=Instantiate(selectedCard,raycastHit.transform.position+new Vector3(0,0.6f,0),Quaternion.Euler(0,180,0));
                timeLeft=0;
                GameObject obj = cardUI[cardIndex];
                for(int i=0;i<4;i++)
                {
                    string name = buttons[i].name;
                    name = name.Substring(0, name.Length - "(Clone)".Length);
                    if(name==obj.name)
                    {
                        buttons[i].GetComponent<Button>().interactable = false;
                        buttons[i].GetComponent<CardButton>().disabledRound = gameRound;
                    }
                }
                
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

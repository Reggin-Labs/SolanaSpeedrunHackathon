using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardButton : MonoBehaviour
{
    SpawnCard spawncard;
    public int cardIndex;
    public int coolDown;
    public int disabledRound;
    Button btn;

    void Start()
    {
        spawncard=GameObject.FindGameObjectWithTag("GameController").GetComponent<SpawnCard>();
        btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(delegate() { SelectCard(); });
    }

    void Update()
    {
        makeInteractable();
        hideButton();
    }

    public void SelectCard()
    {
        Debug.Log("Here");
        spawncard.SelectCard(cardIndex);
        //btn.interactable=false;
        gameObject.transform.GetChild(1).gameObject.SetActive(true);
       
    }
    void hideButton()
    {
        string[] parts = gameObject.name.Split(" ");
        Debug.Log(parts[0]);
        if(parts[0]!=spawncard.selectedCard.name)
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    void makeInteractable()
    {
        if(disabledRound+coolDown<spawncard.gameRound)
        {
            btn.interactable=true;
            gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text ="";
        }
        else if(disabledRound!=0)
        {
            gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = (disabledRound+coolDown-spawncard.gameRound).ToString();
        }
    }
}

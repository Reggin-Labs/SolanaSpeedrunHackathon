using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    }

    public void SelectCard()
    {
        spawncard.SelectCard(cardIndex);
        //btn.interactable=false;
    }

    void makeInteractable()
    {
        if(disabledRound+coolDown<spawncard.gameRound)
        {
            btn.interactable=true;
        }
    }
}

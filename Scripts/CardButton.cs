using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardButton : MonoBehaviour
{
    SpawnCard spawncard;
    public int cardIndex;

    void Start(){
        spawncard=GameObject.FindGameObjectWithTag("GameController").GetComponent<SpawnCard>();
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(delegate() { SelectCard(); });
    }

    public void SelectCard(){
        spawncard.SelectCard(cardIndex);
    }
}

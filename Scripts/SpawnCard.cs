using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCard : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] card;
    public GameObject selectedCard;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            // Debug.Log("Clicked");
            CastRay();
        }
    }

    void CastRay()
    {
        RaycastHit raycastHit;
        Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray,out raycastHit,Mathf.Infinity)){
            Debug.Log(raycastHit.collider.gameObject);
            Debug.Log(raycastHit.transform.position);
            Instantiate(selectedCard,raycastHit.transform.position,Quaternion.identity);
        }
    }

    public void SelectCard(int cardIndex){
        Debug.Log(cardIndex);
        selectedCard=card[cardIndex];
    }

}

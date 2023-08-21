using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BaseUIManager : MonoBehaviour
{
    public GameObject EndPanel;
    public BaseBehaviour PlayerBB;
    public BaseBehaviour EnemyBB;
    bool hasEnded = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hasEnded) return;

        if(!EnemyBB) {
            hasEnded = true;
            EndPanel.SetActive(true);
            EndPanel.GetComponentInChildren<TextMeshProUGUI>().text = "You Won";
        }

        if(!PlayerBB) {
            hasEnded = true;
            EndPanel.SetActive(true);
            EndPanel.GetComponentInChildren<TextMeshProUGUI>().text = "Better Luck Next Time";
        }
        
    }
}

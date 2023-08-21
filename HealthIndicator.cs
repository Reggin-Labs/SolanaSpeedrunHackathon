using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthIndicator : MonoBehaviour
{
    public MovementController movementController;
    public TextMeshPro Text;
    // Start is called before the first frame update
    void Start()
    {
        Text = gameObject.GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        Text.text = movementController.health.ToString();
    }
}

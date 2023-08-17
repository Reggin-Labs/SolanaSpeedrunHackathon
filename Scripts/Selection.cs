// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.InputSystem;
// using UnityEngine.EventSystems;

// public class Selection : MonoBehaviour
// {
//     public Material selectionMaterial;

//     private Material originalMaterial;
   
//     private Transform selection;
//     private RaycastHit raycastHit;

//     private MovementController movementController;
//     // Start is called before the first frame update
//     void Start()
//     {
//         movementController = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementController>();
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if(Input.GetKeyDown(KeyCode.Mouse0) && !EventSystem.current.IsPointerOverGameObject() && !movementController.isMoving)
//         {
//             Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
//             if(Physics.Raycast(ray, out raycastHit))
//             {
//                 if(selection != null && selection != raycastHit.transform && raycastHit.transform.CompareTag("Markers"))
//                 {
//                     selection.GetComponent<Renderer>().material = originalMaterial;
//                 }
//                 if(selection == raycastHit.transform || !raycastHit.transform.CompareTag("Markers")) return;
//                 selection = raycastHit.transform;
//                 TriggerSelection();
//             }
//         }
//     }

//     void TriggerSelection()
//     {
//         originalMaterial = selection.GetComponent<Renderer>().material;
//         selection.GetComponent<Renderer>().material = selectionMaterial;
//         movementController.triggerMovement(selection);
//     }
// }

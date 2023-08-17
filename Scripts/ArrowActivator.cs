// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class ArrowActivator : MonoBehaviour
// {
//     private MovementController movementController;
    
//     public GameObject arrowNorth;
//     public GameObject arrowSouth;
//     public GameObject arrowEast;
//     public GameObject arrowWest;

//     void Start(){
//         movementController = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementController>();
//     }

//     private void OnTriggerStay(Collider other) {
//         RaycastHit raycastHit;
//         if (other.gameObject.tag == "Player") {

//             Ray forwardRay = new Ray(transform.position, transform.right);
//             if(Physics.Raycast(forwardRay, out raycastHit, movementController.blockDistance))
//                 if(raycastHit.transform.CompareTag("Markers"))
//                     arrowNorth.SetActive(!movementController.isMoving);
            
//             Ray backwardRay = new Ray(transform.position, -transform.right);
//             if(Physics.Raycast(backwardRay, out raycastHit, movementController.blockDistance))
//                 if(raycastHit.transform.CompareTag("Markers"))
//                     arrowSouth.SetActive(!movementController.isMoving);

//             Ray leftRay = new Ray(transform.position, -transform.forward);
//             if(Physics.Raycast(leftRay, out raycastHit, movementController.blockDistance))
//                 if(raycastHit.transform.CompareTag("Markers"))
//                     arrowEast.SetActive(!movementController.isMoving);

//             Ray rightRay = new Ray(transform.position, transform.forward);
//             if(Physics.Raycast(rightRay, out raycastHit, movementController.blockDistance))
//                 if(raycastHit.transform.CompareTag("Markers"))
//                     arrowWest.SetActive(!movementController.isMoving);
            
//         }
//     }
// }

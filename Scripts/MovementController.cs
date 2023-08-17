using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public bool isMoving = false;
    public int health;

    public float rotationDuration = 0.5f;
    public float movementDuration = 1f;

    public int blockDistance = 1;


    void Start()
    {
        
    }

    void Update()
    {
        //isMoving = gameObject.GetComponent<iTween>() != null ? true : false;
    }

    public void triggerMovement()
    {
        RaycastHit raycastHit;

        Debug.DrawRay(transform.position,transform.forward*1,Color.red,10);
        //Debug.Log("Ray drew");
        #region Forward Ray
        Ray forwardRay = new Ray(transform.position, transform.forward);
        // Debug.Log(forwardRay);
        if(Physics.Raycast(forwardRay, out raycastHit, blockDistance))
        {
            
            if(raycastHit.transform.CompareTag("CheckBox"))
            {
                //lookForward();
                iTween.MoveTo(gameObject, iTween.Hash("position", raycastHit.transform.position, "time", movementDuration, "easetype", iTween.EaseType.linear, "delay", 0f));
                
            }
            else if(raycastHit.transform.CompareTag("Base"))
            {
                Debug.Log("Hitting");
                iTween.MoveTo(gameObject, iTween.Hash("position", raycastHit.transform.position, "time", movementDuration, "easetype", iTween.EaseType.linear, "delay", 0f));
            }
        }
        #endregion

        // #region Right Ray
        // Ray rightRay = new Ray(transform.position, transform.right);
        // if(Physics.Raycast(rightRay, out raycastHit, blockDistance))
        // {
        //     if(raycastHit.transform == selection)
        //     {
        //         lookRight();
        //         iTween.MoveTo(gameObject, iTween.Hash("position", selection.position, "time", movementDuration, "easetype", iTween.EaseType.linear, "delay", rotationDuration));
        //     }
        // }
        // #endregion

        // #region Backward Ray
        // Ray backwardRay = new Ray(transform.position, -transform.forward);
        // if(Physics.Raycast(backwardRay, out raycastHit, blockDistance))
        // {
        //     if(raycastHit.transform == selection)
        //     {
        //         lookBackward();
        //         iTween.MoveTo(gameObject, iTween.Hash("position", selection.position, "time", movementDuration, "easetype", iTween.EaseType.linear, "delay", rotationDuration));
        //     }
        // }
        // #endregion

        // #region Left Ray
        // Ray leftRay = new Ray(transform.position, -transform.right);
        // if(Physics.Raycast(leftRay, out raycastHit, blockDistance))
        // {
        //     if(raycastHit.transform == selection)
        //     {
        //         lookLeft();
        //         iTween.MoveTo(gameObject, iTween.Hash("position", selection.position, "time", movementDuration, "easetype", iTween.EaseType.linear, "delay", rotationDuration));
        //     }
        // }
        // #endregion
    }

    // void lookForward(){
    //     iTween.RotateTo(gameObject, iTween.Hash("rotation", new Vector3(0f, transform.rotation.eulerAngles.y, 0f), "time", rotationDuration, "easetype", iTween.EaseType.linear));
    // }

    // void lookRight(){
    //     iTween.RotateTo(gameObject, iTween.Hash("rotation", new Vector3(0f, transform.rotation.eulerAngles.y + 90f, 0f), "time", rotationDuration, "easetype", iTween.EaseType.linear));
    // }

    // void lookBackward(){
    //     iTween.RotateTo(gameObject, iTween.Hash("rotation", new Vector3(0f, transform.rotation.eulerAngles.y + 180f, 0f), "time", rotationDuration, "easetype", iTween.EaseType.linear));
    // }

    // void lookLeft(){
    //     iTween.RotateTo(gameObject, iTween.Hash("rotation", new Vector3(0f, transform.rotation.eulerAngles.y - 90f, 0f), "time", rotationDuration, "easetype", iTween.EaseType.linear));
    // }
}

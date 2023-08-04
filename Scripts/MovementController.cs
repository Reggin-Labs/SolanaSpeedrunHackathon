using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public bool isMoving = false;

    public float rotationDuration = 0.5f;
    public float movementDuration = 1f;

    public int blockDistance = 4;


    void Start()
    {
        
    }

    void Update()
    {
        isMoving = gameObject.GetComponent<iTween>() != null ? true : false;
    }

    public void triggerMovement(Transform selection)
    {
        RaycastHit raycastHit;

        #region Forward Ray
        Ray forwardRay = new Ray(transform.position, transform.forward);
        if(Physics.Raycast(forwardRay, out raycastHit, blockDistance))
        {
            if(raycastHit.transform == selection)
            {
                lookForward();
                iTween.MoveTo(gameObject, iTween.Hash("position", selection.position, "time", movementDuration, "easetype", iTween.EaseType.linear, "delay", 0f));
            }
        }
        #endregion

        #region Right Ray
        Ray rightRay = new Ray(transform.position, transform.right);
        if(Physics.Raycast(rightRay, out raycastHit, blockDistance))
        {
            if(raycastHit.transform == selection)
            {
                lookRight();
                iTween.MoveTo(gameObject, iTween.Hash("position", selection.position, "time", movementDuration, "easetype", iTween.EaseType.linear, "delay", rotationDuration));
            }
        }
        #endregion

        #region Backward Ray
        Ray backwardRay = new Ray(transform.position, -transform.forward);
        if(Physics.Raycast(backwardRay, out raycastHit, blockDistance))
        {
            if(raycastHit.transform == selection)
            {
                lookBackward();
                iTween.MoveTo(gameObject, iTween.Hash("position", selection.position, "time", movementDuration, "easetype", iTween.EaseType.linear, "delay", rotationDuration));
            }
        }
        #endregion

        #region Left Ray
        Ray leftRay = new Ray(transform.position, -transform.right);
        if(Physics.Raycast(leftRay, out raycastHit, blockDistance))
        {
            if(raycastHit.transform == selection)
            {
                lookLeft();
                iTween.MoveTo(gameObject, iTween.Hash("position", selection.position, "time", movementDuration, "easetype", iTween.EaseType.linear, "delay", rotationDuration));
            }
        }
        #endregion
    }

    void lookForward(){
        iTween.RotateTo(gameObject, iTween.Hash("rotation", new Vector3(0f, transform.rotation.eulerAngles.y, 0f), "time", rotationDuration, "easetype", iTween.EaseType.linear));
    }

    void lookRight(){
        iTween.RotateTo(gameObject, iTween.Hash("rotation", new Vector3(0f, transform.rotation.eulerAngles.y + 90f, 0f), "time", rotationDuration, "easetype", iTween.EaseType.linear));
    }

    void lookBackward(){
        iTween.RotateTo(gameObject, iTween.Hash("rotation", new Vector3(0f, transform.rotation.eulerAngles.y + 180f, 0f), "time", rotationDuration, "easetype", iTween.EaseType.linear));
    }

    void lookLeft(){
        iTween.RotateTo(gameObject, iTween.Hash("rotation", new Vector3(0f, transform.rotation.eulerAngles.y - 90f, 0f), "time", rotationDuration, "easetype", iTween.EaseType.linear));
    }
}

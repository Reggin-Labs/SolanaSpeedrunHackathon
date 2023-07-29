using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 4f, Color.red);
    }

    public void triggerMovement(Transform selection)
    {
        RaycastHit raycastHit;

        #region Forward Ray
        Ray forwardRay = new Ray(transform.position, transform.forward);
        if(Physics.Raycast(forwardRay, out raycastHit, 4f))
        {
            if(raycastHit.transform == selection)
            {
                transform.position = selection.position;
            }
            Debug.Log(raycastHit.transform.name);
        }
        #endregion
    }
}

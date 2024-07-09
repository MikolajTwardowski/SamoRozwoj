using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbingTool : MonoBehaviour
{
    [SerializeField] int groundLayer;
    Camera camera;
    Ray ray;
    RaycastHit hitInfo;
    IGrabbable grabbableObject;
    IHoverable hoverableObject;

    bool isHovering = false;
    bool isGrabbing = false;

    private void Start() 
    {
        camera = Camera.main;
    }

    private void Update() 
    {
        ray = camera.ScreenPointToRay(Input.mousePosition);

        if(Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hitInfo, 100))
        {
            if(hitInfo.transform.gameObject.TryGetComponent<IGrabbable>(out grabbableObject))
            {
                grabbableObject.OnGrabEnter();
                isGrabbing = true;
                //Debug.Log("GrabEnter");
            }
            return;
        }

        if(Input.GetMouseButton(0) && isGrabbing)
        {
            if(Physics.Raycast(ray, out hitInfo, 100, groundLayer))
            {
                grabbableObject.OnGrab(hitInfo.point + Vector3.up);
                //Debug.Log("OnGrab");
            }
            else
            {
                //Vector3 virtualPoint = camera.ScreenToWorldPoint(Input.mousePosition);
                //virtualPoint.z = virtualPoint.y;
                //virtualPoint.y = 1f;
                //grabbableObject.OnGrab(virtualPoint);
                //Debug.Log(Input.mousePosition + " mousePos");
                //Debug.Log(virtualPoint + " VP");
            }
            return;
        }

        if(Input.GetMouseButtonUp(0) && isGrabbing) // rzucanie w zależności od odległości myszki od obiektu?
        {
            grabbableObject.OnGrabExit();
            isGrabbing = false;
            //Debug.Log("GrabExit");
            return;
        }

        if(Physics.Raycast(ray, out hitInfo, 100))
        {
            if(hitInfo.transform.gameObject.TryGetComponent<IHoverable>(out hoverableObject) && !isHovering)
            {
                hoverableObject.OnHoverEnter();
                isHovering = true;
            }
        }
        else if(Physics.Raycast(ray, out hitInfo, 100))
        {
            
        }

        else if(!Physics.Raycast(ray, out hitInfo, 100) && isHovering) // jebie się przy przechodzeniu z hovera na hovera bo zmienia się obiekt hoverowania a boole się nie zmieniają
        {
            if(hoverableObject != null)
                hoverableObject.OnHoverExit();
            isHovering = false;
        }

    }
}

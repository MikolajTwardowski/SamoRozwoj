using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    Camera mainCam;
    Vector3 direction;
    Vector3 wordPoint;
    
    //[SerializeReference] float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        UppdateMouseWordPosition();
        UppdateDirection();
    }

    private void FixedUpdate() {
        if(Input.GetMouseButton(0))
            FollowCursor();
    }

    void FollowCursor()
    {
        //rb.velocity = direction;
        
    }


    void UppdateMouseWordPosition()
    {
        
        //mouseWordPosition = mainCam.ScreenToWorldPoint(Input.mousePosition);
        // mouseWordPosition.y = 0;
    }

    void UppdateDirection()
    {
        //direction = mouseWordPosition - transform.position;
        direction.y = 0;
    }

    void LookAtCursor()
    {
        //transform.LookAt(mouseWordPosition);
    }
}

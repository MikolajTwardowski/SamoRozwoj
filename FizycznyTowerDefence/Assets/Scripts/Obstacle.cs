using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Obstacle : MonoBehaviour, IGrabbable, IHoverable
{
    bool dragging = false;
    Vector3 direction;
    Rigidbody rb;

    [SerializeField] float speed = 1f;
    [SerializeField] float throwFactor = 1f;

    public void OnGrab()
    {
        //direction = Vector3 .zero;
    }
    public void OnGrab(Vector3 point)
    {
        direction = point - transform.position;
    }

    public void OnGrabEnter()
    {
        dragging = true;
    }

    public void OnGrabExit()
    {
        rb.AddForce(direction * Vector3.Magnitude(direction) * throwFactor);
        dragging = false;
    }

    public void OnHoverEnter()
    {
        Debug.Log(this.name + " podświetlony!");
    }

    public void OnHoverExit()
    {
        Debug.Log(this.name + " przestał być podświetlany!");
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dragging)
        {
            //transform.position += direction;
            rb.velocity = direction * speed;
        }
    }
}

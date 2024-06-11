using UnityEngine;

public interface IGrabbable
{
    public void OnGrabEnter();
    public void OnGrab();
    public void OnGrab(Vector3 point);
    public void OnGrabExit();
}

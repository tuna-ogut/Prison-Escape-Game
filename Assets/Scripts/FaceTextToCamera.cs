using UnityEngine;

public class FaceTextToCamera : MonoBehaviour
{
    
    //In case that camera might rotate or move in the future Text aligns itself towards the camera
    //rather that just locking it in its axises.
    void Update()
    {
        transform.forward = Camera.main.transform.forward;
    }
}

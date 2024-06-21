using System;

using UnityEngine;

public class InteractableDoor : MonoBehaviour
{
    [SerializeField] int doorID;
    //[SerializeField] private HingeJoint hinge;
    //I could act as if left and right pices are the same but I tought that in the future it could add extra functionality
    [SerializeField] private GameObject leftDoorMesh;
    [SerializeField] private GameObject rightDoorMesh;
    
    private void Start()
    {
        leftDoorMesh.GetComponent<HingeJoint>().useLimits = true;
        rightDoorMesh.GetComponent<HingeJoint>().useLimits = true;
        SetColor();
    }

    // Update is called once per frame
    void SetColor()
    {
        Renderer leftRenderer = leftDoorMesh.GetComponent<Renderer>();
        Renderer rightRenderer = rightDoorMesh.GetComponent<Renderer>();
        //I check left and right door seperately, maybe in the future it can be used as a feature
        //such as key managing; choosing which door to enter to save some colored keys and dispense other colored key
        //Notice we would need two ID's at the top for this purpose
        //Also collider used should be changed and seperate colliders for each door should be used as a trigger
        if (leftRenderer != null)
        {
            leftRenderer.material.color = ColorManager.Instance.GetColor(doorID);
        }
        if (rightRenderer != null)
        {
            rightRenderer.material.color = ColorManager.Instance.GetColor(doorID);
        }
    }

    private void OpenDoor(Collider playerCollider)
    {
        Player player = playerCollider.GetComponent<Player>();

        if (player.HasKey(doorID))
        {
            Debug.Log("Entered");
            //The following also will need to change if player can choose which door to enter
            leftDoorMesh.GetComponent<HingeJoint>().useLimits = false;
            rightDoorMesh.GetComponent<HingeJoint>().useLimits = false;
            player.DecrementKey(doorID);
            //AND OPEN THE DOOR
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            OpenDoor(other);
        }
    }
}

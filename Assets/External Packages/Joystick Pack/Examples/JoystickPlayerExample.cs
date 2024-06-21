
using System;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    //speed is not necessary since I am using animations root motion.
    //public float speed;
    public FixedJoystick fixedJoystick;
    public Rigidbody rb;
    //private bool isControlEnabled = true;
    
    private void Start()
    {
        rb.freezeRotation= true; // When a collision occurs there is a spin movement this line is to avoid that.
    }
    
    public void FixedUpdate()
    {
            Vector3 direction = Vector3.forward * fixedJoystick.Vertical + Vector3.right * fixedJoystick.Horizontal;
            
            //The below part is not necessary since I am using animations root motion.
            //rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
            
            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(direction);
            }
    }
}

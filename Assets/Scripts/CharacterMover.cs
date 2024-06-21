using UnityEngine;


//This Script decides if both player and enemy is moving. Enemy and Player can be seperated on different
//Scripts however since this is a very short script and Enemy has another script that controls Patrol 
//Movement, The script is let combined deliberately
public class CharacterMover : MonoBehaviour
{

    protected Animator animator;
    private bool isMoving = false;
    bool isCaught = false;
    [SerializeField] private FixedJoystick joystick;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        Move();
        animator.SetBool("isRunning", isMoving);
    }

    void Move()
    {
        if (gameObject.tag == "Player")
        {
            //FREEZE if caught for player. 
            //isCaught could be included in the if statement above. However, because in a boolean
            //expression with the && operator, if the first condition is false, the rest are not
            //evaluated, there is no significant performance impact.
            isMoving =  (!isCaught) && (joystick.Vertical != 0 || joystick.Horizontal != 0);
        }
        else if (gameObject.tag == "Enemy")
        {
            //Didnt find any conditions to check but might be needed in future so I let it here
        }
    }
    
    //This function is for enemy. 
    public void SetIsMoving(bool moving)
    {
        isMoving = moving;
        animator.SetBool("isRunning", isMoving);
    }

    //this function is for player
    public void SetIsCaught(bool caught)
    {
        isCaught = caught;
    }
}

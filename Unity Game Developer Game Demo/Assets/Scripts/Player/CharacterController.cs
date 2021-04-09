using UnityEngine;
/// <summary>
/// Main controller for both the playerss
/// </summary>
public class CharacterController : MonoBehaviour
{
    //check for whether the player is on the ground or not
    private bool _isGrounded;
    
    //reference to the rigidbody
    private Rigidbody2D _rigidbody;
    
    //variable to store the amount of jumps that the player has
    private int _jumpCount;
    
    //id to sort through both of the players easier
    public int id;
    
    //force that helps the player jump
    public float jumpForce;
    
    //Layer mask for the check if the player is on the ground
    public LayerMask groundMask;
    
    //Array of the transforms for the ground checks, I use two on both legs of the character, in case it ends up in weird position but is still alive
    public Transform[] groundCheck;
    
    //radius that is required to check if the player is near the ground or not
    public float groundCheckRadius;
    
    private void Start()
    {
        //get reference to the torso's rigidbody
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //for all of the transforms in the groundcheck array, the bool is set whether we have at least one foot on the ground
        foreach (Transform ground in groundCheck)
        {
            _isGrounded = Physics2D.OverlapCircle(ground.position, groundCheckRadius, groundMask);
        }
    }

    /// <summary>
    /// Jump method that is being called on the buttons that are hidden over the players, applies force to make them jump
    /// </summary>
    public void Jump()
    {
        if (_jumpCount < 1)
        {
            _rigidbody.AddForce(Vector2.up * jumpForce);
            _jumpCount++;
        }
        
        if (_isGrounded)
        {
            _jumpCount = 0;
        }
    }
    
}
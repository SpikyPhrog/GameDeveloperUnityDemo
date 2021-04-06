using System;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private bool _isGrounded;
    private Rigidbody2D _rigidbody;
    private int _jumpCount;
    public int id;
    
    public float jumpForce;
    public Vector2 jumpHeight;
    public LayerMask groundMask;
    public Transform[] groundCheck;
    public float groundCheckRadius;
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        foreach (Transform ground in groundCheck)
        {
            _isGrounded = Physics2D.OverlapCircle(ground.position, groundCheckRadius, groundMask);
        }
    }

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

using UnityEngine;
/// <summary>
/// Class that keeps the players standing on their feet
/// </summary>
public class Balance : MonoBehaviour
{
    //setting the rotation that the joints should rotate at
    public float targetRotation;
    //modifier for how often the joints are rotated
    public float force;
    //reference to the rigidbody of the object that needs to keep balance
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        //get the rigidbody of the object that holds this script
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //every frame set the rotation of the joint with lerp between the current rotation and the given rotation
        _rigidbody.MoveRotation(Mathf.Lerp(_rigidbody.rotation, targetRotation, force * Time.fixedDeltaTime));
    }
}

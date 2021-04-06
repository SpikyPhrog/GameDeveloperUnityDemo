using UnityEngine;

public class Balance : MonoBehaviour
{
    public float targetRotation;
    public float force;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _rigidbody.MoveRotation(Mathf.Lerp(_rigidbody.rotation, targetRotation, force * Time.fixedDeltaTime));
    }
}

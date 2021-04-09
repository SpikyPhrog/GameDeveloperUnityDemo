using UnityEngine;

public class Bazooka : MonoBehaviour
{
    //Transform for the  point from where the rockets will be spawning
    public Transform firePoint;
    //The rocket's Prefab
    public GameObject rocketPrefab;
    //The speed that the rocket will travel with
    public float velocity;
    //The direction of the rocket
    public Vector2 direction;
    
    /// <summary>
    /// Method that will be called upon pressing the buttons on the UI to shoot if we have equipped bazooka.
    /// It instantiates the rocket and then sets the velocity and the direction of the rigidbody
    /// </summary>
    public void Fire()
    {
        GameObject bullet = Instantiate(rocketPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * velocity;
    }
}

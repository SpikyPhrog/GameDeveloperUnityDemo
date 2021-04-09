using UnityEngine;
/// <summary>
/// Singleton class, good practice to have only one singleton in the project, since it takes a while to load first the static classes and then the rest of the stuff.
/// Keeps references of a lot of classes that are used all over the place in once neat class.
/// </summary>
public class MasterSingleton : MonoBehaviour
{
    public static MasterSingleton Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public GameManager GameManager;
    public UIManager UIManager;
    public SoundManager SoundManager;

}

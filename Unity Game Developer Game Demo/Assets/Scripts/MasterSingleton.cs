using UnityEngine;

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

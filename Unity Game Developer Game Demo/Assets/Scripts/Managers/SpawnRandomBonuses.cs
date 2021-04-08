using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnRandomBonuses : MonoBehaviour
{
    public GameObject[] bonuses;
    
    private float _dropDuration;
    private float _waitDuration;
    private void Start()
    {
        _dropDuration = 5f;
        _waitDuration = 7f;
    }

    private void Update()
    {
        if (_waitDuration <= 0)
        {
            _dropDuration = 5f;
            _waitDuration = 7f;
            SpawnDrop(bonuses);
        }
        else
        {
            _dropDuration -= Time.deltaTime;
            _waitDuration -= Time.deltaTime;
        }

        if (MasterSingleton.Instance.UIManager.itemDuration != null)
        {
            MasterSingleton.Instance.UIManager.itemDuration.text = ((int) _dropDuration).ToString();
        }

    }

    void SpawnDrop(GameObject[] drops)
    {
        MasterSingleton.Instance.SoundManager.PlaySound(SoundEvents.DropSpawn);
        GameObject drop = Instantiate(drops[Random.Range(0, drops.Length)], transform);
        MasterSingleton.Instance.UIManager.itemDuration = drop.GetComponent<DisplayDuration>().duration;
        Destroy(drop, _dropDuration); 
    }
}

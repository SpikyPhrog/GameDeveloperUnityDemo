using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnRandomBonuses : MonoBehaviour
{
    public GameObject[] bonuses;

    private float _lastTimeDropped;
    private float _firstInterval;
    private void Start()
    {
        
        StartCoroutine(nameof(DropRandomBonus));
    }

    IEnumerator DropRandomBonus()
    {
        while (true)
        {
            _firstInterval = Random.Range(0f, 5f);
            SpawnDrop(bonuses);
            _lastTimeDropped += _firstInterval;
            yield return new WaitForSeconds(_lastTimeDropped);
        }
    }

    void SpawnDrop(GameObject[] drops)
    {
        Instantiate(drops[Random.Range(0, drops.Length)], transform);
    }
}

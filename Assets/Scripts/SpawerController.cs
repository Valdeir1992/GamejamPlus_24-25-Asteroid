using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawerController: MonoBehaviour
{
    [SerializeField] private GameObject[] _asteroidPrefabs;
    [SerializeField] private AsteroidWave[] _waves;
    [SerializeField] private float _radius;

    private void Start()
    {
        StartCoroutine(Coroutine_StartSpawn(_waves[0]));
    }

    private IEnumerator Coroutine_StartSpawn(AsteroidWave wave)
    {
        int count = 0;
        bool start = true;
        while(count < wave.Amount)
        {
            Vector3 pos = Vector3.zero;
            if (start)
            {
                start = false;
                for (int index = 0; index < wave.StartAmount; index++)
                {
                    pos = Random.insideUnitCircle * _radius;
                    Instantiate(_asteroidPrefabs[Random.Range(0, _asteroidPrefabs.Length)], pos, Quaternion.identity);
                } 
            }
            pos = Random.insideUnitCircle * _radius;
            Instantiate(_asteroidPrefabs[Random.Range(0, _asteroidPrefabs.Length)], pos, Quaternion.identity);
            yield return new WaitForSeconds(wave.SpawnTime);
            count++;
        }
    }
}
[System.Serializable]
public class AsteroidWave
{
    public float SpawnTime;
    public int Amount;
    public int StartAmount;
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class SpawerController: MonoBehaviour
{
    [SerializeField] private AsteroidBehaviour _asteroidPrefab;
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
        Vector3 randomPos = default;
        while(count < wave.Amount)
        {
            Vector3 pos = new Vector3(Random.Range(-1,1f),Random.Range(-1,1),0)*_radius/2;
            if (start)
            {
                start = false;
                for (int index = 0; index < wave.StartAmount; index++)
                {
                    randomPos = Random.insideUnitCircle * _radius;
                    pos += new Vector3(randomPos.x,randomPos.y,0);
                    AsteroidBehaviour startAsteroid = Instantiate(_asteroidPrefab, pos, Quaternion.identity);
                    startAsteroid.SetupAsteroid((AsteroidSize)Random.Range(0, 3));
                } 
            }
            randomPos = Random.insideUnitCircle * _radius;
            pos += new Vector3(randomPos.x, randomPos.y, 0);
            var asteroid = Instantiate(_asteroidPrefab, pos, Quaternion.identity);
            asteroid.SetupAsteroid((AsteroidSize)Random.Range(0, 3)); 
            yield return new WaitForSeconds(wave.SpawnTime);
            count++;
        }
        yield return new WaitForSeconds(20);
        yield return Coroutine_StartSpawn(_waves.OrderBy(x => Guid.NewGuid()).First());
    }
} 
[System.Serializable]
public class AsteroidWave
{
    public float SpawnTime;
    public int Amount;
    public int StartAmount;
}

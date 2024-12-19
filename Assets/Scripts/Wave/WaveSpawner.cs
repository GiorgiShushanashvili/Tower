using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] Wave[] _waves;
    [SerializeField] private Transform _cube;
    [SerializeField] private Transform _parent;

    private Wave _currentWave;
    //private List<ZombieParent> zombies;
    private float timeBFRWave;
    private float _radiusForSpawning = 5f;
    private float _spawnedZombies = 0;
    private float _zombiesToSpawn;
    private int i = 0;

    private bool _nextWave;

    private void Awake()
    {
        _currentWave=_waves[i];
        timeBFRWave=_currentWave._timeBeforeWave;
        StartCoroutine(SpawnEnemy());
        foreach(float number in _currentWave._numberToSpawn)
        {
            _zombiesToSpawn += number;
        }
    }

    private Vector3 SpawnHelper()
    {
        float randomAngle = Random.Range(0f, 360f);
        float randomX = _radiusForSpawning * Mathf.Cos(randomAngle);
        float randomZ = _radiusForSpawning * (Mathf.Sin(randomAngle));

        Vector3 spawnPoint = new Vector3(randomX, 0, randomZ);

        return spawnPoint;
    }

    private IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(_currentWave._timeBeforeWave);
        while (_zombiesToSpawn > _spawnedZombies)
        {
            Vector3 spawnPoint = SpawnHelper();

            Vector3 dirToCube = (_cube.position - spawnPoint).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(dirToCube);

            if (_spawnedZombies == _currentWave._range[0])
            {
                switch (_currentWave._numberToSpawn[0])
                {
                    case > 0f:
                        if (_currentWave._numberToSpawn[1] > 0)
                        {
                            int num = Random.Range(0, _currentWave._enemyPrefabs.Length);
                            var enemy =Instantiate(_currentWave._enemyPrefabs[num], spawnPoint, targetRotation);
                            if (enemy.type == ZombieType.Warrior)
                            {
                                Debug.Log("walker pirveli");
                                _currentWave._numberToSpawn[0]--;
                            }
                            else
                            {
                                Debug.Log("shooter pirveli");
                                _currentWave._numberToSpawn[1]--;
                            }
                        }
                        else
                        {
                            Debug.Log("walker meore");
                            Instantiate(_currentWave._enemyPrefabs[0].gameObject, spawnPoint, targetRotation);
                            _currentWave._numberToSpawn[0]--;
                        }
                        break;

                    case 0f:
                        if (_currentWave._numberToSpawn[1] > 0)
                        {
                            Debug.Log("shooter bolo");
                            Instantiate(_currentWave._enemyPrefabs[1].gameObject, spawnPoint, targetRotation);
                            _currentWave._numberToSpawn[1]--;
                        }
                        break;

                }
            }
            else
            {
                Debug.Log("walkkr   bolo");
                Instantiate(_currentWave._enemyPrefabs[0].gameObject, spawnPoint, targetRotation);
                _currentWave._numberToSpawn[0]--;

            }
            _spawnedZombies++;

            if (_spawnedZombies == _zombiesToSpawn)
            {
                i++;
                _currentWave = _waves[i];
                break;
            }
            yield return new WaitForSeconds(_currentWave._timeIntervalBetweenZombies);
        }
    }


    void ManageWave()
    {
        i++;
        if (i<_waves.Length)
        {
            _currentWave = _waves[i];
        }
        else
        {
            //you win
        }
    }

}

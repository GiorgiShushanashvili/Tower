using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] Wave[] _waves;
    [SerializeField] private Transform _cube;
    [SerializeField] private Transform _parent;

    private Wave _currentWave;
    private float timeBFRWave;
    private float _radiusForSpawning = 5f;
    private float _createdZombies = 0;
    private float _zombiesToSpawn;
    private int i = 0;

    private bool _isSpawning = false;

    private List<int> nums=new List<int>();

    private bool _nextWave;

    private void Start()
    {
        _currentWave=_waves[i];
        _currentWave.StartMethod();
        StartCoroutine(SpawnWave());
        foreach(var number in _currentWave._numberToSpawn)
        {
            nums.Add(number);
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

    private IEnumerator SpawnWave()
    {
        if (_isSpawning)
            yield break;
        _isSpawning = true;

        yield return new WaitForSeconds(_currentWave._timeBeforeWave);
        while (_createdZombies < _zombiesToSpawn)
        {
            Vector3 spawnPoint = SpawnHelper();

            Vector3 dirToCube = (_cube.position - spawnPoint).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(dirToCube);

            SpawnZombie(spawnPoint,targetRotation);

            if (_createdZombies == _zombiesToSpawn &&i+1<_waves.Length)
            {
                InitializeWaveData();
                //break;
            }
            else if (_createdZombies == _zombiesToSpawn && i + 1 == _waves.Length)
            {
                break;
            }
            yield return new WaitForSeconds(_currentWave._timeIntervalBetweenZombies);
        }
        _isSpawning = false;
        Debug.Log("korutine damtavrda");
    }


    private void SpawnZombie(Vector3 spawnPoint,Quaternion targetRotation)
    {
        if (_createdZombies >= _currentWave._range[0])
        {
            switch (nums[0])
            {
                case > 0:
                    if (nums[1] > 0)
                    {
                        int num = Random.Range(0, _currentWave._enemyPrefabs.Length);
                        var enemy = Instantiate(_currentWave._enemyPrefabs[num], spawnPoint, targetRotation);
                        _createdZombies++;
                        if (enemy.tag == "Zombie")
                        {
                            nums[0]--; ;
                        }
                        else if (enemy.tag == "ShooterZombie")
                        {
                            nums[1]--;
                        }
                    }
                    else
                    {
                        Instantiate(_currentWave._enemyPrefabs[0].gameObject, spawnPoint, targetRotation);
                        nums[0]--;
                        _createdZombies++;
                    }
                    break;

                case 0:
                    if (nums[1]-- > 0)
                    {
                        Instantiate(_currentWave._enemyPrefabs[1].gameObject, spawnPoint, targetRotation);
                        nums[1]--;
                        _createdZombies++;
                    }
                    break;

            }
        }
        else
        {
            Instantiate(_currentWave._enemyPrefabs[0].gameObject, spawnPoint, targetRotation);
            nums[0]--;
            _createdZombies++;
        }
    }

    private void InitializeWaveData()
    {
        i++;
        _currentWave = _waves[i];
        _currentWave.StartMethod();
        nums.Clear();
        _zombiesToSpawn = 0;
        _createdZombies = 0;
        Debug.Log(_currentWave.name);
        foreach (var number in _currentWave._numberToSpawn)
        {
            nums.Add(number);
            _zombiesToSpawn += number;
        }
        Debug.Log(_zombiesToSpawn);
        StopCoroutine(SpawnWave());
        //StartCoroutine(SpawnWave());
        //break;
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

    /*private void OnDisable()
    {
        _currentWave._numberToSpawn[i]  = _originalWave._numberToSpawn[i];
    }*/
}

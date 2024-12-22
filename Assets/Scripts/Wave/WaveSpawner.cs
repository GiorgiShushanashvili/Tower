using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _waveNumber;
    [SerializeField] Wave[] _waves;
    [SerializeField] private Transform _cube;
    [SerializeField] private Transform _parent;

    private Wave _currentWave;
    private float _radiusForSpawning = 5f;
    private float _createdZombies;
    private float _zombiesToSpawn;
    private int i = 0;
    private List<int> nums=new List<int>();


    private void Start()
    {
        _waveNumber.alpha = 0f;
        StartCoroutine(SpawnWave());
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
        while(i< _waves.Length)
        {
            _currentWave = _waves[i];
            _currentWave.StartMethod();
            nums.Clear();
            _zombiesToSpawn = 0;
            _createdZombies = 0;
            CriticalAreaHandler._killedZombiesInWave = 0;
            foreach (var number in _currentWave._numberToSpawn)
            {
                nums.Add(number);
                _zombiesToSpawn += number;
            }
            yield return new WaitForSeconds(_currentWave._timeBeforeWave);
            StartCoroutine(ShowWaveMessage(i+1));

            while (_createdZombies < _zombiesToSpawn)
            {
                Vector3 spawnPoint = SpawnHelper();

                Vector3 dirToCube = (_cube.position - spawnPoint).normalized;
                Quaternion targetRotation = Quaternion.LookRotation(dirToCube);

                SpawnZombie(spawnPoint, targetRotation);
                yield return new WaitForSeconds(_currentWave._timeIntervalBetweenZombies);
            }

            yield return new WaitUntil(() => CriticalAreaHandler._killedZombiesInWave == _createdZombies);
            CoinBonusManager.instance.AddCoinsByDefeatingWave();
            i++;
            if (i == _waves.Length)
            {
                Debug.Log("game finished");
            }
        }
    }

    IEnumerator ShowWaveMessage(int numberOfWave)
    {
        _waveNumber.text = "Wave " + numberOfWave;
        StartCoroutine(FadeTextAlpha(1));
        yield return new WaitForSeconds(2.5f);
        StartCoroutine(FadeTextAlpha(0));
    }

    private IEnumerator FadeTextAlpha(float targetAlpha)
    {
        float startAlpha=_waveNumber.color.a;
        float elaped = 0f;
        float duration = 1f;
        while (elaped < duration)
        {
            elaped += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, elaped / duration);
            _waveNumber.alpha = alpha;
            yield return null;
        }
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
}

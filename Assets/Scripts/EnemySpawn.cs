using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private Transform _cube;
    [SerializeField] private Transform _parent;
    [SerializeField] private GameObject _walkingZombie;
    [SerializeField] private GameObject _zombieWithPistol;

    private float _radiusForSpawning =5f;

    private int _counter;

    void Start()
    {
        _counter = 0;
        StartCoroutine(SpawnEnemy());       
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
        while (true)
        {

            Vector3 spawnPoint=SpawnHelper();

            Vector3 dirToCube = (_cube.position - spawnPoint).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(dirToCube);

            GameObject enemy= Instantiate(_walkingZombie, spawnPoint, targetRotation);
            _counter++;
            if (_counter == 3)
            {
                Vector3 spawnPointForPistolZombie = SpawnHelper();

                Vector3 dirToCubeForPistolZombie = (_cube.position - spawnPointForPistolZombie).normalized;
                Quaternion targetRotationForPistolZombie = Quaternion.LookRotation(dirToCubeForPistolZombie);

                GameObject pistolZombie = Instantiate(_zombieWithPistol, spawnPointForPistolZombie, targetRotationForPistolZombie);
                pistolZombie.transform.SetParent(_parent);
                _counter = 0;
            }
            enemy.transform.SetParent(_parent);
            yield return new WaitForSeconds(1.8f);
        }
    }
}

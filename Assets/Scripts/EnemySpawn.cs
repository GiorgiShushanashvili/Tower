using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Transform _cube;
    [SerializeField] private Transform _parent;
    [SerializeField] private GameObject _zombieTypes;

    private float _radiusForSpawning =2f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            //GameObject gameObject = _zombieTypes[Random.Range(0, _zombieTypes.Length)];
            Transform spawPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];

            Vector3 randomSpawnPoint = new Vector3(spawPoint.position.x + Random.Range(-_radiusForSpawning, _radiusForSpawning), 0,
                spawPoint.position.z + Random.Range(-_radiusForSpawning, _radiusForSpawning));

            Vector3 dirToCube = (_cube.position - randomSpawnPoint).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(dirToCube);

            GameObject enemy= Instantiate(_zombieTypes, randomSpawnPoint, targetRotation);
            enemy.transform.SetParent(_parent);
            yield return new WaitForSeconds(2f);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject LevelTile;
    [SerializeField] private Transform _parent;
    [SerializeField] private GameObject _player;

    private Rigidbody _rb;

    float _heightDelta = 0.1f;

    List<GameObject> levels = new List<GameObject>();


    private void Start()
    {
        GameObject firstTile = Instantiate(LevelTile, new Vector3(0, levels.Count, 0), Quaternion.identity);
        firstTile.transform.SetParent(_parent);
        levels.Add(firstTile);
        _heightDelta = LevelTile.transform.localScale.y;
        Instantiate(_player,new Vector3(0,_heightDelta,0),Quaternion.identity);

        Time.timeScale = 1.0f;
    }

    void AddTile()
    {
        GameObject tile = Instantiate(LevelTile, new Vector3(0, levels.Count * _heightDelta, 0), Quaternion.identity);
        tile.transform.SetParent(_parent);

        levels.Add(tile);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            AddTile();
        }*/
        if (TowerHealth.towerHealth.Die())
        {
            ReduceTile();
            TowerHealth.towerHealth.RefreshLife();
        }
        if (levels.Count == 0)
        {
            GameOver();
        }

    }

    public void ReduceTile()
    {
        GameObject firstTile = levels[0];
        levels.RemoveAt(0);
        Destroy(firstTile);
    }

    private void GameOver()
    {
        Time.timeScale =0f;
    }
    
    
}

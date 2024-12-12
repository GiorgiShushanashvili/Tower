using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject LevelTile;
    [SerializeField] private Transform _parent;
    [SerializeField] private GameObject _player;

     MeshRenderer _renderer;
     MeshRenderer _renderer2;
    private Rigidbody _rb;

    float _heightDelta = 0.1f;

    List<GameObject> levels = new List<GameObject>();


    private void Start()
    {

        GameObject firstTile = Instantiate(LevelTile, new Vector3(0, levels.Count, 0), Quaternion.identity);

        BlockItemClass blockItem = firstTile.GetComponent<BlockItemClass>();
        _renderer = blockItem.CylinderTop.GetComponent<MeshRenderer>();
        _renderer2 = blockItem.CylinderMain.GetComponent<MeshRenderer>();

        firstTile.transform.SetParent(_parent);
        levels.Add(firstTile);
        _heightDelta = (_renderer.bounds.size.y + _renderer2.bounds.size.y);
        GameObject player= Instantiate(_player,new Vector3(0,_heightDelta,0),Quaternion.identity);
        player.transform.SetParent(firstTile.transform);
    }

    void AddTile()
    {
        foreach (var level in levels)
        {
            level.transform.position = new Vector3(level.transform.position.x, level.transform.position.y + _heightDelta, level.transform.position.z);
        }
        GameObject tile = Instantiate(LevelTile, new Vector3(0,0, 0), Quaternion.identity);
        tile.transform.SetParent(_parent);
        levels.Add(tile);
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //AddTile();
        }
        if (TowerHealth.towerHealth.Die())
        {
            ReduceTile();
            TowerHealth.towerHealth.RefreshLife();
        }
        if (levels.Count == 0)
        {
            AddTile();
            GameManager.Instance.GameOver();
        }

    }

    public void ReduceTile()
    {
        foreach (var level in levels)
        {
            level.transform.position = new Vector3(level.transform.position.x, level.transform.position.y - _heightDelta, level.transform.position.z);
        }
        GameObject firstTile = levels[levels.Count-1];
        levels.Remove(firstTile);
        Destroy(firstTile);
    }
    
    
}

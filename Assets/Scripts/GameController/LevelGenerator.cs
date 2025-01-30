using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using static Enums;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject LevelTile;
    [SerializeField] private Transform _parent;
    [SerializeField] private Player _player;

    //[SerializeField] private ObjectClones objectClone;

    private Player objPLayer;

    private Player obj;
    public Player Obj { get => obj; }


    public GameObject secondPistol
    {
        get => obj.secondPistol;
        set=> obj.secondPistol = value;
    }
    

    MeshRenderer _renderer;
    MeshRenderer _renderer2;
    private Rigidbody _rb;

    float _heightDelta = 0.1f;

    List<GameObject> levels = new List<GameObject>();


    private void Awake()
    {
        GameObject firstTile = Instantiate(LevelTile, new Vector3(0, levels.Count, 0), Quaternion.identity);
        BlockItemClass blockItem = firstTile.GetComponent<BlockItemClass>();
        levels.Add(firstTile);

        _renderer = blockItem.CylinderTop.GetComponent<MeshRenderer>();
        _renderer2 = blockItem.CylinderMain.GetComponent<MeshRenderer>();

        _heightDelta = (_renderer.bounds.size.y + _renderer2.bounds.size.y);
        obj = Instantiate(_player, new Vector3(0, _heightDelta, 0), Quaternion.identity);

        if (ObjectClones._player == null)
        {
            ObjectClones._player = obj;
        }
        obj.transform.SetParent(firstTile.transform);
        firstTile.transform.SetParent(_parent);
      
        _heightDelta = (_renderer.bounds.size.y + _renderer2.bounds.size.y);
    }

    /*private void ControlPLayerCondition()
    {
        if (BoostController.Instance.currentBoost == 0)
        {
            Debug.Log("sawyisia");
            obj.pLayerCondition = PLayerCondition.Standard;
            obj.secondPistol.SetActive(false);
        }
        if (BoostController.Instance.currentBoost == 2)
        {
            obj.pLayerCondition = PLayerCondition.FirstBoost;
            obj.secondPistol.SetActive(false);
        }
        if (BoostController.Instance.currentBoost == 4)
        {
            obj.secondPistol.SetActive(true);
            obj.pLayerCondition = PLayerCondition.SecondBoost;
        }
    }*/







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
    /*void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //AddTile();
        }
        if (TowerHealth.towerHealth.Die())
        {
            //ReduceTile();
            TowerHealth.towerHealth.RefreshLife();
        }
        if (levels.Count == 0)
        {
            AddTile();
            //GameManager.Instance.GameOver();
        }

    }*/

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public static TriggerZone Instance;

    public List<Transform> _zombies;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _zombies = new List<Transform>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zombie"))
        {
           
            _zombies.Add(other.transform);
        }
    }

    public void RemoveZombie()
    {
        _zombies.RemoveAt(0);
    }
}

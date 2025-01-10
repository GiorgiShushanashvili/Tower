using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ResistanceController : MonoBehaviour
{
    public static ResistanceController Instance;

    [SerializeField] Slider _slider;
    [SerializeField] TapController tapController;

    private float maxResistance;
    public float currentResistance;

    private float resistanceAdding=6f;
    public float resistanceReduce = 5f;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        maxResistance = GlobalVariables._maxTaps;
        currentResistance=0;
        _slider.maxValue = maxResistance;
        _slider.value = currentResistance;
    }

    private void Update()
    {
        ResistanceFilling();
    }


    public void ResistanceFilling()
    {
        if (currentResistance < maxResistance)
        {
            float resistanceToAdd = Mathf.Min(resistanceAdding, maxResistance - currentResistance);
            currentResistance = Mathf.MoveTowards(currentResistance, maxResistance, resistanceToAdd*Time.deltaTime);
            _slider.value = currentResistance;
        }
    }

    public void ResistanceReduce()
    {
        if (currentResistance > 0)
        {
            float resistanceToReduce= Mathf.Min(resistanceReduce, currentResistance - 0);
            currentResistance = currentResistance - resistanceToReduce;
            _slider.value = currentResistance;
        }
    }

    private void OnEnable()
    {
        tapController.OnPressed += ResistanceReduce;
    }

    private void OnDisable()
    {
        tapController.OnPressed -= ResistanceReduce;
    }
}

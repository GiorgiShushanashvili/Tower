using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ResistanceController : MonoBehaviour
{
    [SerializeField]
    Slider _slider;
    [SerializeField] TapController tapController;

    private float maxResistance;
    private float currentResistance;

    private float resistanceAdding=4f;

    private void Start()
    {
        maxResistance = GlobalVariables._maxTaps;
        currentResistance=0;
        _slider.maxValue = maxResistance;
        _slider.value = currentResistance;
    }

    private void Update()
    {
        test();
    }


    public void test()
    {
        if (currentResistance < maxResistance)
        {
            float resistanceToAdd = Mathf.Min(resistanceAdding, maxResistance - currentResistance);
            currentResistance = Mathf.MoveTowards(currentResistance, maxResistance, resistanceToAdd*Time.deltaTime);
            _slider.value = currentResistance;
        }
    }

    public void test1()
    {
        currentResistance = currentResistance - 5;
        Debug.Log(currentResistance);
        _slider.value = currentResistance;
    }

    private void OnEnable()
    {
        tapController.OnPressed += test1;
    }

    private void OnDisable()
    {
        tapController.OnPressed -= test1;
    }



    /*public void SetMaxResistance()
    {
        _slider.maxValue = maxResistance;
        _slider.value = currentResistance;
    }
     public void SetResistance()
    {
        _slider.value = currentResistance;
    }*/


    /*private IEnumerator IncreaseResistance()
    {
        while (true)
        {
            if (currentResistance < maxResistance)
            {

                float resistanceToAdd = Mathf.Min(resistanceAdding, maxResistance - currentResistance);
                Debug.Log(resistanceToAdd);
                currentResistance = currentResistance + resistanceToAdd * Time.deltaTime;
                currentResistance = Mathf.Lerp(currentResistance, maxResistance, currentResistance / maxResistance);
                if (currentResistance >= maxResistance)
                {
                    currentResistance = maxResistance;
                }
            }
            yield return new WaitForSecondsRealtime(0.01f);
        }
    }*/
}

using UnityEngine;
using UnityEngine.UI;

public class BoostController : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] TapController _tapController;

    private float maxBoost;
    private float currentBoost;

    private float boostReducer = 0.75f;
    private float boostIncr = 1f;

    private void Start()
    {
        currentBoost = 0f;
        maxBoost = 16f;
        slider.maxValue=maxBoost;
        slider.value=currentBoost;
    }

    private void Update()
    {
        ReduceBoost();
    }

    public void ReduceBoost()
    {
        if (currentBoost > 0)
        {
            float boostToReduce = Mathf.Min(boostReducer, currentBoost - 0);
            currentBoost = Mathf.MoveTowards(currentBoost, 0, boostToReduce * Time.deltaTime);
            slider.value = currentBoost;
        }
    }

    public void AddBoost()
    {
        if (currentBoost < maxBoost&&ResistanceController.Instance.currentResistance>=ResistanceController.Instance.resistanceReduce)
        {
            float boostToIncrease = Mathf.Min(boostIncr, maxBoost - currentBoost);
            currentBoost += boostIncr;
            slider.value = currentBoost;
        }
    }


    private void OnEnable()
    {
        _tapController.OnPressed += AddBoost;
    }

    private void OnDisable()
    {
        _tapController.OnPressed -= AddBoost;
    }
}

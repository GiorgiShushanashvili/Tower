using UnityEngine;
using UnityEngine.UI;
using static Enums;

public class BoostController : MonoBehaviour
{
    public static BoostController Instance;

    [SerializeField] Slider slider;
    [SerializeField] TapController _tapController;
    //[SerializeField] ObjectClones _objectClones;

    private float maxBoost;
    public float currentBoost=0;

    private float boostReducer = 0.35f;
    private float boostIncr = 0.5f;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

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
        ControlPlayerCodnition();
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


    private void ControlPlayerCodnition()
    {
        if (ObjectClones._player != null)
        {
            if (currentBoost <= 0.1f)
            {
                ObjectClones._player.pLayerCondition = PLayerCondition.Standard;
                //ObjectClones._player.secondPistol.SetActive(false);
            }
            if (currentBoost <= 2.2f&& currentBoost >= 1.8f)
            {
                ObjectClones._player.pLayerCondition = PLayerCondition.FirstBoost;
                ObjectClones._player.secondPistol.SetActive(false);
            }
            if (currentBoost>=3.8f&&currentBoost <= 4.2f)
            {
                ObjectClones._player.secondPistol.SetActive(true);
                ObjectClones._player.pLayerCondition = PLayerCondition.SecondBoost;
            }
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

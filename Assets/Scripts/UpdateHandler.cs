using UnityEngine;
using Unity.Mathematics;
using TMPro;

public class UpdateHandler : MonoBehaviour
{
    [SerializeField] GameData gameData;

    public float CalculateUpgrade(float minValue,float maxValue,float minUpgradeLevel,float maxUpgradeLevel,float currentLevel)
    {
        float result =math.remap(minUpgradeLevel,maxUpgradeLevel,minValue,maxValue,currentLevel);
        return result;
    }

    public void SetUpgrade(ref int curLvl,int maxLvl,float minValue,float maxValue,
        ref float ValueToSet,ref TextMeshProUGUI current,ref TextMeshProUGUI potential)
    {
        if (curLvl < maxLvl)
        {
            curLvl++;
            float predictedValue = CalculateUpgrade(minValue, maxValue, 0, maxLvl, curLvl+1);
            float upgrade = CalculateUpgrade(minValue, maxValue, 0, maxLvl, curLvl);
            ValueToSet = upgrade;

            current.text=upgrade.ToString();
            if(curLvl<maxLvl)
            {
                potential.text=predictedValue.ToString();
            }
            else
            {
                potential.text=upgrade+"max";
            }
        }
    }
    
}

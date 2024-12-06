using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePanelController : MonoBehaviour
{
    [SerializeField] GameObject _attackPanel;
    [SerializeField] GameObject _defensePanel;
    [SerializeField] GameObject _bonusPanel;

    private void Start()
    {
        _attackPanel.SetActive(true);
        _defensePanel.SetActive(false);
        _bonusPanel.SetActive(false);
    }

    public void TransToDefensePanel()
    {
        _attackPanel.SetActive(false);
        _defensePanel.SetActive(true);
        _bonusPanel.SetActive(false);
    }
    public void TransToAttackPanel()
    {
        _attackPanel.SetActive(true);
        _defensePanel.SetActive(false);
        _bonusPanel.SetActive(false);
    }

    public void TransToBonusPanel()
    {
        _attackPanel.SetActive(false);
        _defensePanel.SetActive(false);
        _bonusPanel.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePanelController : MonoBehaviour
{
    [SerializeField] GameObject _attackPanel;
    [SerializeField] GameObject _defensePanel;

    private void Start()
    {
        _attackPanel.SetActive(true);
        _defensePanel.SetActive(false);
    }

    public void TransToDefensePanel()
    {
        _attackPanel.SetActive(false);
        _defensePanel.SetActive(true);
    }
    public void TransToAttackPanel()
    {
        _attackPanel.SetActive(true);
        _defensePanel.SetActive(false);
    }
}

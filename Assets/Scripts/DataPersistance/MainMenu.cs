using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject _upgradePanel;
    [SerializeField] GameObject _start;
    private void Awake()
    {
        DataPersistanceManager.Instance.LoadGame();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void HomeButton()
    {
        _upgradePanel.SetActive(false);
        _start.SetActive(true);
    }
    public void UpgradePanel()
    {
        _upgradePanel.SetActive(true);
        _start.SetActive(false);
    }
}

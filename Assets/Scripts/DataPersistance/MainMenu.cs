using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void OnNewGameClicked()
    {
        DataPersistanceManager.Instance.NewGame();
    }

    public void OnLoadGameClicked()
    {
        DataPersistanceManager.Instance.LoadGame();
    }
    
    public void OnSaveGameClicked()
    {
        DataPersistanceManager.Instance.SaveGame();
    }
}

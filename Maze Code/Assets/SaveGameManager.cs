using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveGameManager : MonoBehaviour
{
    public SaveItem saveItemManager;
    public SoundConfigManager saveSoundConfigManager;
    public SaveCamera saveCameraManager;
    public SavePosition savePositionManager;
    public SaveInventory saveInventoryManager;
    public SavePuzzle savePuzzleManager;
    // Start is called before the first frame update
    void Awake()
    {
        if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("Start Menu")) return;
        SaveManager saveInfo = SaveGameInfo.LoadInfo();
        savePositionManager.position.initialValue = saveInfo.savePosition;
        saveCameraManager.maxPositionMap.initialValue = saveInfo.maxPositionMap;
        saveCameraManager.minPositionMap.initialValue = saveInfo.minPositionMap;
        saveCameraManager.resetMaxPosition.initialValue = saveInfo.resetMaxPosition;
        saveCameraManager.resetMinPosition.initialValue = saveInfo.resetMinPosition;
        SaveGame();
    }

    private void OnDisable () {
        SaveGameInfo.SaveInfo(saveCameraManager, savePositionManager);
        Debug.Log("save1");
        saveItemManager.SaveScriptables ();
        Debug.Log("save5");
        saveSoundConfigManager.SaveConfig ();
        Debug.Log("save2");
        saveInventoryManager.SaveScriptables ();
        Debug.Log("save3");
        savePuzzleManager.SaveScriptables ();
        Debug.Log("save4");
    }

    private void OnApplicationFocus (bool focusStatus) {
        if (!focusStatus) {
            SaveGameInfo.SaveInfo(saveCameraManager, savePositionManager);
            Debug.Log("save1");
            saveItemManager.SaveScriptables ();
            Debug.Log("save5");
            saveSoundConfigManager.SaveConfig ();
            Debug.Log("save2");
            saveInventoryManager.SaveScriptables ();
            Debug.Log("save3");
            savePuzzleManager.SaveScriptables ();
            Debug.Log("save4");
        }
    }

    private void OnApplicationQuit () {
        SaveGameInfo.SaveInfo(saveCameraManager, savePositionManager);
        Debug.Log("save1");
        saveItemManager.SaveScriptables ();
        Debug.Log("save5");
        saveSoundConfigManager.SaveConfig ();
        Debug.Log("save2");
        saveInventoryManager.SaveScriptables ();
        Debug.Log("save3");
        savePuzzleManager.SaveScriptables ();
        Debug.Log("save4");
    }
    public void SaveGame () {
        Debug.Log("load1");
        saveInventoryManager.LoadScriptables ();
        Debug.Log("load2");
        saveSoundConfigManager.LoadConfig ();
        Debug.Log("load4");
        savePuzzleManager.LoadScriptables ();
        Debug.Log("load6");
        saveItemManager.LoadScriptables ();
        Debug.Log("load acabou");
    }

    public void ResetPosition(){
        SaveGameInfo.Reset(saveCameraManager);
    }
}

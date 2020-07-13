using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour {
    // Start is called before the first frame update
    public SoundConfigManager saveSoundConfigManager;
    public SaveCamera saveCameraManager;
    public SavePosition savePositionManager;
    public SaveInventory saveInventoryManager;
    public SavePuzzle savePuzzleManager;
    public SaveItem saveItemManager;

    private void OnEnable () {
        saveCameraManager.LoadLimits ();
        saveSoundConfigManager.LoadConfig ();
        savePositionManager.LoadScriptables ();
        saveInventoryManager.LoadScriptables ();
        savePuzzleManager.LoadScriptables ();
        saveItemManager.LoadScriptables ();
    }

    private void OnDisable () {
        saveCameraManager.SaveLimits ();
        saveSoundConfigManager.SaveConfig ();
        savePositionManager.SaveScriptables ();
        saveInventoryManager.SaveScriptables ();
        savePuzzleManager.SaveScriptables ();
        saveItemManager.SaveScriptables ();
    }

    private void OnApplicationFocus (bool focusStatus) {
        if (!focusStatus) {
            saveCameraManager.SaveLimits ();
            saveSoundConfigManager.SaveConfig ();
            savePositionManager.SaveScriptables ();
            saveInventoryManager.SaveScriptables ();
            savePuzzleManager.SaveScriptables ();
            saveItemManager.SaveScriptables ();
        }
    }

    private void OnApplicationQuit () {
        saveCameraManager.SaveLimits ();
        saveSoundConfigManager.SaveConfig ();
        savePositionManager.SaveScriptables ();
        saveInventoryManager.SaveScriptables ();
        savePuzzleManager.SaveScriptables ();
        saveItemManager.SaveScriptables ();
    }

}
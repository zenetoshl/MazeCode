using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour {
    // Start is called before the first frame update
    public SoundConfigManager saveSoundConfigManager;
    public SaveCamera saveCameraManager;
    public SavePosition savePositionManager;
    public SaveInventory saveInventoryManager;
    public SavePuzzle savePuzzleManager;
    public SaveItem saveItemManager;


    private void Awake() {
        if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("Start Menu")) return;
        SaveGame();
    }
    public void SaveGame () {
        Debug.Log("load1");
        saveInventoryManager.LoadScriptables ();
        Debug.Log("load2");
        saveCameraManager.LoadLimits ();
        Debug.Log("load3");
        saveSoundConfigManager.LoadConfig ();
        Debug.Log("load4");
        savePositionManager.LoadScriptables ();
        Debug.Log("load5");
        savePuzzleManager.LoadScriptables ();
        Debug.Log("load6");
        saveItemManager.LoadScriptables ();
        Debug.Log("load acabou");
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
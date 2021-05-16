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
    public static SaveManager saveInfo = null;
    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log("entrei no awake");
        if (SceneManager.GetActiveScene ().name == "Start Menu")
        {
            saveInfo = SaveGameInfo.LoadInfo(saveCameraManager, saveItemManager.ResetScriptables (), saveInventoryManager.ResetScriptables (), savePuzzleManager.ResetScriptables ());
        } else
        if(saveInfo == null){
            saveInfo = SaveGameInfo.LoadInfo(saveCameraManager, saveItemManager.ResetScriptables (), saveInventoryManager.ResetScriptables (), savePuzzleManager.ResetScriptables ());
        }
        
        if (SceneManager.GetActiveScene ().name != "Start Menu") 
        {
            savePositionManager.position.initialValue = saveInfo.savePosition;
            saveCameraManager.maxPositionMap.initialValue = saveInfo.maxPositionMap;
            saveCameraManager.minPositionMap.initialValue = saveInfo.minPositionMap;
            savePuzzleManager.LoadScriptables (saveInfo.savePuzzleManager);
            saveItemManager.LoadScriptables (saveInfo.saveItemManager);
            saveInventoryManager.LoadScriptables (saveInfo.saveInventoryManager);
            saveCameraManager.resetMaxPosition.initialValue = saveInfo.resetMaxPosition;
            saveCameraManager.resetMinPosition.initialValue = saveInfo.resetMinPosition;
            saveSoundConfigManager.LoadConfig ();
        }
    }

    private void OnDisable (){
        if (SceneManager.GetActiveScene ().name != "Start Menu")
        {
            SaveGameInfo.SaveInfo(saveCameraManager, savePositionManager, saveItemManager.SaveScriptables (), saveInventoryManager.SaveScriptables (), savePuzzleManager.SaveScriptables ());
            saveSoundConfigManager.SaveConfig ();
        }
    }
    
    private void OnApplicationFocus (bool focusStatus) {
        if(focusStatus) return;
        if (SceneManager.GetActiveScene ().name != "Start Menu") 
        {
            SaveGameInfo.SaveInfo(saveCameraManager, savePositionManager, saveItemManager.SaveScriptables (), saveInventoryManager.SaveScriptables (), savePuzzleManager.SaveScriptables ());
            saveSoundConfigManager.SaveConfig ();
        }
    }
    
    private void OnApplicationQuit () {
        if (SceneManager.GetActiveScene ().name != "Start Menu") 
        {
            SaveGameInfo.SaveInfo(saveCameraManager, savePositionManager, saveItemManager.SaveScriptables (), saveInventoryManager.SaveScriptables (), savePuzzleManager.SaveScriptables ());
            saveSoundConfigManager.SaveConfig ();
        }
    }

    public void SaveGameInformation(){
        SaveGameInfo.SaveInfo(saveCameraManager, savePositionManager, saveItemManager.SaveScriptables (), saveInventoryManager.SaveScriptables (), savePuzzleManager.SaveScriptables ());
        saveSoundConfigManager.SaveConfig ();
    }
    
    public void ResetPosition(){
        saveInfo = SaveGameInfo.Reset(saveCameraManager, saveItemManager.ResetScriptables (), saveInventoryManager.ResetScriptables (), savePuzzleManager.ResetScriptables ());
    }
}

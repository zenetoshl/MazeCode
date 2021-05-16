using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveGameInfo
{
    private static bool reseted;
    public static void SaveInfo(
    SaveCamera saveCameraManager,
    SavePosition savePositionManager,
    SaveItem.Items saveItemManager,
    SaveInventory.Counts saveInventoryManager,
    SavePuzzle.Puzzles savePuzzleManager
    ) {
        BinaryFormatter binary = new BinaryFormatter();
        string path = Application.persistentDataPath + "/savedGame.mzcd";
        FileStream fileStream = new FileStream(path, FileMode.Create);
        SaveManager saveInfo = new SaveManager(savePositionManager.position.defaultValue, saveCameraManager.maxPositionMap, saveCameraManager.minPositionMap, 
        saveCameraManager.resetMaxPosition, saveCameraManager.resetMinPosition, saveItemManager, saveInventoryManager, savePuzzleManager);
        var json = JsonUtility.ToJson(saveInfo);
        Debug.Log("SALVANDO ---" + json);
        binary.Serialize(fileStream, json);
        fileStream.Close();
    }

    public static SaveManager LoadInfo(SaveCamera saveCameraManager, SaveItem.Items resetItemManager,
    SaveInventory.Counts resetInventoryManager,
    SavePuzzle.Puzzles resetPuzzleManager) {
        if(reseted){
            reseted = false;
        }
        if (File.Exists (Application.persistentDataPath + "/savedGame.mzcd")) {
            FileStream file = new FileStream(Application.persistentDataPath + "/savedGame.mzcd", FileMode.Open);
            BinaryFormatter binary = new BinaryFormatter ();
            var saveInfo = binary.Deserialize(file);
            SaveManager ahmlk = JsonUtility.FromJson<SaveManager>("" + saveInfo);
            Debug.Log("LOADING ------" + saveInfo);
            file.Close();
            return ahmlk;
        } else {
            Debug.Log("erro no load: arquivo não encontrado, resetando...");
            return Reset(saveCameraManager, resetItemManager, resetInventoryManager, resetPuzzleManager);
        }
    }

    public static SaveManager Reset(SaveCamera saveCameraManager, SaveItem.Items saveItemManager,
    SaveInventory.Counts saveInventoryManager,
    SavePuzzle.Puzzles savePuzzleManager) {
        
        Vector2 position = new Vector2(0f, 3f);
        SaveManager saveInfo = new SaveManager(position, saveCameraManager.resetMaxPosition, saveCameraManager.resetMinPosition, 
        saveCameraManager.resetMaxPosition, saveCameraManager.resetMinPosition, saveItemManager, saveInventoryManager, savePuzzleManager);
        var json = JsonUtility.ToJson(saveInfo);
        BinaryFormatter binary = new BinaryFormatter();
        string path = Application.persistentDataPath + "/savedGame.mzcd";
        FileStream fileStream = new FileStream(path, FileMode.Create);
        binary.Serialize(fileStream, saveInfo);
        fileStream.Close();
        if(File.Exists(Application.persistentDataPath + "/savedGame.mzcd"))
        {
            File.Delete(Application.persistentDataPath + "/savedGame.mzcd");
        }
        Debug.Log(json);
        return saveInfo;
    }
}

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
    SavePosition savePositionManager) {
        if(reseted){
            return;
        }
        BinaryFormatter binary = new BinaryFormatter();
        string path = Application.persistentDataPath + "/playerInfo.mzcd";
        FileStream fileStream = new FileStream(path, FileMode.Create);
        SaveManager saveInfo = new SaveManager(savePositionManager.position.initialValue, saveCameraManager.maxPositionMap, saveCameraManager.minPositionMap, saveCameraManager.resetMaxPosition, saveCameraManager.resetMinPosition);
        binary.Serialize(fileStream, saveInfo);
        fileStream.Close();
    }

    public static SaveManager LoadInfo() {
        if(reseted){
            reseted = false;
        }
        if (File.Exists (Application.persistentDataPath + "/playerInfo.mzcd")) {
            FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.mzcd", FileMode.Open);
            BinaryFormatter binary = new BinaryFormatter ();
            SaveManager saveInfo = binary.Deserialize(file) as SaveManager;
            file.Close ();
            return saveInfo;
        } else {
            Debug.Log("erro no load: arquivo não encontrado");
            return null;
        }
    }

    public static void Reset(SaveCamera saveCameraManager) {
        Vector2 position = new Vector2(0f, 3f);
        BinaryFormatter binary = new BinaryFormatter();
        string path = Application.persistentDataPath + "/playerInfo.mzcd";
        FileStream fileStream = new FileStream(path, FileMode.Create);
        SaveManager saveInfo = new SaveManager(position, saveCameraManager.resetMaxPosition, saveCameraManager.resetMinPosition, saveCameraManager.resetMaxPosition, saveCameraManager.resetMinPosition);
        binary.Serialize(fileStream, saveInfo);
        fileStream.Close();
        reseted = true;
        Debug.Log("cheguei aqui");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalSaveSoundConfig : MonoBehaviour
{
    public SoundConfigManager saveSoundConfigManager;

    private void OnEnable () {
        saveSoundConfigManager.LoadConfig ();
    }

    private void OnDisable () {
        saveSoundConfigManager.SaveConfig ();
    }

    private void OnApplicationFocus (bool focusStatus) {
        if (!focusStatus) {
            saveSoundConfigManager.SaveConfig ();
        }
    }

    private void OnApplicationQuit () {
        saveSoundConfigManager.SaveConfig ();
    }
}

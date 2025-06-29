using BepInEx;
using BepInEx.Logging;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LavaLagFix;

[BepInPlugin("Ayzax.LavaLagFix", "Lava Lag Fix", "1.0.0")]
public class LavaLagFix : BaseUnityPlugin
{
    internal static new ManualLogSource Logger;
        
    void Awake()
    {
        Logger = base.Logger;
        Logger.LogInfo("Ayzax's Lava Lag Fix is loaded!");
        SceneManager.sceneLoaded += HandleSceneLoad;
    }

    void HandleSceneLoad(Scene scene, LoadSceneMode loadMode)
    {
        DisableLavaBubbles();
    }

    void DisableLavaBubbles()
    {
        Logger.LogInfo("Looking for Lava Bubbles to disable...");
        GameObject LavaBubblesObj = GameObject.Find("/Map/Volcano/LavaField/Lava Bubbles");

        if (!LavaBubblesObj)
        {
            Logger.LogInfo("No Lava Bubbles found.");
            return;
        }

        LavaBubblesObj.SetActive(false);
        Logger.LogInfo("Disabling Lava Bubbles!");
    }
}

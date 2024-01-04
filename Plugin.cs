using BepInEx;
using UnityEngine;

namespace Speedometer
{
    [BepInPlugin("tairasoul.vaproxy.speedometer", "Speedometer", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        bool init = false;
        void Awake()
        {
            Logger.LogInfo("Speedometer is awake.");
        }

        void Start() => Init();
        void OnDestroy() => Init();

        void Init()
        {
            if (init) return;
            init = true;
            GameObject Speedometer = new GameObject("Speedometer");
            DontDestroyOnLoad(Speedometer);
            Speedometer.AddComponent<Speedometer>();
        }
    }
}

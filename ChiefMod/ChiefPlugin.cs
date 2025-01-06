using BepInEx;
using HarmonyLib;
using HunkMod.Modules.Weapons;

namespace ChiefMod
{
    [BepInDependency("com.rob.Hunk", BepInDependency.DependencyFlags.HardDependency)]
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    public class ChiefPlugin : BaseUnityPlugin
    {
        public const string PluginGUID = "com." + PluginAuthor + "." + PluginName;
        public const string PluginAuthor = "LONK";
        public const string PluginName = "ChiefMod";
        public const string PluginVersion = "1.0.5";

        public static ChiefPlugin Instance { get; private set; }
        internal static Harmony Harm;

        public void Awake()
        {
            Instance = this;
            Harm = new Harmony(PluginGUID);

            Log.Init(Logger);

            //ApplySoundReplacements();
            AddWeaponReskins();
        }

        private void ApplySoundReplacements()
        {
            Harm.CreateClassProcessor(typeof(EscapeSequence)).Patch();
        }

        private void AddWeaponReskins()
        {
            WeaponManager.Init();
            ChiefSkin.Init();

            WeaponManager.AddWeapon(SMG.instance.weaponDef, "mdlSMGHalo");
            WeaponManager.AddWeapon(MUP.instance.weaponDef, "mdlMUPHalo");
            WeaponManager.AddWeapon(AssaultRifle.instance.weaponDef, "mdlAssaultRifleUNSC");
            WeaponManager.AddWeapon(Shotgun.instance.weaponDef, "mdlShotgunHalo");
        }
    }
}

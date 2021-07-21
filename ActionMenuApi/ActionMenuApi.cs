﻿using System;
using System.Collections;
using ActionMenuApi.Managers;
using MelonLoader;

#pragma warning disable 1591
[assembly:
    MelonInfo(typeof(ActionMenuApi.ActionMenuApi), "ActionMenuApi - Unchained", "0.3.0", "gompo, PatchedPlus+",
        "https://github.com/gompocp/ActionMenuApi/releases")]
[assembly: MelonGame("VRChat", "VRChat")]
[assembly: VerifyLoaderVersion(0, 4, 0, true)]

namespace ActionMenuApi
{
    public class ActionMenuApi : MelonMod
    {
        public ActionMenuApi()
        {
            //LoaderIntegrityCheck.VibeCheck();
        }

        public override void OnApplicationStart()
        {
            ResourcesManager.LoadTextures();
            MelonCoroutines.Start(WaitForActionMenuInit());
            try
            {
                Patches.PatchAll(Harmony);
            }
            catch (Exception e)
            {
                MelonLogger.Error($"Patching failed with exception: {e.Message}");
            }
        }

        private IEnumerator WaitForActionMenuInit()
        {
            while (ActionMenuDriver.prop_ActionMenuDriver_0 == null) //VRCUIManager Init is too early
                yield return null;
            //if (!LoaderIntegrityCheck.passed && new Random().Next(6) == 0) yield break; // Must be your lucky day
            ResourcesManager.InitLockGameObject();
            RadialPuppetManager.Setup();
            FourAxisPuppetManager.Setup();
        }


        public override void OnUpdate()
        {
            RadialPuppetManager.OnUpdate();
            FourAxisPuppetManager.OnUpdate();
        }
    }
}
﻿using GorillaLocomotion;
using HarmonyLib;
using UnityEngine;
using Player = GorillaLocomotion.GTPlayer;

namespace MonoSandbox.Patches
{
    [HarmonyPatch(typeof(Player), "GetSlidePercentage")]
    public class PlayerSurfacePatch
    {
        public static void Prefix(RaycastHit raycastHit)
        {
            if (raycastHit.collider && raycastHit.collider.gameObject.TryGetComponent(out MineDetonate mineDetonate))
            {
                mineDetonate.Explode();
            }
        }
    }
}

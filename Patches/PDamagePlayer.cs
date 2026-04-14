using HarmonyLib;
using Rocket.Unturned.Chat;
using SDG.Unturned;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace DamageRemover__Agiota_.Patches
{
    [HarmonyPatch(typeof(PlayerLife), "doDamage")]
    public class PDamagePlayer
    {
        public static void Prefix(ref byte amount, Vector3 newRagdoll, EDeathCause newCause, ELimb newLimb, CSteamID newKiller, ref EPlayerKill kill, bool trackKill, ERagdollEffect newRagdollEffect, ref bool canCauseBleeding, PlayerLife __instance)
        {
            if (newKiller == null)
                return;

            Player Instigator = PlayerTool.getPlayer(newKiller);
            if (Instigator == null)
                return;

            if (Main.Instance.Configuration.Instance.RemoveDamageList.Contains(Instigator.equipment.itemID))
            {
                amount = 0;
            }
        }
    }
}

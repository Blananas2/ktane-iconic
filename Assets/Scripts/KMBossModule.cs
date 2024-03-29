﻿using System;
using System.Collections.Generic;
using Ut;
using UnityEngine;

public class KMBossModule : MonoBehaviour
{
    public string[] GetIgnoredModuleIDs(KMBombModule module, string[] @default = null)
    {
        return GetIgnoredModules(module.ModuleType, @default, ids: true);
    }

    public string[] GetIgnoredModules(KMBombModule module, string[] @default = null, bool ids = false)
    {
        return GetIgnoredModules(module.ModuleDisplayName, @default, ids);
    }

    public string[] GetIgnoredModules(string moduleName, string[] @default = null, bool ids = false)
    {
        if (Application.isEditor)
            return @default ?? new string[0];

        var bossModuleManagerAPIGameObject = GameObject.Find("BossModuleManager");
        if (bossModuleManagerAPIGameObject == null) // Boss Module Manager is not installed
        {
            Debug.LogFormat(@"[KMBossModule] Boss Module Manager is not installed.");
            return @default ?? new string[0];
        }

        var key = ids ? "GetIgnoredModuleIDs" : "GetIgnoredModules";
        var bossModuleManagerAPI = bossModuleManagerAPIGameObject.GetComponent<IDictionary<string, object>>();
        if (bossModuleManagerAPI == null || !bossModuleManagerAPI.ContainsKey(key))
        {
            Debug.LogFormat(@"[KMBossModule] Boss Module Manager does not have a list on record for “{0}”.", moduleName);
            return @default ?? new string[0];
        }

        var list = ((Func<string, string[]>) bossModuleManagerAPI[key])(moduleName);
        Debug.LogFormat(@"[KMBossModule] Boss Module Manager returned list for “{0}”: {1}", moduleName, list == null ? "<null>" : list.JoinString(", "));
        return list ?? @default ?? new string[0];
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// require to create custom editor to reset stats value in unity interface

[CustomEditor(typeof(PlayerStats))]

public class PlayerStatsEditor : Editor
{
    private PlayerStats StatsTarget => target as PlayerStats;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Reset Player Value"))
        {
            // call method from player stats
            StatsTarget.ResetPlayer();
        }
    }
}

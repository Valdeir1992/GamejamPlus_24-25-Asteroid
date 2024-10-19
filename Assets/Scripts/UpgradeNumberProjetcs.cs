﻿using UnityEngine;

[CreateAssetMenu(menuName = "Rougue Asteroid/Upgrade/Number of projetcs")]
public sealed class UpgradeNumberProjetcs : UpgradeSO
{
    [SerializeField] private int _value;

    public override void Upgrade()
    {
        FindAnyObjectByType<StatsController>().AddNumberProjetcs(_value);
    }
}
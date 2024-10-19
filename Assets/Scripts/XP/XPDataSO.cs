using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Asteroid/XP/Value")]
public class XPDataSO : ScriptableObject
{
    [SerializeField] private List<XPValue> _listXPValue;

    public List<XPValue> ListXPValue { get => _listXPValue;}
}

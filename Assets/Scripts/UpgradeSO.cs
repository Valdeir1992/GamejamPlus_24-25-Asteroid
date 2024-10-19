using UnityEngine;

public abstract class UpgradeSO : ScriptableObject
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private string _description;

    public string Description { get => _description;}
    public Sprite Icon { get => _icon;}

    public abstract void Upgrade();
}

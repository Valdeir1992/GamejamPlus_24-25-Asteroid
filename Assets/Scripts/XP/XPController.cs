using System; 
using System.Linq;
using UnityEngine;

public class XPController : MonoBehaviour
{
    private int _currentLevel = 1;
    private int _currenXP;
    public Action<LevelInfo> OnLevelUp;
    public Action<XPInfo> OnAddXP;
    [SerializeField] private XPDataSO _xpValues;
     

    public void AddXP(int value, string source)
    {
        var xpInfo = new XPInfo() { AddXP = value, DeltaXP = (_currenXP + value) - _currenXP, Source = source };
        _currenXP += value;
        OnAddXP?.Invoke(xpInfo);
        if (CheckLevel())
        {
            var levelUp = new LevelInfo()
            {
                CurentLevel = _currentLevel,
                CurrentXP = _currenXP,
                NextXP = _xpValues.ListXPValue.FirstOrDefault(x => x.Level == _currentLevel + 1).Value
            };
            _currentLevel++;
            OnLevelUp?.Invoke(levelUp);
        }
    }

    public bool CheckLevel()
    {
        return _currenXP > _xpValues.ListXPValue.FirstOrDefault(x => x.Level == _currentLevel).Value;
    }
}
public struct LevelInfo
{
    public int CurentLevel;
    public int CurrentXP;
    public int NextXP;
}

public struct XPInfo
{
    public int DeltaXP;
    public int AddXP;
    public string Source;
}

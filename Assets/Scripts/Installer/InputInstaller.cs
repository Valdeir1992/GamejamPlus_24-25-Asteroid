using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InputInstaller : MonoInstaller
{
    [SerializeField] private InputController _inputControllerPrefab;
    public override void InstallBindings()
    {
        Container.Bind<InputController>().FromComponentInNewPrefab(_inputControllerPrefab).AsSingle();
    }
}

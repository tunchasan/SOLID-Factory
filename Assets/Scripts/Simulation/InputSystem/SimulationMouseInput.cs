using System.Collections.Generic;
using DG.Tweening;
using Factorio.Core.InputSystem.Base;
using UnityEngine;
using Zenject;

namespace Factorio.Simulation.InputSystem
{
    public class SimulationMouseInput : InputBase
    {
        [SerializeField] private float pathDuration = 15F;
        [SerializeField] private Transform simulationTarget = null;
        [SerializeField] private List<Transform> simulationPath = new();

        private Vector3[] _path;

        [Inject] private Camera _camera;
        
        private void Start()
        {
            _path = new Vector3[simulationPath.Count];

            for (var i = 0; i < _path.Length; i++)
            {
                _path[i] = simulationPath[i].position;
            }
            
            ProcessInput();
        }

        protected override void ProcessInput()
        {
            simulationTarget.DOPath(_path, pathDuration, PathType.CatmullRom).OnUpdate(() =>
            {
                Direction = _camera.WorldToScreenPoint(simulationTarget.position);
                
            }).SetLoops(-1).SetEase(Ease.Linear);
        }
    }
}
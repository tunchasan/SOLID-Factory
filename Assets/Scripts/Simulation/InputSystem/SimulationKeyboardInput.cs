using System.Collections;
using Factorio.Core.InputSystem.Base;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Factorio.Simulation.InputSystem
{
    public class SimulationKeyboardInput : InputBase
    {
        [SerializeField] private Transform simulationTarget = null;
        [Range(0F, 1F)] [SerializeField] private float movementRandomness = 1F;

        private Vector2 _difference = Vector2.zero;

        private void Start()
        {
            StartCoroutine(FindDirection());
        }

        private IEnumerator FindDirection()
        {
            while (true)
            {
                var direction = simulationTarget.position;
            
                yield return new WaitForSeconds(Random.Range(.25F, 1F) * movementRandomness);

                direction = simulationTarget.position - direction;
                direction *= 100F;
                direction.x = Mathf.Clamp(direction.x, -.5F, .5F);
                direction.y = Mathf.Clamp(direction.y, -.5F, .5F);
                Direction = direction;
            }
        }

        protected override void ProcessInput()
        {
            _difference =  simulationTarget.position - transform.position;
            _difference.x = Mathf.Clamp(_difference.x, -1F, 1F);
            _difference.y = Mathf.Clamp(_difference.y, -1F, 1F);
            Direction = _difference;
        }
    }
}
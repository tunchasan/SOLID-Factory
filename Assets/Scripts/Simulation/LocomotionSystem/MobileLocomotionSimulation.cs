using Factorio.Core.InputControllerSystem.Base;
using Factorio.Core.LocomotionSystem.Class;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Factorio.Simulation.LocomotionSystem
{
    public class MobileLocomotionSimulation : MobileLocomotion
    {
        private float _speedMultiplier = 1F;

        public override void Initialize(InputController input)
        {
            base.Initialize(input);
            _speedMultiplier = Random.Range(.25F, 2.5F);
        }
        
        #region Movement
        public override void ProcessMovement()
        {
            if (CanMove())
            {
                var currentVelocity = transform.position;
                var targetVelocity = Input.MovementInput;
                transform.position = Vector3.Lerp(currentVelocity, targetVelocity, 
                    Time.fixedDeltaTime * _speedMultiplier);
                OnLocomotion?.Invoke();
            }
            else
            {
                OnCancelledLocomotion?.Invoke();
            }
        }

        #endregion
    }
}
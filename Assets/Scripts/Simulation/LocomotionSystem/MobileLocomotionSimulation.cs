using Factorio.Core.InputControllerSystem.Base;
using Factorio.Core.LocomotionSystem.Class;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Factorio.Simulation.LocomotionSystem
{
    public class MobileLocomotionSimulation : MobileLocomotion
    {
        [SerializeField] private bool randomSpeed = true;
        
        private float _speedMultiplier = 1.25F;

        public override void Initialize(InputController input)
        {
            base.Initialize(input);
            if(!randomSpeed) return;
            _speedMultiplier = Random.Range(.25F, 2.5F);
        }
        
        public override bool CanMove()
        {
            return ShouldMove && Input.MovementInput.magnitude >= 1F;
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
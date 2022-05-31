using UnityEngine;

namespace DetectorSystem
{
    public interface IDetector
    {
        abstract void OnTriggerEnter(Collider other);
    }
}
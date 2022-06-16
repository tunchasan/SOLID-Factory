using SourceSystem.Enums;
using UnityEngine;

namespace SourceSystem.Class
{
    [CreateAssetMenu]
    public class SourcePreset : ScriptableObject
    {
        public DetectableType detectType;
        public PlaceableType placeType;
        public StorableType storeType;
        public TransportableType transportType;
    }
}
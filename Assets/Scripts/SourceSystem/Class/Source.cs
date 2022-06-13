using SourceSystem.Base;

namespace SourceSystem.Class
{
    public class Source : SourceBase
    {
        protected override void SetBehaviour()
        {
            Storable = null;
            Placeable = null;
            Detectable = null;
            Transportable = null;
        }
    }
}
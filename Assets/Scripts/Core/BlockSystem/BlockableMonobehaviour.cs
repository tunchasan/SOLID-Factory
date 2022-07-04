using Factorio.Core.BlockSystem.Base;
using UnityEngine;

namespace Factorio.Core.BlockSystem
{
    public class BlockableMonobehaviour : MonoBehaviour, IBlockable
    {
        public bool HasBlocked { get; private set; }

        public virtual void Initialize(bool hasBlocked)
        {
            HasBlocked = hasBlocked;

            if (hasBlocked)
            {
                Block();
            }

            else
            {
                UnBlock();
            }
        }
        
        public virtual void Block()
        {
            HasBlocked = true;
        }

        public virtual void UnBlock()
        {
            HasBlocked = false;
        }
    }
}

using System;
using UnityEngine;

namespace Fiziks2D
{
    public class GroundDetector2D : MonoBehaviour, IGroundDetector2D
    {
        public GroundingInformation2D Info { get; private set; }


        private void Start()
        {
            Info = new GroundingInformation2D();
        }


        private void Update()
        {
           RaycastHit2D hitInfo = Physics2D.CircleCast(
                this.transform.position,
                0.3f,
                Vector2.down,
                0.2f
                // mask    
                );

            Info.Update(hitInfo);
        }

    }
}
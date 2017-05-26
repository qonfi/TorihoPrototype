//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine.SceneManagement;
//using UnityEngine.Networking; // (needs NetworkBehaviour)
//using UnityEngine.UI;
using UnityEngine;

namespace Fiziks2D
{
    public class GroundingInformation2D
    {
        public RaycastHit2D HitInfo { get; private set; }
        public GameObject GroundBeingDetected { get; private set; }
        public GameObject LastDetectedGround { get; private set; }
        public bool IsGrounding { get; private set; }


        /// <summary>
        /// hitInfo を渡すとその情報を整理してフィールドに反映する。
        /// </summary>
        /// <param name="hitInfo"></param>
        public void Update(RaycastHit2D hitInfo)
        {
            this.HitInfo = hitInfo;

            if (hitInfo.collider == null)
            {
                GroundBeingDetected = null;
                IsGrounding = false;
            }
            else
            {
                GameObject detectedObject = hitInfo.collider.gameObject;
                GroundBeingDetected = detectedObject;
                LastDetectedGround = detectedObject;
                IsGrounding = true;
            }
        }
    }
}
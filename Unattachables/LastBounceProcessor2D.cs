//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine.SceneManagement;
//using UnityEngine.Networking; // (needs NetworkBehaviour)
//using UnityEngine.UI;
using UnityEngine;

namespace Fiziks2D
{
    public class LastBounceProcessor2D 
    {
        private float passedTime = 0.00f;
        private float upwardPower = 18f;
        private float gravityAccel = 16f;

        public Vector2 Update(GameObject faller)
        {
            Vector2 movement;
            passedTime += Time.deltaTime;
            movement = (upwardPower -  passedTime * gravityAccel) * Vector2.up;

            if (passedTime > 3f)
            {
                GameObject.Destroy(faller);
            }

            return movement;
        }
    }
}
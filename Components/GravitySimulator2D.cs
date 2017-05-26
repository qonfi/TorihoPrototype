//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine.SceneManagement;
//using UnityEngine.Networking; // (needs NetworkBehaviour)
//using UnityEngine.UI;
using System;
using UnityEngine;

namespace Fiziks2D
{
    public class GravitySimulator2D : MonoBehaviour, IGravitySimulator2D, IMovementCalculator2D
    {
        public float GravityAccel { get; private set; }
        public float FloatingTime { get; private set; }
        public Vector2 MovementPerFrame { get; private set; }
        private IGroundDetector2D detector;


        private void Start()
        {
            detector = GetComponent<IGroundDetector2D>();
            GravityAccel = 8.00f;
        }



        private void Update()
        {
            if (detector.Info.IsGrounding == false)
            {
                // 接地していなければ、FloatingTime のカウントをしていき、それに比例した落下量を計算する、
                FloatingTime += Time.deltaTime;
                MovementPerFrame = Vector2.down * GravityAccel * FloatingTime;
                return;
            }

            if (detector.Info.IsGrounding)
            {
                // 接地していたら FloatingTime をリセットして、移動量をゼロに。
                FloatingTime = 0.00f;
                MovementPerFrame = Vector2.zero; //?
                return;
            }

        }


    }
}
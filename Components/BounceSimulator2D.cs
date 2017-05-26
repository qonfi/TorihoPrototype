
using System;
using UnityEngine;
using Labo;


namespace Fiziks2D
{

    // 悪くない動作だが、このアプリケーションには余り向いていないかも。
    public class BounceSimulator2D : MonoBehaviour, IMovementCalculator2D
    {
        private IGroundDetector2D groundDetector;
        private MovementHandler2D handler;
        private Vector2 MovementBeforeCollision;
        public Vector2 MovementPerFrame { get; private set; }
        private float constantBouncePower = 2f;

        public bool Fallen { get; set; }
        private LastBounceProcessor2D lastBouncer;

        private void Start()
        {
            groundDetector = GetComponent<IGroundDetector2D>();
            handler = GetComponent<MovementHandler2D>();
            lastBouncer = new LastBounceProcessor2D();
        }


        private void Update()
        {
            if (Fallen)
            {
                this.MovementPerFrame = lastBouncer.Update(this.gameObject);
                return;
            }

            if (groundDetector.Info.IsGrounding)
            {
                MovementPerFrame = Vector2.zero;

                //if (groundDetector.Info.GroundBeingDetected.tag == TagManager.BasketTag) { return; }

                // 衝突面の法線方向に、衝突直前の速度を考慮(detector側のみ)した移動を行う。
                // 衝突直前の速度は"秒ごとの移動量"として計算されたものを"フレームごとの移動量"に戻している...たぶん。
                Vector2 bounceDirection = groundDetector.Info.HitInfo.normal;
                float bouncePower = MovementBeforeCollision.magnitude *  1/ Time.deltaTime;
                bouncePower = bouncePower * 0.60f + constantBouncePower;
                // Debug.Log(bounceDirection + " " + bouncePower);
                MovementPerFrame = bounceDirection * bouncePower;
            }
            else
            {
                // 接地中でない間のみ速度を記録しておき、それを衝突直前の速度として使う。
                MovementBeforeCollision = handler.TotalMovement;
            }
        }


    }
}
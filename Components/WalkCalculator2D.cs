
using System;
using UnityEngine;


namespace Fiziks2D
{
    public class WalkCalculator2D : MonoBehaviour, IMovementCalculator2D
    {
        public IDebuffManager2D debuffManager; 
        public Vector2 MovementPerFrame { get; private set; }
        public float WalkSpeed { get; private set; }
        public float MaxSpeed { get; private set; }


        private void Start()
        {
            debuffManager = GetComponent<IDebuffManager2D>();
            WalkSpeed = 3f;
            MaxSpeed = 7.00f;
        }


        private void Update()
        {
            // 初期化
            float horizontalMovement = MovementPerFrame.x;

            // 入力の値をもとにして移動量を計算。
            if (Input.GetMouseButton(0)) { horizontalMovement += -WalkSpeed; }
            if (Input.GetMouseButton(1)) { horizontalMovement += WalkSpeed; }

            // 最高速度まで値を制限
            horizontalMovement = Mathf.Clamp(horizontalMovement, -MaxSpeed, MaxSpeed);

            // 異常状態の影響を計算する
            // 移動量がマイナスになった後、入力による加算減算などがうまく機能していないようだ。
            horizontalMovement = DebuffEffect(horizontalMovement);

            if (debuffManager.ConcussionDebuff && 
                WalkSpeed > 0)
            {
                WalkSpeed = -WalkSpeed;
            }

            // 結果
            MovementPerFrame = Vector2.right * horizontalMovement;

            Slowdown();
        }


        // これはDebuffManager 側で実行スべきか?
        private float DebuffEffect(float movement)
        {
            // まどろっこしい書き方になってしまった。しかもこの関数内で実行する必要がない。
            if (debuffManager.ConcussionDebuff && 
                WalkSpeed > 0)
            {
                WalkSpeed *= -1.00f;
            }

            if (debuffManager.ConcussionDebuff == false && 
                WalkSpeed < 0)
            {
                WalkSpeed *= -1.00f;
            }


            if (debuffManager.SlowmotionDebuff)
            {
                movement *= 0.4f;
            }

            return movement;
        }


        private void Slowdown()
        {
            // 入力が無い場合減速
            if (Input.GetMouseButton(0) == false &&
                Input.GetMouseButton(1) == false)
            {
                MovementPerFrame *= 0.8f;
            }
        }
    }
}
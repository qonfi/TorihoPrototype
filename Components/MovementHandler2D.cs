
using System.Collections.Generic;
using UnityEngine;


namespace Fiziks2D
{
    public class MovementHandler2D : MonoBehaviour
    {
        public Vector2 TotalMovement { get; private set; }
        private List<IMovementCalculator2D> calculators;


        private void Start()
        {
            calculators = new List<IMovementCalculator2D>();
            calculators.AddRange(GetComponents<IMovementCalculator2D>());
        }


        private void Update()
        {
            TotalMovement = Vector2.zero;

            foreach(IMovementCalculator2D element in calculators)
            {
                TotalMovement += element.MovementPerFrame;
            }

            TotalMovement *= Time.deltaTime;
            transform.Translate(TotalMovement);
        }


        /// <summary>
        /// 原因が突き止められないバグがあり、回避するために柔軟性のないメソッドになっている。
        /// </summary>
        public void UpdateComponentsList()
        {
            calculators.Clear();
            //calculators.AddRange(GetComponents<IMovementCalculator2D>()); // 何故かDestroyしたはずのコンポーネントを拾ってきてしまう。
            calculators.Add(GetComponent<DivingProcessor2D>());
        }

    }
}
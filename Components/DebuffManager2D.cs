
using System;
using UnityEngine;

namespace Fiziks2D
{
    public class DebuffManager2D : MonoBehaviour, IDebuffManager2D
    {
        public bool ConcussionDebuff { get; private set; }
        public bool SlowmotionDebuff { get; private set; }
        private float slowmotionTime = 0.00f;
        private float naturalHealTime = 3f;
        


        private void Start()
        {
            ConcussionDebuff = false;
            SlowmotionDebuff = false;
        }


        private void Update()
        {
            NaturalHeal();

            //Debug.Log("Concussion" + ConcussionDebuff + "\n" +
            //    "Slowmotion" + SlowmotionDebuff);
        }


        private void NaturalHeal()
        {
            if (SlowmotionDebuff)
            {
                slowmotionTime += Time.deltaTime;
            }

            if (slowmotionTime > naturalHealTime)
            {
                SlowmotionDebuff = false;
                ResetSlowmotionTime();
            }
        }


        public void SwitchConcussion()
        {
            ConcussionDebuff = !ConcussionDebuff;
        }


        public void StartSlowmotion()
        {
            SlowmotionDebuff = true;
            ResetSlowmotionTime();
        }


        public void EndSlowmotion()
        {
            SlowmotionDebuff = false;
            ResetSlowmotionTime();
        }


        private void ResetSlowmotionTime()
        {
            slowmotionTime = 0.00f;
        }
    }
}
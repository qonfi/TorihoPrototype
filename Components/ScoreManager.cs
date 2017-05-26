//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine.SceneManagement;
//using UnityEngine.Networking; // (needs NetworkBehaviour)
//using UnityEngine.UI;
using UnityEngine;
using Labo;

namespace Fiziks2D
{
   // ScoreManager の名前にそぐわない処理も請け負ってしまっている。
    public class ScoreManager : MonoBehaviour
    {
        public int Score { get; private set; }
        private DebuffManager2D debuffManager;


        private void Start()
        {
            GameObject athlete = GameObject.FindGameObjectWithTag(TagManager.AthleteTag);
            debuffManager = athlete.GetComponent<DebuffManager2D>();
        }


        public void Judge(string fallerTag, int headingCount)
        {
            if (fallerTag == TagManager.AppleTag)
            {
                Score += (1 + headingCount);
                Debug.Log(Score);
                return;
            }

            if (fallerTag == TagManager.PoisonTag)
            {
                Debug.Log("Poison!");
                return;
            }

            if (fallerTag == TagManager.WeightTag)
            {
                Debug.Log("Heavy weight!");
                debuffManager.StartSlowmotion();
                return;
            }


            Debug.Log(fallerTag);
        }
    }
}
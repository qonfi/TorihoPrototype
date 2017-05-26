//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine.SceneManagement;
//using UnityEngine.Networking; // (needs NetworkBehaviour)
//using UnityEngine.UI;
using UnityEngine;
using Labo;
using System;

namespace Fiziks2D
{
    public class GroundingReactor2D : MonoBehaviour
    {
        public int HeadingCount { get; private set; }
        private bool colliding;
        private bool fallen;

        private IGroundDetector2D detector;
        private DebuffManager2D debuffManager;
        private ScoreManager scorer;

        private FallenProcessor2D fallenProcessor;


        private void Start()
        {
            detector = GetComponent<IGroundDetector2D>();

            GameObject athlete = GameObject.FindGameObjectWithTag(TagManager.AthleteTag);
            debuffManager = athlete.GetComponent<DebuffManager2D>();

            GameObject manager = GameObject.FindGameObjectWithTag(TagManager.ManagerTag);
            scorer = manager.GetComponent<ScoreManager>();

            fallenProcessor = new FallenProcessor2D(this.gameObject);
        }


        private void Update()
        {
            if (fallen) { return; }

            GameObject ground = detector.Info.GroundBeingDetected;

            // この辺がみづらい。
            if (ground == null)
            {
                colliding = false;
                return;
            }

            if (colliding == true) { return; }

            colliding = true;

            if (ground.tag == TagManager.AthleteTag)
            {
                HeadingCount++;
                StartConcussion();
                return;
            }
            
            if (ground.tag == TagManager.BasketTag)
            {
                //Debug.Log(detector.Info.GroundBeingDetected.tag);
                GetComponent<DivingProcessor2D>().StartCatching();
                scorer.Judge(this.tag, HeadingCount);
                return;
            }

            if (ground.tag == TagManager.GroundTag)
            {
                // fallenProcessor.Start();
                fallen = true;
                fallenProcessor.Start();
                return;
            }
        }


        private void StartConcussion()
        {
            if ( this.tag == TagManager.WeightTag)
            {
                debuffManager.SwitchConcussion();
            }
        }

    }
}
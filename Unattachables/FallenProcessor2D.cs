//using System.Collections;
using System.Collections.Generic;
//using UnityEngine.SceneManagement;
//using UnityEngine.Networking; // (needs NetworkBehaviour)
//using UnityEngine.UI;
using UnityEngine;

namespace Fiziks2D
{
    public class FallenProcessor2D
    {
        private List<Component> components;
        private BounceSimulator2D bouncer;

        // パフォーマンスのことは考えていない。このリストは使いまわす形にしたほうが本当はよい。それかstatic?
        public FallenProcessor2D(GameObject faller)
        {
            components = new List<Component>();
            components.AddRange(faller.GetComponents<Component>());
            bouncer = faller.GetComponent<BounceSimulator2D>();
        }


        public void Start()
        {
            foreach (Component element in components)
            {
                if (element is Transform) { continue; }
                if (element is SpriteRenderer) { continue; }
                if (element is MovementHandler2D) { continue; }
                if (element is GroundingReactor2D) { continue; }

                if (element is GroundDetector2D) { continue; }
                if (element is BounceSimulator2D) { continue; }
                GameObject.Destroy(element);
            }

            bouncer.Fallen = true;
        }
    }
}
//using System.Collections;
using System.Collections.Generic;
//using UnityEngine.SceneManagement;
//using UnityEngine.Networking; // (needs NetworkBehaviour)
//using UnityEngine.UI;
using System;
using UnityEngine;
using Labo;

namespace Fiziks2D
{
    public class DivingProcessor2D : MonoBehaviour, IMovementCalculator2D
    {
        public Vector2 MovementPerFrame { get; private set; }
        private List<Component> components;
        private MovementHandler2D handler;
        private float divingSpeed = 1f;
        private GameObject basket;

        private void Start()
        {
            components = new List<Component>();
            components.AddRange(GetComponents<Component>());
            
            handler = GetComponent<MovementHandler2D>();
            basket = GameObject.FindGameObjectWithTag(TagManager.BasketTag);    // パフォーマンス悪
        }


        public void StartCatching()
        {
            foreach (Component element in components)
            {
               if (element == null) { continue; }
               if (element is Transform) { continue; }
                if (element is MovementHandler2D) { continue; }
                if (element is SpriteRenderer) { continue; }
                if (element is DivingProcessor2D) { continue; }
                Destroy(element);
            }

            handler.UpdateComponentsList();

            this.transform.parent = basket.transform;
            this.MovementPerFrame = Vector2.down * divingSpeed;
        }
    }
}
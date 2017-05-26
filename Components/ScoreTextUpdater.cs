//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine.SceneManagement;
//using UnityEngine.Networking; // (needs NetworkBehaviour)
using UnityEngine.UI;
using UnityEngine;
using Labo;

namespace Fiziks2D
{
    public class ScoreTextUpdater : MonoBehaviour
    {
        private ScoreManager scorer;
        private Text textComponent;

        private void Start()
        {
            GameObject manager = GameObject.FindGameObjectWithTag(TagManager.ManagerTag);
            scorer = manager.GetComponent<ScoreManager>();

            textComponent = GetComponent<Text>();
        }

        private void Update()
        {
            textComponent.text = scorer.Score.ToString();
        }
    }
}
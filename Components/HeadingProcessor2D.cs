//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine.SceneManagement;
//using UnityEngine.Networking; // (needs NetworkBehaviour)
//using UnityEngine.UI;
using UnityEngine;

namespace Fiziks2D
{
    public class HeadingProcessor2D : MonoBehaviour
    {
        public int HeadingCount { get; private set; }

        public int IncreaseCount()
        {
            HeadingCount++;
            return HeadingCount;
        }
    }
}
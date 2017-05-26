//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine.SceneManagement;
//using UnityEngine.Networking; // (needs NetworkBehaviour)
//using UnityEngine.UI;
using UnityEngine;

namespace Fiziks2D
{
    public interface IGravitySimulator2D 
    {
        float GravityAccel { get; }
        float FloatingTime { get; }
    }
}
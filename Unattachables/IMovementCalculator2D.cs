
using UnityEngine;

namespace Fiziks2D
{
    public interface IMovementCalculator2D 
    {
        Vector2 MovementPerFrame { get; }
    }
}
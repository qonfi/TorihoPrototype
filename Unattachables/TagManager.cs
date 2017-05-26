
//using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Labo
{

    public static class TagManager
    {
        public static string AthleteTag { get; private set; }
        public static string BasketTag { get; private set; }
        public static string FallerTag { get; private set; }
        public static string AppleTag { get; private set; }
        public static string PoisonTag { get; private set; }
        public static string WeightTag { get; private set; }
        public static string GroundTag { get; private set; }
        public static string ManagerTag { get; private set; }

        static TagManager()
        {
            AthleteTag = "Athlete";
            BasketTag = "Basket";
            FallerTag = "Faller";
            AppleTag = "Apple";
            PoisonTag = "Poison";
            WeightTag = "Weight";
            GroundTag = "Ground";
            ManagerTag = "Manager";
        }
    }
}
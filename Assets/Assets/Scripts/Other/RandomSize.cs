using System;
using UnityEngine;

namespace Assets.Assets.Scripts.Other
{
    public class RandomSize : ISize
    {
        public float minSize, maxSize;

        public override float Value()
        {
            return UnityEngine.Random.Range(minSize, maxSize);
        }
    }
}

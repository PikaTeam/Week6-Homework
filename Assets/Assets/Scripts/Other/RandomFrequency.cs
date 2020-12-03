using System;
using UnityEngine;

namespace Assets.Assets.Scripts.Other
{
    public class RandomFrequency : IFrequency
    {
        private float min, max;

        public RandomFrequency(float min, float max)
        {
            this.min = min;
            this.max = max;
        }

        public override float value()
        {
            return UnityEngine.Random.Range(min, max);
        }
    }
}

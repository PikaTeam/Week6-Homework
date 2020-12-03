using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Assets.Scripts.Other
{
    public class ConstantFrequency : IFrequency
    {
        public float constant;

        public ConstantFrequency(float constant)
        {
            this.constant = constant;
        }

        public override float value()
        {
            return constant;
        }

    }
}

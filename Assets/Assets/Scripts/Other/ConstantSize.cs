using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantSize : ISize
{

    public float constant = 1;

    public override float Value()
    {
        return constant;
    }
}

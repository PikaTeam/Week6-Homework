using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternatingSize : ISize
{
    public ISize[] sizes;
    public int alternateAfterNValues;

    private int currentSizeIndex = 0;
    private int valuesGenerated = 0;

    public override float Value()
    {
        valuesGenerated++;
        
        if (valuesGenerated == alternateAfterNValues && currentSizeIndex < sizes.Length-1)
        {
            currentSizeIndex++;
            valuesGenerated = 0;
            Debug.Log("ALTERNATED");
        }

        Debug.Log(valuesGenerated);
        return sizes[currentSizeIndex].Value();
    }
}

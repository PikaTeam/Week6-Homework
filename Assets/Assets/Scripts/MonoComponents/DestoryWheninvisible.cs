using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryWheninvisible : MonoBehaviour
{

    private void OnBecameInvisible()
    {
        Debug.Log("INVISIBLE");
        Destroy(this.gameObject);
    }
}

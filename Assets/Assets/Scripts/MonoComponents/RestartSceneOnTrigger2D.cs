using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartSceneOnTrigger2D : MonoBehaviour
{
    public GameObject triggerWith;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("triggered scene");
        if (collision.gameObject.tag.Equals(triggerWith.tag))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

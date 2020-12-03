using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToSceneOnCollision2D : MonoBehaviour
{
    public GameObject withObject;
    [SerializeField]
    public string sceneName;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals(withObject.tag))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}

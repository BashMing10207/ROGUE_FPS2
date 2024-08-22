using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SCENWSDF : MonoBehaviour
{
    public string name;
    public void Sce()
    {
        SceneManager.LoadScene(name);
    }
}

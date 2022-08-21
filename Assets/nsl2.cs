using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nsl2 : MonoBehaviour
{ 
    void OnEnable()
    {
        SceneManager.LoadScene("Main - final boss", LoadSceneMode.Single);
    }
}

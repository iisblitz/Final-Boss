using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portalLogic : MonoBehaviour
{
    public int NumberLevelToLoad;
    public string NameLeveltoLoad;
    public bool useIntegerToLoadLevel = false;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    { }

    private void OnTriggerEnter2D(Collider2D collision) {
        GameObject collisionGameObject = collision.gameObject;
        if (collisionGameObject.name == "Player") {
        LoadScene();
        }
    }
    

    void LoadScene(){
        if (useIntegerToLoadLevel)
        {SceneManager.LoadScene(NumberLevelToLoad); }
        else { SceneManager.LoadScene(NameLeveltoLoad); }
    } 
}

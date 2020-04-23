using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseLevelController : MonoBehaviour
{
    [Header("Keys")] [SerializeField]
    private KeyCode restartKey = KeyCode.T;
    

    void Update()
    {
        if(Input.GetKeyDown(restartKey))
            FastRestartScene();
    }
    
    public virtual void FastRestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public virtual void FastLoadScene(int whatScene)
    {
        SceneManager.LoadScene(whatScene);
    }

    public virtual IEnumerator TimetLoadScene(int whatScene, float howLongToWait)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(whatScene); //Ready to load scene
        asyncLoad.allowSceneActivation = false; //So it not load scene before the time have gone
        
        yield return new WaitForSeconds(howLongToWait);
        
        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            asyncLoad.allowSceneActivation = true; //Load scene
            yield return null;
        }
    }
}

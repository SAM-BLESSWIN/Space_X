using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneloader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("loadscene", 3f);
    }
    void loadscene()
    {
        SceneManager.LoadScene(1);
    }
}

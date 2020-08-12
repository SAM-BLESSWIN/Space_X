using UnityEngine;
using UnityEngine.SceneManagement;

public class collisionhandler : MonoBehaviour
{
    [SerializeField] float levelloaddelay = 1f;
    [SerializeField] GameObject destroy;
    private void OnTriggerEnter(Collider other)
    {
        shipdestroyed();
        destroy.SetActive(true);
        Invoke("reloadscene", levelloaddelay);
    }

    private  void shipdestroyed()
    {
        SendMessage("playerdead");
    }

    void reloadscene()
    {
        SceneManager.LoadScene(1);
    }
}

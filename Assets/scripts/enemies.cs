using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemies : MonoBehaviour
{
    [SerializeField] GameObject enemyfx;
    [SerializeField] Transform parent;
    [SerializeField] int points = 20;
    [SerializeField] int hits= 10;
    scoreboard scoreboard;
  
    void Start()
    {
        boxcollider();
        scoreboard = FindObjectOfType<scoreboard>();
    }

    private void boxcollider()
    {
        Collider enemy = gameObject.AddComponent<BoxCollider>();
        enemy.isTrigger = false;
    }

    // Update is called once per frame

    void OnParticleCollision(GameObject other)
    {
        hits--;
        if (hits <= 0)
        {
            killenemy();
        }
    }

    private void killenemy()
    {
        scoreboard.scorepoints(points);
        GameObject dead = Instantiate(enemyfx, transform.position, Quaternion.identity);
        dead.transform.parent = parent;
        Destroy(gameObject);
    }
}

using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
    
    private GameController gameController;
    public GameObject explosion;
    public GameObject playerExplosion;
    public GameObject enemyExplosion;
    public int scoreValue;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if(gameController == null)
        {
            Debug.Log("Cannot find gamecontroller script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Boundary"))||(other.CompareTag("Enemy")))
        {
            return;
        }

        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }

        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }

        if (other.tag == "Enemy")
        {
            Instantiate(enemyExplosion, other.transform.position, other.transform.rotation);
        }

        Destroy(other.gameObject);
        Destroy(gameObject);
        gameController.AddScore(scoreValue);
        
    }
}

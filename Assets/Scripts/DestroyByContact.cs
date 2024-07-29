using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

    private GameController gameController;

    public GameObject playerExplosion;
    public GameObject explosion;
    public int scoreValue;

    void OnTriggerEnter(Collider other) {

        if (other.tag == "boundary") {
            return;
        }

        Instantiate(explosion, transform.position, transform.rotation);

        if (other.tag == "Player") {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
        }


        Destroy(other.gameObject);
        Destroy(gameObject);

        gameController.AddScore(scoreValue);
    }

    void Start() {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");

        if(gameControllerObject != null) {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitter : MonoBehaviour
{
    public ParticleSystem explosion;
    // Start is called before the first frame update
    public void OnCollisionEnter2D(Collision2D other)
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
        if (other.gameObject.tag == "Player")
        {
            PlayerHealth.playerHealth = PlayerHealth.playerHealth - 1f;
        }
    }

}

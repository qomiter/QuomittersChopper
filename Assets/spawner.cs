using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject enemySpawner;
    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Maker", 0f, 25f);
    }
    void Maker()
    {
        GameObject enemyClone = Instantiate(enemySpawner, transform.position, transform.rotation);
        enemyClone.SetActive(true);
  
    }
    // Update is called once per frame
    void Update()
    {

    }

}

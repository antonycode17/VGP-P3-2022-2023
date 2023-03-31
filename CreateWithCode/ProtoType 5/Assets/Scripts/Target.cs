using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorqe = 10;
    private float xRange = 4;
    private float ySpawnpos = -2;
    private GameManager gameManager;
    public int pointValue;
    public ParticleSystem explosionParticle;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPos();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
    private void OnMouseDown()
    {
        if(gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
        
    }
    */
    public void DestroyTarget()
    {
        if(gameManager.isGameActive)
        {
            Debug.Log("hit");
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Sensor" ||  other.gameObject.name == "SwiperObject")
        {
             Destroy(gameObject);
        }
       
        if(!gameObject.CompareTag("Bad") && gameManager.isGameActive && other.gameObject.name == "Sensor")
        {
            gameManager.UpdateLives(-1);

          
        }
    }

    Vector3 RandomForce()
    {
       return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    
    float RandomTorque()
    {
        return Random.Range(-maxTorqe, maxTorqe);
    }

    Vector3 RandomSpawnPos()
    {
       return new Vector3(Random.Range(-xRange, xRange), ySpawnpos);
    }
    
}

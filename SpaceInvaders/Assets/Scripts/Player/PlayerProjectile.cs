using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public float speed;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 projectilePosition = transform.position;
        projectilePosition.y += speed * Time.deltaTime;
        transform.position = projectilePosition;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Enemy"))
        {
            Instantiate(explosion, collider.gameObject.transform.position, Quaternion.identity);
            Destroy(collider.gameObject);
            Destroy(this.gameObject);
        }
        else if(collider.gameObject.CompareTag("Limit"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        else if(collider.gameObject.CompareTag("Bunker"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        else if(collider.gameObject.CompareTag("EnemyProjectile"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(collider.gameObject);
            Destroy(this.gameObject);
        }
    }
}

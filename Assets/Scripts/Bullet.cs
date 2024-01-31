using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float pushForce;
    [SerializeField] private int damage;

    private float despawnTimer;
    private float timeToDespawn;

    // Start is called before the first frame update
    void Start()
    {
        despawnTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        despawnTimer += Time.deltaTime;
        if(despawnTimer >= timeToDespawn) 
        {
            //transform.parent.GetComponent<PoolScript>().DespawnObject(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            Vector2 direction = (Character.Instance.transform.position - collision.transform.position).normalized;
            //collision.GetComponent<Enemy>().Hit(damage, direction, pushForce);
            Destroy(gameObject);
        }
    }
}

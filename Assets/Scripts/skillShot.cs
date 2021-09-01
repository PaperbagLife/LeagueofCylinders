using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillShot : MonoBehaviour
{
    public float lifeSpan;
    public float speed;
    private float DestroyTime;
    public int skillDamage;
    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        lifeSpan = 5f;
        speed = 0.1f;
        skillDamage = 1;
        DestroyTime = lifeSpan + Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + direction * speed;
        if (Time.time > DestroyTime) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "enemy") {
            other.GetComponent<enemy>().takeDamage(skillDamage);
            Destroy(gameObject);
        }
    }

    public void setDirection(Vector3 dir) {
        Debug.Log("set");
        direction = dir;
    }
}

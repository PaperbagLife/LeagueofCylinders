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
    private GameObject owner;
    // Start is called before the first frame update
    void Start()
    {
        lifeSpan = 0.6f;
        speed = 0.12f;
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
            int income = other.GetComponent<enemy>().takeDamage(skillDamage);
            if (income != 0) {
                // Tell parent we got a kill
                owner.gameObject.GetComponent<playerMovement>().getGold(income);
            }

            Destroy(gameObject);
        }
    }

    public void setDirection(Vector3 dir) {
        direction = dir;
    }
    public void setOwner(GameObject parent) {
        owner = parent;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoattack : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    public float speed = 5.0f;
    public int damage = 1;
    private GameObject owner;
    void Start()
    {
        speed = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) {
            Destroy(gameObject);
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, 
            target.transform.position, Time.deltaTime * speed);
        if ((transform.position - target.transform.position).magnitude < 0.8f) {
            int income = target.GetComponent<enemy>().takeDamage(damage);
            if (income != 0) {
                // Tell parent we got a kill
                owner.gameObject.GetComponent<playerMovement>().getGold(income);
            }
            Destroy(gameObject);
        }
    }
    public void setTarget(GameObject t) {
        target = t;
    }
    public void setOwner(GameObject parent) {
        owner = parent;
    }
}

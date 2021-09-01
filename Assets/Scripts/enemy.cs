using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int hp;
    void Start()
    {
        hp = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if(hp <= 0) {
            Destroy(gameObject);
        }
    }
    public void takeDamage(int damage) {
        hp -= damage;
    }
}

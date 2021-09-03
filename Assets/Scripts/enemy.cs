using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int curHP;
    public int maxHP = 10;
    public int loot;
    public Image healthbar;
    void Start()
    {
        curHP = maxHP;
        loot = 300;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int takeDamage(int damage) {
        curHP -= damage;
        healthbar.fillAmount = ((float)curHP) / maxHP;
        if(curHP <= 0) {
            Destroy(gameObject);
            return loot;
        }
        return 0;
    }
}

using UnityEngine;
using System.Collections;

[AddComponentMenu("MyGame/EnemyRocket")]
public class enemyBullet : bullets {
    void OnTriggerEnter(Collider other)
    {
        if (other.tag.CompareTo("Player") != 0)
        {
            return;
        }
        Destroy(this.gameObject);
    }
}

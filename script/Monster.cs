using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float speed = 3f;
    public Transform pointA;
    public Transform pointB;

    private Transform target;

    void Start()
    {
        // Đặt điểm đầu tiên là điểm A
        target = pointA;
    }

    void Update()
    {
        // Di chuyển quái vật đến điểm đích
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        // Nếu quái vật đạt đến điểm đích, đổi hướng
        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            SwitchTarget();
        }
    }

    void SwitchTarget()
    {
        // Đổi hướng di chuyển giữa hai điểm
        target = (target == pointA) ? pointB : pointA;
        FlipDirection();
    }

    void FlipDirection()
    {
        // Đảo hướng của sprite khi đổi hướng di chuyển
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    //Biến mất khi mũi tên chạm vào
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "MuiTen"){
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}

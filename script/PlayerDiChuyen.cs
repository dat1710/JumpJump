using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using System;
using JetBrains.Annotations;
using Unity.Mathematics;

public class PlayerDiChuyen : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public Animator anm;
    public int speed;
    public float traiPhai;
    bool isFacingRight = true;
    public float doCao;
    bool ground;
    public GameObject prefabMuiTen;
    public Transform diemBan;
    public float tocDoMuiTen;
    private float lanBanTruoc;
    public float shootCooldown ;
    public GameObject gameOverObject;
    public GameObject winGame;
    void Start() {
        
    }
    void Update() {
        rb2d.freezeRotation = true;
        diChuyen();
        jump();
        shoot();
        LeoThang();
    }
    
    private void FixedUpdate() {
        if(ktLeoThang){
            rb2d.gravityScale = 0f;
            rb2d.velocity = new Vector2(rb2d.velocity.x,y*speedLeoThang);
            anm.SetTrigger("leoThang");
        }else{
            rb2d.gravityScale = 1;
        }
    }
    void diChuyen(){
        traiPhai = Input.GetAxisRaw("Horizontal");
        rb2d.velocity = new Vector2(speed*traiPhai,rb2d.velocity.y);
        if(isFacingRight == true && traiPhai == -1){
            transform.localScale = new Vector3(-1,1,1);
            isFacingRight = false;
        }
        if(isFacingRight == false && traiPhai ==1){
            transform.localScale = new Vector3(1,1,1);
            isFacingRight = true;
        }
        anm.SetFloat("Running",Mathf.Abs(traiPhai));
    }
    void jump(){
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){
            if(ground == true){
                rb2d.velocity = new Vector2(rb2d.velocity.x,doCao);
                ground = false;
            }
        }          
    }
    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "San"){
            ground = true;
        }
    //Xử lý va chạm với chuong ngai vat
        if(other.gameObject.tag == "Monster" || other.gameObject.tag == "Spikes"){
            // Đặt điểm số về 0 khi chết
            gameObject.SetActive(false);
            gameOverObject.SetActive(true);
        }   
    }
    void shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time-lanBanTruoc > shootCooldown)
        {
            anm.SetTrigger("banCung");
            // Tạo mũi tên và đặt tốc độ cho nó
            GameObject bullet = Instantiate(prefabMuiTen, diemBan.position, diemBan.rotation);
            Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
            bulletRB.velocity = transform.right * tocDoMuiTen;
            lanBanTruoc = Time.time;
            //Đổi hướng mũi tên cùng với hướng của người chơi
            SpriteRenderer bulletSpriteRenderer = bullet.GetComponent<SpriteRenderer>();
            bulletSpriteRenderer.flipX = !isFacingRight;
            float directionMultiplier = isFacingRight == false ? -1f : 1f;
            bulletRB.velocity = new Vector2(directionMultiplier * tocDoMuiTen, 0);
        }
    }
        //Leo thang
    float speedLeoThang = 3f;
    public bool ktThang;
    public bool ktLeoThang;
    float y;
    void LeoThang(){
        y = Input.GetAxis("Vertical");
        if(ktThang && math.abs(y)>0){
            ktLeoThang = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Thang"){
            ktThang = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Thang"){
            ktThang = false;
            ktLeoThang = false;
        }
        //ChienThang
        if(other.gameObject.tag == "Win"){
            gameObject.SetActive(false);
            winGame.SetActive(true);
        }
    }
}

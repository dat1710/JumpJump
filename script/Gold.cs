using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    private AudioManager audioManager;
    private void Awake() {
    GameObject[] audioObjects = GameObject.FindGameObjectsWithTag("audio");

        // Kiểm tra xem có ít nhất một đối tượng với tag "audio" hay không
        if (audioObjects.Length > 0)
        {
            // Chọn đối tượng đầu tiên trong mảng và gọi GetComponent
            audioManager = audioObjects[0].GetComponent<AudioManager>();
        } 
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            audioManager.PlaySFX(audioManager.coinClip);
            Destroy(gameObject);
        }
    }
}


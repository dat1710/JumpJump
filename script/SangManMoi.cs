using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SangManMoi : MonoBehaviour
{
    public float thoiGianChoChuyenScene = 1f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Tắt nhân vật
            other.gameObject.SetActive(false);

            // Chuyển scene sau khoảng thời gian chờ
            StartCoroutine(ChuyenSceneSauThoiGian());
        }
    }

    IEnumerator ChuyenSceneSauThoiGian()
    {
        // Chờ thời gian cần thiết trước khi chuyển scene
        yield return new WaitForSeconds(thoiGianChoChuyenScene);

        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            // Chuyển scene
            SceneManager.LoadScene(nextSceneIndex);
}
}

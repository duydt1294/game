using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nexttt : MonoBehaviour
{
    public string Next; // Tên của scene bạn muốn chuyển tới

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Kiểm tra xem có phải là nhân vật (Player) không
        if (other.CompareTag("Player"))
        {
            // Chuyển tới scene khác
            SceneManager.LoadScene(Next);
        }
    }
}

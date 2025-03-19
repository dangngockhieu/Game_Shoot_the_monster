using UnityEngine;
// Tính toán kích thước của màn hình để điều chính kích thước của Background trong Level1 và Level2
public class BG : MonoBehaviour
{
    void Start()
    {
        var height = Camera.main.orthographicSize * 2f; // Tính chiều cao
        var width = height * Screen.width / Screen.height; // Tính chiều rộng
        transform.localScale = new Vector3(width, height, 0f); // Điều chỉnh kích thước của background
    }
}

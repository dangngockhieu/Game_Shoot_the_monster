using UnityEngine;
using System.Collections;
// Dùng để Cuộn background trong Level1 và Level2
public class BGscrolling : MonoBehaviour
{
    private const float scrollSpeed = 0.05f; // Tóc độ cuộn background
    private Material mat; // Lưu trữ thông tin về vật liệu của background
    private Vector2 offset = Vector2.zero; // Lưu trữ thông tin về vị trí cuộn background
    void Awake()
    {
        mat = GetComponent<Renderer>().material; // Lấy thông tin về vật liệu của background
    }
    void Start()
    {
        offset = mat.GetTextureOffset("_MainTex"); // Lấy thông tin về vị trí cuộn background
    }

    void Update()
    {
        offset.y += scrollSpeed * Time.deltaTime; // Cập nhật vị trí background
        mat.SetTextureOffset("_MainTex", offset); // Nếu background đã cuộn hết thì quay lại vị trí ban đầu
    }
}
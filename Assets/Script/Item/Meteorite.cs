using UnityEngine;
// Quản lý thiên thạch
public class Meteorite : MonoBehaviour
{
    public float fallSpeed = 3f; // Tốc độ rơi của thiên thạch

    void Update()
    {
        // Di chuyển thiên thạch xuống dưới
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

        // Kiểm tra nếu thiên thạch chạm vào màn hình phía dưới
        Vector3 screenBottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        if (transform.position.y < screenBottomLeft.y)
        {
            Destroy(gameObject); // Hủy thiên thạch
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Nếu thiên thạch va chạm với người chơi
        if (collision.CompareTag(Constant.PLAYER_TAG))
        {
            Destroy(gameObject); // Hủy thiên thạch
        }
    }
}
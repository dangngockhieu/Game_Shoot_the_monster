using UnityEngine;
// Quản lý vật phẩm, cái này nếu người chơi thu thập được thì sẽ nhân đôi đạn
public class PowerUp : MonoBehaviour
{
    public enum PowerUpType { DoubleBullet } // Loại vật phẩm
    public PowerUpType powerUpType; // Loại vật phẩm hiện tại
    public float fallSpeed = 3f; // Tốc độ rơi của vật phẩm
    public float doubleBulletDuration = 7f; // Thời gian hiệu ứng x2 đạn

    void Update()
    {
        // Di chuyển vật phẩm xuống dưới
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

        // Kiểm tra nếu vật phẩm chạm vào màn hình phía dưới
        Vector3 screenBottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        if (transform.position.y < screenBottomLeft.y)
        {
            Destroy(gameObject); // Hủy vật phẩm
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Nếu vật phẩm va chạm với người chơi
        if (collision.CompareTag(Constant.PLAYER_TAG))
        {
            Player player = collision.GetComponent<Player>();
            if (player != null && powerUpType == PowerUpType.DoubleBullet)
            {
                player.ActivateDoubleBullet(doubleBulletDuration); // Kích hoạt x2 đạn
            }
            Destroy(gameObject); // Hủy vật phẩm
        }
    }
}
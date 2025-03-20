using UnityEngine;
using System.Collections;
// Quản lý Người chơi
public class Player : MonoBehaviour
{
    private float playerSpeed = 5f; // Tốc độ di chuyển của người chơi
    Vector3 screenBounds;
    Vector3 playerMovement;
    private Rigidbody2D rb;
    private Audio_Manager audioManager; // Tham chiếu đến Audio_Manager
    [SerializeField] private GameObject bullet; // Đạn của người chơi
    private bool canShoot = true; // Điều khiển Bắn đạn
    private float shootCooldown = 0.2f; // Thời gian ngắn nhất giữa các lần bắn đạn liên tục 
    private bool isDoubleBulletActive = false; // Trạng thái x2 đạn

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        // Âm thanh khi bắn đạn
        audioManager = GameObject.FindWithTag(Constant.AUDIO_TAG).GetComponent<Audio_Manager>();
    }

    void Start()
    {
        // Xác định giới hạn màn hình để gioới hạn di chuyển của người chơi
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    // Kích hoạt x2 đạn
    public void ActivateDoubleBullet(float time)
    {
        if (!isDoubleBulletActive)
        {
            isDoubleBulletActive = true;
            StartCoroutine(DoubleBulletCoroutine(time));
        }
    }

    IEnumerator DoubleBulletCoroutine(float time)
    {
        yield return new WaitForSeconds(time); // Chờ trong thời gian đã chỉ định
        isDoubleBulletActive = false; // Đặt lại trạng thái x2 đạn sau thời gian đã chỉ định
    }
    void Update()
    {
        Di_chuyen();
        Ban();
    }

    // Bắn đạn
    void Ban()
    {
        if (canShoot && Input.GetKeyDown(KeyCode.Space)) // Bắn đạn khi bấm phím Cách
        {
            if (isDoubleBulletActive) // Nếu X2 đạn
            {
                // Bắn x2 đạn
                Instantiate(bullet, transform.position + Vector3.left * 0.5f, Quaternion.identity);
                Instantiate(bullet, transform.position + Vector3.right * 0.5f, Quaternion.identity);
            }
            else
            {
                // Bắn 1 đạn
                Instantiate(bullet, transform.position, Quaternion.identity);
            }
            // Đạn ko xoay
            canShoot = false; // Ngăn bắn liên tục
            StartCoroutine(ShootCooldown()); // Bắt đầu thời gian chờ giữa các lần bắn
            if (audioManager != null)
            {
                audioManager.PlaySfx(audioManager.shootClip); // Phát âm thanh bắn đạn
            }
        }
        else if (canShoot && (!Input.GetKeyDown(KeyCode.Space)) && Input.GetMouseButtonDown(0)) // Bắn đạn khi bấm chuột trái
        {
            if (isDoubleBulletActive)
            {
                // Bắn x2 đạn
                Instantiate(bullet, transform.position + Vector3.left * 0.2f, Quaternion.identity);
                Instantiate(bullet, transform.position + Vector3.right * 0.2f, Quaternion.identity);
            }
            else
            {
                // Bắn 1 đạn
                Instantiate(bullet, transform.position, Quaternion.identity);
            }
            // Đạn ko xoay
            canShoot = false; // Ngăn bắn liên tục
            StartCoroutine(ShootCooldown()); // Bắt đầu thời gian chờ giữa các lần bắn
            if (audioManager != null)
            {
                audioManager.PlaySfx(audioManager.shootClip); // Phát âm thanh bắn đạn
            }
        }
    }
    // Delay khi bắn đạn liên tục
    IEnumerator ShootCooldown()
    {
        yield return new WaitForSeconds(shootCooldown); // Chờ thời gian chờ
        canShoot = true; // Cho phép bắn lại
    }

    void Di_chuyen()
    {
        // Xử lý di chuyển của người chơi theo phím WASD hoặc các phím mũi tên
        playerMovement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * playerSpeed * Time.deltaTime;
        transform.Translate(playerMovement);

        //Giới bạn di chuyển của người chơi ko đi qua rìa màn hình
        float clamedX = Mathf.Clamp(transform.position.x, -screenBounds.x, screenBounds.x);
        float clamedY = Mathf.Clamp(transform.position.y, -screenBounds.y, screenBounds.y);
        Vector3 Pos = transform.position;
        Pos.x = clamedX;
        Pos.y = clamedY;
        transform.position = Pos;
    }
    // Xử lý va chạm với các đối tượng khác
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Constant.Enemy_BULLET_TAG)) // Va chạm với đạn của kẻ thù
        {
            gameObject.SetActive(false); // Vô hiệu hóa Player
            if (Player_Manager.Instance != null)
            {
                Player_Manager.Instance.TriggerGameOver(); // Xử lý Game Over
            }
            gameObject.SetActive(false); // Vô hiệu hóa Player
        }
        // Va chạm với đạn của kẻ thù
        else if (collision.CompareTag(Constant.ENEMY_TAG) || collision.CompareTag(Constant.METEORITE_TAG))
        {
            if (audioManager != null)
            {
                audioManager.PlaySfx(audioManager.collideClip);
            }
            gameObject.SetActive(false); // Vô hiệu hóa Player
            if (Player_Manager.Instance != null)
            {
                Player_Manager.Instance.TriggerGameOver();
            }
            gameObject.SetActive(false); // Vô hiệu hóa Player
        }
    }
}

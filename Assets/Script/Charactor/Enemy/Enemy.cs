
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Enemy : MonoBehaviour
{
    // Script này dùng điền khiển hành vi của Enemy và máu của nó
    private float enemySpeed = 3f, chaseSpeed = 7f; // tốc độ địch, tốc độ lúc đâm vào ng chơi

    [SerializeField] private GameObject bullet;
    public int enemyHealthMax; // máu của kẻ địch (để int)
    private int enemyHealth;
    private bool canShoot = true; // Flag to control shooting
    private float shootCooldown = 1f; // Cooldown time between shots
    Transform playerPosition; // biến chứa vị trí của người chơi
    private Vector3 originalPosition; // Vị trí ban đầu của địch
    private bool isChasingPlayer = false; // Flag to control chasing behavior
    public Mau thanhMau;
    private List<GameObject> bullets = new List<GameObject>(); // Danh sách quản lý các viên đạn
    void Start()
    {
        enemyHealth = enemyHealthMax; // Khởi tạo máu của địch  
        originalPosition = transform.position; // Lưu vị trí ban đầu của địch
        GameObject player = GameObject.FindWithTag(Constant.PLAYER_TAG); // Tìm Player GameObject 
        if (player != null)
        {
            playerPosition = player.transform; // Lấy vị trí của Player để bám theo
        }
        thanhMau.SetHealth(enemyHealth, enemyHealthMax); // Cập nhật thanh máu của địch
        StartCoroutine(EnemyShoot()); // gọi hàm EnemyShoot để tạo ra đạn
        StartCoroutine(ChasePlayerRoutine()); // gọi hàm ChasePlayerRoutine để đuổi theo người chơi
    }
    // Bắn đạn
    IEnumerator EnemyShoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootCooldown); // Chờ 1 khoảng thời gian để có thể bắn tiếp
            if (canShoot && playerPosition != null)
            {
                Vector3 temp = transform.position;
                temp.y -= 0.5f;

                if (bullet != null)
                {
                    GameObject bulletInstance = Instantiate(bullet, temp, Quaternion.identity); // Tạo viên đạn
                    bullets.Add(bulletInstance);
                }
            }
        }
    }

    IEnumerator ChasePlayerRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(10f, 15f)); // Random từ 10 đến 15s thì địch sẽ lao về Người chơi
            if (playerPosition != null)
            {
                Vector3 targetPosition = playerPosition.position; // Lưu vị trí hiện tại của người chơi
                isChasingPlayer = true;
                // Đuổi theo người chơi
                while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, targetPosition, chaseSpeed * Time.deltaTime);
                    yield return null;
                }
                yield return new WaitForSeconds(1f); // Đợi 1 giây trước khi quay lại vị trí ban đầu
                // Quay lại vị trí ban đầu
                while (Vector3.Distance(transform.position, originalPosition) > 0.1f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, originalPosition, enemySpeed * Time.deltaTime);
                    yield return null;
                }
                isChasingPlayer = false;
            }
        }
    }

    void Update()
    {
        if (enemyHealth <= 0)
        {
            if (thanhMau != null)
            {
                thanhMau.SetHealth(0, enemyHealthMax); // Cập nhật thanh máu trước khi tắt Enemy
            }
            gameObject.SetActive(false);
        }

        if (!isChasingPlayer)
        {
            Di_chuyen();
        }
    }

    void Di_chuyen()
    {
        if (playerPosition == null)
        {
            return;
        }

        // Di chuyển theo phương x để bám theo người chơi
        Vector3 targetPosition = new Vector3(playerPosition.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, enemySpeed * Time.deltaTime);
    }
    // Xử lý va chạm
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Constant.PLAYER_BULLET_TAG))
        { //Nếu Enemy va chạm với đạn của người chơi thì bị trừ 1 máu
            enemyHealth = Mathf.Max(0, enemyHealth - 1); // Đảm bảo enemyHealth không âm
            thanhMau.SetHealth(enemyHealth, enemyHealthMax);
            // Nếu Enemy chết thì các viên đạn vừa bắn của nó mà đang trong quá trình di chuyển sẽ bị hủy ngay lập tức
            if (enemyHealth <= 0)
            {
                foreach (GameObject bullet in bullets)
                {
                    if (bullet != null)
                    {
                        Destroy(bullet);
                    }
                }

                if (Enemy_Manager.Instance != null)
                {
                    Enemy_Manager.Instance.Trigger();
                }
                Destroy(gameObject);
            }
        }
    }

}


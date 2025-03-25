
using UnityEngine;
using System.Collections;
public class Enemy1 : MonoBehaviour
{
    // Script này dùng điền khiển hành vi của Enemy và máu của nó
    public float enemySpeed, speeds; // tốc độ địch, tốc độ lúc đâm vào ng chơi

    private Rigidbody2D rb; // Rigidbody của địch
    [SerializeField] private GameObject bullet;
    public int enemyHealth; // máu của kẻ địch (để int)
    private bool canShoot = true; // Flag to control shooting
    public float shootCooldown = 1f; // Cooldown time between shots
    Transform playerPosition; // biến chứa vị trí của người chơi
    private Vector3 originalPosition; // Vị trí ban đầu của địch
    private bool isChasingPlayer = false; // Flag to control chasing behavior

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        originalPosition = transform.position; // Lưu vị trí ban đầu của địch
        GameObject player = GameObject.FindWithTag("Player"); // Find the player GameObject by tag
        if (player != null)
        {
            playerPosition = player.transform; // Get the player's transform
        }
        else
        {
            Debug.LogError("Player not found!");
        }

        StartCoroutine(EnemyShoot()); // gọi hàm EnemyShoot để tạo ra đạn
        StartCoroutine(ChasePlayerRoutine()); // gọi hàm ChasePlayerRoutine để đuổi theo người chơi
    }

    IEnumerator EnemyShoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootCooldown);
            if (canShoot && playerPosition != null)
            {
                Vector3 temp = transform.position;
                temp.y -= 0.5f;

                if (bullet != null)
                {
                    Instantiate(bullet, temp, Quaternion.identity);
                    Debug.Log("Bullet instantiated");
                }
                else
                {
                    Debug.LogError("Bullet is NULL!");
                }
            }
        }
    }

    IEnumerator ChasePlayerRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(10f, 15f));
            if (playerPosition != null)
            {
                Vector3 targetPosition = playerPosition.position; // Lưu vị trí hiện tại của người chơi
                isChasingPlayer = true;
                while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, targetPosition, speeds * Time.deltaTime);
                    yield return null;
                }
                yield return new WaitForSeconds(1f); // Đợi 1 giây trước khi quay lại vị trí ban đầu
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
        if (!isChasingPlayer)
        {
            Di_chuyen();
        }

        if (enemyHealth <= 0)
            gameObject.SetActive(false);
    }

    void Di_chuyen()
    {
        if (playerPosition == null)
        {
            Debug.LogWarning("playerPosition is NULL! Enemy can't find Player.");
            return;
        }

        // Di chuyển theo phương x để bám theo người chơi
        Vector3 targetPosition = new Vector3(playerPosition.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, enemySpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Constant.PLAYER_BULLET_TAG)) //Nếu Enemy va chạm với đạn của người chơi thì bị trừ 1 máu
            enemyHealth -= 1;
    }

}


using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Enemy_Manager : MonoBehaviour
{
    public static Enemy_Manager Instance { get; private set; }
    public GameObject Enemy;
    public int sceneToLoad; // Scene cần chuyển đến

    void Start()
    {   // Nếu Enemy không hoạt động, kích hoạt lại Enemy
        if (!Enemy.activeInHierarchy)
        {
            Enemy.SetActive(true);
        }
    }

    void Awake()
    {   // Đảm bảo chỉ có một đối tượng Enemy_Manager tồn tại trong trò chơi
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject); // Xóa đối tượng nhưng không ngay lập tức
            return;
        }

        Enemy = GameObject.FindGameObjectWithTag(Constant.ENEMY_TAG);
    }
    // Khi đối tượng Enemy_Manager bị hủy, đặt Instance về null
    void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }
    // Kiểm tra xem Enemy có đang hoạt động trong Scene ko
    public bool enemyIsAlive()
    {
        return Enemy.activeInHierarchy;
    }

    public void Trigger()
    {
        StartCoroutine(Delayed());
    }

    private IEnumerator Delayed()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(sceneToLoad);
    }
}
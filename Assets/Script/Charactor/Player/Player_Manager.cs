using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
// Quản lý Người chơi
public class Player_Manager : MonoBehaviour
{
    public static Player_Manager Instance { get; private set; }
    public GameObject Player;

    void Start()
    {   // Nếu người chơi không hoạt động, kích hoạt lại người chơi 
        if (!Player.activeInHierarchy)
        {
            Player.SetActive(true);
        }
    }

    void Awake()
    { // Đảm bảo chỉ có một đối tượng Player_Manager tồn tại trong trò chơi
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject); // Xóa đối tượng nhưng không ngay lập tức
            return;
        }

        Player = GameObject.FindGameObjectWithTag(Constant.PLAYER_TAG);
    }
    // Khi đối tượng Player_Manager bị hủy, đặt Instance về null
    void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }
    // Kiểm tra xem Player có đang hoạt động trong Scene ko
    public bool playerIsAlive()
    {
        return Player.activeInHierarchy;
    }
    // Chuyển sang scene GameOver
    public void TriggerGameOver()
    {
        StartCoroutine(DelayedGameOver());
    }
    // Đợi 5 giây trước khi chuyển sang scene GameOver
    private IEnumerator DelayedGameOver()
    {
        yield return new WaitForSeconds(5f); // Đợi 5 giây
        SceneManager.LoadScene(1); // Chuyển về Scene 1
    }
}
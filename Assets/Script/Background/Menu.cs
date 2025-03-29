using UnityEngine;
using UnityEngine.SceneManagement;
// Quản lý các UI trong Game
public class Menu : MonoBehaviour
{
    // Nếu bấm "Play" thì chuyển từ màn hình Menu qua Màn hình để chơi Level1
    public void PlayGame()
    {
        SceneManager.LoadScene(3);
    }
    // Nếu bấm "Exit" thì thoát khỏi Game
    public void ExitGame()
    {
        Application.Quit();
    }
    // Trở về màn hình Menu ban đầu
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    // Chuyển qua Level tiếp theo
    public void Next()
    {
        SceneManager.LoadScene(4);
    }
}
# 🚀 Shoot The Monster - Unity 2D Space Shooter

[![Unity](https://img.shields.io/badge/Unity-2022.3%2B-blue.svg)](https://unity.com/)
[![Render Pipeline](https://img.shields.io/badge/Pipeline-URP-orange.svg)](https://unity.com/srp/Universal-Render-Pipeline)
[![Language](https://img.shields.io/badge/Language-C%23-brightgreen.svg)](https://docs.microsoft.com/en-us/dotnet/csharp/)

> **Shoot The Monster** là tựa game bắn súng không gian 2D (Space Shooter) cuộn dọc tốc độ cao, được phát triển trên nền tảng Unity kết hợp đồ họa Universal Render Pipeline (URP). Người chơi điều khiển phi thuyền chiến đấu, tiêu diệt quái vật ngoài không gian, né tránh các đợt mưa thiên thạch và thu thập vật phẩm nâng cấp hỏa lực.

---

## 🎮 Tính năng nổi bật & Gameplay

- **Điều khiển nhạy bén**: Di chuyển phi thuyền mượt mà trong giới hạn khung hình camera, né tránh đạn và quái vật.
- **Cơ chế kẻ địch thông minh (Monster AI)**:
  - Quái vật di chuyển theo đội hình và bắn đạn về phía người chơi.
  - Sau khoảng thời gian ngẫu nhiên, quái vật có khả năng lao thẳng (Dash) bất ngờ về phía phi thuyền.
- **Chướng ngại vật ngẫu nhiên**: Các mảnh thiên thạch (Meteorite) lao xuống liên tục từ rìa trên màn hình đòi hỏi phản xạ cao.
- **Hệ thống Buff (PowerUp)**:
  - Thu thập vật phẩm màu vàng rơi từ không gian để kích hoạt hiệu ứng **x2 Đạn kép** trong vòng **5 giây**.
- **Hiệu ứng & Âm thanh sống động**:
  - Tích hợp hiệu ứng âm thanh phong phú (BGM Menu, Victory, GameOver, âm thanh bắn, va chạm, nổ).
  - Background cuộn vô tận (Infinite Scrolling Background) tạo cảm giác bay liên tục trong vũ trụ.
- **Giao diện & Flow hoàn chỉnh**: Màn hình Menu bắt đầu, HUD trạng thái máu/điểm, màn hình Victory và Game Over.

---

## 🕹️ Hướng dẫn điều khiển (Controls)

| Thao tác | Phím điều khiển |
| :--- | :--- |
| **Di chuyển** | `W`, `A`, `S`, `D` hoặc các phím Mũi tên (`↑`, `←`, `↓`, `→`) |
| **Bắn đạn** | Phím Cách (`Space`) hoặc Chuột trái (`Left Mouse`) |
| **Điều hướng Menu** | Chuột trái chọn nút Play / Replay / Exit |

---

## 📂 Cấu trúc dự án (Project Structure)

```plaintext
Game_Shoot_the_monster/
├── Assets/
│   ├── Materials/         # Material & shader cho sprites và lighting URP
│   ├── Prefab/            # Prefab người chơi, quái vật, đạn, thiên thạch, item
│   ├── Scenes/            # Các Scene: MenuScene, GameScene, GameOver, Victory
│   ├── Script/
│   │   ├── Audio/         # Audio_Manager, Audio_Menu, Audio_GameOver, Audio_Victory
│   │   ├── Background/    # BG scrolling và quản lý background
│   │   ├── Bullet/        # Xử lý đạn người chơi (Player_Bullet) & quái (Enemy_Bullet)
│   │   ├── Charactor/     # Player controller, Enemy AI, quản lý máu & spawn wave
│   │   ├── Item/          # Meteorite (thiên thạch), PowerUp (x2 đạn), Spawner
│   │   └── Constant.cs    # Định nghĩa hằng số Tag toàn cục
│   ├── Settings/          # Cấu hình Universal Render Pipeline (URP)
│   ├── Sprite/            # Toàn bộ hình ảnh phi thuyền, quái vật, đạn, background, UI
│   └── TextMesh Pro/      # Tài nguyên font chữ UI TextMeshPro
├── Packages/              # Unity Package Manager manifest & lock
├── ProjectSettings/       # Cài đặt input, tag, collision matrix, physics, player
└── README.md              # Tài liệu giới thiệu và hướng dẫn dự án
```

---

## 🛠️ Yêu cầu cài đặt & Khởi chạy (Getting Started)

1. **Phiên bản Unity khuyến nghị**: Unity `2022.3 LTS` (hoặc mới hơn) có cài đặt **Universal Render Pipeline (URP)**.
2. **Cách mở dự án**:
   - Mở **Unity Hub**.
   - Chọn **Add** > **Add project from disk**.
   - Trỏ vào thư mục `Game_Shoot_the_monster`.
   - Chọn phiên bản Unity tương ứng và mở dự án.
3. **Chạy game**:
   - Trong cửa sổ `Project`, mở thư mục `Assets/Scenes/`.
   - Mở scene mở đầu (Menu / Start scene) hoặc `MainScene`.
   - Bấm nút **Play** (`Ctrl + P`) trên thanh công cụ Unity để trải nghiệm!

---

## 👤 Tác giả
- **Đặng Ngọc Khiêu** (dangngockhieu)
- GitHub: [@dangngockhieu](https://github.com/dangngockhieu)

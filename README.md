# ADB Multi-Device Control Tool (Official Integration for Michanger.io)

[![Official Website](https://img.shields.io/badge/Official-Michanger.io-blue?style=for-the-badge&logo=google-chrome)](https://michanger.io)
[![Release](https://img.shields.io/github/v/release/CPIDNGMP/API_Michanger.io?style=for-the-badge&color=green)](https://github.com/CPIDNGMP/API_Michanger.io/releases)
[![License](https://img.shields.io/badge/License-LGPL--2.1-yellow?style=for-the-badge)](License-LGPL.txt)
[![.NET](https://img.shields.io/badge/.NET-4.8-purple?style=for-the-badge&logo=dotnet)](https://dotnet.microsoft.com/download/dotnet-framework/net48)

**ADB Multi-Device Control Tool** là giải pháp quản lý và tự động hoá hàng loạt thiết bị Android chuyên nghiệp, được thiết kế đồng bộ hoàn hảo với hệ sinh thái **Michanger Pro** và **OneChanger**.

---

## 🌟 Tính Năng Nổi Bật

- **Điều Khiển Hàng Loạt:** Quản lý hàng trăm thiết bị Android qua giao diện C# .NET 4.8 mượt mà.
- **Tích Hợp API:** Kết nối trực tiếp với Michanger Pro và OneChanger để đổi thông tin thiết bị (Fingerprint).
- **Quản Lý SOCKS5:** Cấu hình Proxy riêng biệt cho từng máy hoặc hàng loạt chỉ với một click.
- **Luồng GeminiPro (Automation):** Kịch bản tự động hóa 4 bước: 
  1. Wipe Data App (Dọn sạch rác app cũ)
  2. Change Device Info (Đổi cấu hình máy mới)
  3. Config SOCKS5 (Fake IP bảo mật)
  4. Launch App (Tự động mở ứng dụng mục tiêu)
- **Plugin Flow System:** Tự tạo luồng tự động hóa riêng — chỉ cần implement interface `IFlow`, không cần sửa core.
- **ADB Script Editor:** Tự xây dựng kịch bản thao tác phức tạp (Tap, Swipe, Image Match, Text Match...) không cần lập trình.
- **Real-time Logs:** Theo dõi trạng thái chi tiết của từng thiết bị theo thời gian thực.

---

## 🚀 Quick Start

### 1. Yêu Cầu Hệ Thống
- Windows 10/11
- .NET Framework 4.8 Runtime
- ADB (Android Debug Bridge) — thiết bị đã bật **USB Debugging**
- Michanger Pro hoặc OneChanger đang chạy trên máy

### 2. Chạy Nhanh
1. Giải nén và chạy `MichangerAPIControl.exe`
2. Click nút **Michanger Pro** hoặc **OneChanger** (đèn Status phải hiện xanh **ON**)
3. Cắm điện thoại → bấm **Scan Devices**
4. Tick chọn các máy → bấm **RUN GEMINIPRO**

### 3. Cấu hình OneChanger (Khuyến nghị trước khi chạy)
- Bật tùy chọn **"Logout gmail trước khi change"**
- Thêm vào Wipe list: `com.google.android.apps.googleone`, `com.google.android.apps.subscriptions.red`

---

## 🛠 Tự Tạo Flow Tự Động (Custom Flow)

Hệ thống **Plugin Flow** cho phép bạn thêm luồng tự động riêng mà không cần sửa code gốc:

```csharp
// Tạo file MyFlow.cs bất kỳ trong project
using MichangerAPIControl.Automation.Flows;

public class MyCustomFlow : IFlow
{
    public string Name => "My Custom Flow";

    public async Task ExecuteAsync(BaseApiClient api, string serial,
        Action<string> log, Action<string, Color> updateStatus)
    {
        log($"[MyFlow] Running on {serial}");
        // ... your logic here ...
        updateStatus("Done", Color.LightGreen);
    }
}
```

Flow sẽ **tự động xuất hiện** trong UI — không cần đăng ký thêm gì. Xem hướng dẫn đầy đủ tại [`Docs/HuongDanSuaCode.md`](Docs/HuongDanSuaCode.md).

---

## 📥 Tải Về (Download)

👉 **[GitHub Releases](https://github.com/CPIDNGMP/API_Michanger.io/releases)**

---

## 📚 Tài Liệu

| Tài liệu | Mô tả |
|---|---|
| [Hướng Dẫn Sử Dụng](Docs/HuongDanSuDung.md) | Hướng dẫn toàn bộ tính năng cho người dùng |
| [Hướng Dẫn Sửa Code](Docs/HuongDanSuaCode.md) | API Reference, kiến trúc, cách mở rộng |
| [CONTRIBUTING](CONTRIBUTING.md) | Hướng dẫn đóng góp open-source |

---

## 📞 Liên Hệ & Hỗ Trợ
- **Website:** [https://michanger.io](https://michanger.io)
- **Hướng dẫn chi tiết:** [Xem tại đây](https://michanger.io/guide/adb-control)

## 📦 Thư Viện Sử Dụng
- [KAutoHelper](libs/KAutoHelper.dll) — ADB helper: Tap, Swipe, Screenshot, Key events
- [Emgu.CV](https://emgu.com) — OpenCV wrapper cho .NET: Image matching
- [ADB (Android Debug Bridge)](https://developer.android.com/tools/adb) — Google Android SDK

---

*Tool này là companion chính thức của hệ sinh thái [Michanger.io](https://michanger.io), được phát triển để hỗ trợ người dùng quản lý và tự động hóa thiết bị Android một cách hiệu quả và chuyên nghiệp.*

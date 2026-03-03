# ADB Multi-Device Control Tool (Official Integration for Michanger.io)

[![Official Website](https://img.shields.io/badge/Official-Michanger.io-blue?style=for-the-badge&logo=google-chrome)](https://michanger.io)
[![Release](https://img.shields.io/github/v/release/CPIDNGMP/API_Michanger.io?style=for-the-badge&color=green)](https://github.com/CPIDNGMP/API_Michanger.io/releases)

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
- **Real-time Logs:** Theo dõi trạng thái chi tiết của từng thiết bị theo thời gian thực.

---

## 🚀 Hướng Dẫn Sử Dụng Nhanh

### 1. Cấu hình OneChanger (Bắt buộc)
Để tối ưu hoá sạch sẽ nhất, hãy bật các tuỳ chọn sau trên OneChanger:
- Tích chọn **"Logout gmail trước khi change"**.
- Thêm các package hệ thống vào danh sách Wipe:
    - `com.google.android.apps.googleone`
    - `com.google.android.apps.subscriptions.red`

### 2. Thao tác trên Tool Control
1. **Chọn Tool:** Click nút `Michanger Pro` hoặc `OneChanger` (Đèn Status phải hiện xanh **ON**).
2. **Quét thiết bị:** Bấm `Scan Devices` để nhận diện các máy đang cắm cáp.
3. **Thiết lập:** Điền Brand/Model muốn đổi và dán SOCKS5 vào ô tương ứng.
4. **Chạy luồng:** Bấm `RUN GEMINIPRO` để thực hiện quy trình tự động hoàn toàn.

---

## 📥 Tải Về (Download)

Bạn có thể tải phiên bản đóng gói sẵn (EXE) tại mục:
👉 **[GitHub Releases](https://github.com/CPIDNGMP/API_Michanger.io/releases)**

---

## 🛠 Yêu Cầu Hệ Thống
- Windows 10/11
- .NET 4.8 Runtime
- ADB (Android Debug Bridge) đã được cài đặt và thiết bị đã bật USB Debugging.

---

## 📞 Liên Hệ & Hỗ Trợ
- **Website:** [https://michanger.io](https://michanger.io)
- **Hướng dẫn chi tiết:** [Xem tại đây](https://michanger.io/guide/adb-control)

*Dự án được phát triển nhằm mục đích hỗ trợ cộng đồng làm MMO, App Farming và Automation chuyên nghiệp.*

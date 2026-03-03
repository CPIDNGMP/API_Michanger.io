# Hướng Dẫn Sửa Code & Phát Triển Cấu Trúc (Developer Guide)

Chào mừng các nhà phát triển đến với mã nguồn mở của **ADB Multi-Device Control Tool**.
Dự án này được xây dựng trên nền tảng **.NET 8.0** kết hợp **C# Windows Forms (WinForms)** với triết lý thiết kế giao diện Glassmorphism / Dark Mode, hướng đến tính module hóa, linh hoạt chuyển đổi giữa các Backend API.

Dưới đây là sơ đồ lõi và hướng dẫn can thiệp vào mã nguồn:

---

## 1. Cấu Trúc Lõi Dự Án (Architecture)

Toàn bộ Backend được chia nhỏ thành các thư mục:

- `MichangerAPIControl\MichangerAPIControl\MichangerAPIControl`
  - `Form1.cs / Form1.Designer.cs`: Màn hình giao diện chính (View & Presenter).
  - `Forms/DeviceSettingsForm.cs`: Bảng Panel Cài đặt nhỏ dạng cửa sổ nổi (Popup Dialoug).
  - `Controls/DeviceControlItem.cs`: Giao diện Component tùy chỉnh cho Từng Hàng Điện Thoại (Custom UserControl).
  - `src/ApiClients`: Gói các phương thức gửi HTTP Requests đến Tool Gốc (OneChanger, Michanger Pro).
  - `src/Automation`: Luồng Script Kịch bản Tự động (ví dụ: `GeminiProFlow.cs`).
  - `src/Core`: Thư viện lõi nền tảng (Ví dụ xử lý ADB lệnh nền: `AdbClient.cs`).
  - `src/Models`: Nơi xử lý dữ liệu và Lưu Trữ Ổ cứng (JSON/AppSettings).

---

## 2. Hướng Dẫn Sửa Mã Giao Diện (UI Form1)

Giao diện Form1 không tuân theo các Palette chuẩn cũ của WinForms mà tự can thiệp render màu FlatStyle tĩnh.

### A. Nút Công Cụ Bị Lỗi Hiển Thị, Cần Đổi Màu
WinForms tự động reset màu `BackColor` thành xám đen khi nút bị set thuộc tính `Enabled = false`. Vì vậy, để làm nổi bật nút API đang kích hoạt, ta bắt buộc phải đánh dấu bằng mã lệnh trong `SwitchTool()` (**Dòng 115, Form1.cs**).
```csharp
// Đóng Khung và tô màu Custom
BtnToolMichanger.BackColor = (toolIndex == 0) ? Color.FromArgb(0, 122, 204) : Color.FromArgb(30, 35, 50);
BtnToolMichanger.FlatAppearance.BorderColor = (toolIndex == 0) ? Color.Cyan : Color.FromArgb(60, 65, 80);
BtnToolMichanger.FlatAppearance.BorderSize = (toolIndex == 0) ? 2 : 1;
```

### B. Can Thiệp Cơ Chế Nhận Diện Phần Mềm (Polling)
Phần nhận diện `Status: ON` hoặc `OFF` sử dụng Vòng Lặp Bất Đồng Bộ `Task PollApiStatusAsync()`.
- Để thêm tool mới (Ví dụ *TwoChanger*): Cần khai báo thêm Process Name vào mảng `GetProcesses()` và khai báo Port (9999) mở cho API của phần mềm đó.

---

## 3. Hướng Dẫn Thêm Mới Client API

Để phần mềm hỗ trợ thêm một tool đổi máy khác ngoài Michanger và OneChanger, làm theo 3 bước:

1. **Thêm API Class Mới:** Tạo file `NewToolApiClient.cs` kế thừa `BaseApiClient`.
2. **Khai báo URL chuẩn:**
   ```csharp
   public async Task<bool> ChangeDeviceAsync(...) 
   {
       // Xây dựng URL động
       string url = $"http://127.0.0.1:9999/api?action=change&brand={brand}...";
       return await SendGetRequestAsync(url);
   }
   ```
3. **Gọi lên Form1:** Tạo thêm 1 `_newToolApi`, kéo thêm Button vào Designer, và bổ sung Index mới vào `SwitchTool(int index)` là xong. Giao diện sẽ tự động hiểu và truyền tham số `BaseApiClient`.

---

## 4. Hướng Dẫn Viết Kịch Bản Tự Động (Automation Script)

File `GeminiProFlow.cs` quản lý toàn bộ các kịch bản chạy một bước "Bấm Phát Ăn Ngay".

### Kịch Bản Mẫu
```csharp
// Đang chạy song song trên Thread Pool
public static async Task ExecuteAsync(BaseApiClient apiClient, string serial, Action<string> logMessage)
{
    logMessage($"[{serial}] Flow started / Bắt đầu luồng.");
    
    // 1. Lệnh Change (Đổi Device)
    await apiClient.ChangeDeviceAsync(serial, ...);
    await Task.Delay(1000); // Wait API process

    // 2. Clear Data Ứng Dụng (Package)
    // Tích hợp ADB Command hoặc API:
    // Ex: await Core.AdbClient.ClearAppAsync(serial, "com.google.android.youtube");
}
```
Lưu ý: Bất kỳ Action nào gọi từ UI sang Automation đều phải được bọc trong `Task.Run()` để tránh việc Khóa UI (Freeze WinFrames).

---

## 5. Lưu Trữ Dữ Liệu Tự Động (Persistence)
Dự án được ứng dụng cả 2 cơ chế lưu:
- **Form1Settings (`app.json`)**: Ghi nhớ tọa độ (X, Y) của phần mềm trên màn hình, lưu tạm thời `Brand`, `Model` đã gõ giở ở bảng Right Panel.
- **DeviceConfigManager (`devices.json`)**: Theo Format Dictonary `Key: Serial ID - Value: Data Proxy`. Cho phép hệ thống gõ SocksIP vào máy điện thoại, tắt phần mềm bật lại vẫn chưa bị mất IP cũ.

> **❗ Chú Ý Quan Trọng khi sửa Lưu Trữ:** 
> Bất cứ khi nào cập nhật thêm `TextBox` mới, bạn phải sửa file Model (`DeviceConfig`) và gọi lệnh ghi `DeviceConfigManager.Save()` tại Event `FormClosing` của thiết bị.

![Architecture Screenshot](placeholder_cau_truc_thu_muc.png)  
*(Hình 1: Cấu trúc thư mục của Codebase)*

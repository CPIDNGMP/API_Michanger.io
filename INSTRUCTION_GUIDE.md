# 📱 Michanger & OneChanger API Control Tool

Dự án C# WinForms quản lý nhiều thiết bị ADB và tự động gọi API tương tác song song với công cụ Michanger Pro và OneChanger.

## 📂 Tổng quan Kiến trúc Thư mục (Folder Structure)
```text
MichangerAPIControl\
│
├── src\
│   ├── ApiClients\
│   │   ├── BaseApiClient.cs         # Cấu hình HttpClient gốc (Delay, url-encode, Timeout 5 phút)
│   │   ├── MichangerApiClient.cs    # Kế thừa BaseApiClient — endpoints Michanger Pro
│   │   └── OnechangerApiClient.cs   # Kế thừa BaseApiClient — endpoints OneChanger
│   │
│   ├── Automation\
│   │   ├── Flows\
│   │   │   ├── IFlow.cs             # Interface chuẩn cho mọi automation flow
│   │   │   └── FlowRegistry.cs      # Auto-discover flows qua reflection
│   │   ├── GeminiProFlow.cs         # Flow mẫu tích hợp sẵn (implement IFlow)
│   │   ├── ADBCommand.cs            # Script engine: Tap, Swipe, ImageMatch, v.v.
│   │   └── AdbScriptRunner.cs       # Chạy script file .txt line-by-line
│   │
│   ├── Core\
│   │   ├── AdbClient.cs             # Wrapper gọi adb.exe (lấy devices, mở app, chạy lệnh)
│   │   └── DeviceManager.cs         # Cập nhật danh sách máy lên UI an toàn (thread-safe)
│   │
│   └── Models\
│       └── DeviceConfig.cs          # Lưu cấu hình từng thiết bị (Filters, Socks5, Wipe Apps)
│
├── Controls\
│   └── DeviceControlItem.cs         # UserControl: Card hiển thị 1 thiết bị, bắt sự kiện Click
│
├── Forms\
│   └── DeviceSettingsForm.cs        # Popup chỉnh Filter Setting cá nhân từng thiết bị
│
└── Form1.cs                         # Main form: Kết nối UI → FlowRegistry → API Client
```

---

## 🛠 Hướng dẫn Chi tiết Các Tính năng Đã Lập trình

### 1. Tính năng Tự động Nhận diện API (Auto-Select Tool)
* **File xử lý:** `Form1.cs` 
* **Hàm:** `CheckApiStatusAsync()`
* **Cách hoạt động:**
  - Ở lần khởi động đầu tiên (hoặc khi ấn **Scan Devices**), phần mềm sẽ chui vào cổng mạng local `http://localhost:9999/`.
  - Đọc text trả về: Nếu thấy "OneChanger..." thì báo **OneChanger: ON** màu xanh lá. Nếu thấy "Michanger..." thì tương tự với **Michanger Pro**.
  - Tự động thay đổi giá trị Dropdown ComboBox: Mã `CboToolType.SelectedIndex = 0` (chọn Michanger) hoặc `1` (Onechanger). Ưu tiên Michanger nếu cả 2 cùng On.

### 2. Tăng Thời gian Chờ (Timeout Limit) chống Crash
* **File xử lý:** `src\ApiClients\BaseApiClient.cs`
* **Vị trí sửa:** Hàm khởi tạo `Constructor` của base class.
* **Cách hoạt động:** 
  - Hàm Change Device thường bắt điện thoại đổi rom, xoá app nên tốn vài phút. Http C# mặc định 100 giây sẽ Time-Out tung lỗi Exception sập phần mềm.
  - Fix bằng cách: Khai báo `_httpClient = new HttpClient { Timeout = TimeSpan.FromMinutes(5) };` nâng ngưỡng chờ lên 5 phút cho toàn bộ các API.

### 3. Luồng Tự động GeminiPro (Run GeminiPro Flow)
* **File xử lý:** `Form1.cs`
* **Hàm lập trình:** `RunGeminiProFlowAsync()`
* **Cách hoạt động:** Khi người dùng nhấn nút "Run GeminiPro", phần mềm tự động rẽ nhánh và gọi hàm luồng 3 bước như sau:
  1. **Bước Validation Chống Lỗi:** Nếu ô TextInput SOCKS5 bỏ trống -> Cảnh báo `MessageBox` đỏ chót lên màn hình và `return;` ép lập trình hủy nguyên luồng tự động (Giúp tránh lỗi không đổi Proxy gây lộ IP máy thật).
  2. **Bước 1 (Đổi Thiết bị):** Gọi api `ChangeDeviceAsync()`. 
  3. **Bước 2 (Config IP Proxy):** Đợi bước 1 báo thành công, lấy thông số Socks gửi API `SetSocksAsync()`.
  4. **Bước 3 (Bật ứng dụng lên dọn dẹp):** Bóc tách package app từ Settings (VD: `com.google.android.apps.subscriptions.red`). Dùng Script qua `AdbClient.ExecuteCommandAsync` để bắn nhồi ADB mở app từ dưới shell device.
    *(Lệnh ngầm: `adb -s <serial> shell monkey -p <package> -c android.intent.category.LAUNCHER 1`)*

### 4. Thao tác trên Từng Thiết bị vs Toàn bộ Thiết bị
* **File xử lý:** `Form1.cs`
* **Quy trình:**
  - Nếu bấm nút tắt trên một thiết bị (Change, Rand+Change): Hệ thống chạy vào hàm `DeviceItem_ActionClicked`. Biến Config truyền vào API là **Config Riêng (Cá nhân)** của thiết bị đó lưu trong Model.
  - Nếu Tick (Checkbox) chọn từ 2 máy trở lên rồii bấm "Change Device" từ khung dọc bên phải: Giao diện sẽ chạy thẳng vào `ExecuteActionOnSelectedDevices`. Tại đây phần mềm áp dụng Vòng Lặp (`foreach`). Hệ thống chạy song song lệnh cấu hình trên nhiều máy, và tự động ép các máy đã chọn xài chung Filter lấy từ **Khung Textbox Cấu hình Lọc (Global Settings)** bên tay phải.

# Hướng Dẫn Sửa Code & Tính Năng ADB Automation (MichangerAPIControl)

> Tài liệu này mô tả kiến trúc kỹ thuật, các hàm automation và hướng dẫn sửa/mở rộng code cho module ADB Automation của MichangerAPIControl.

---

## 🗂️ Cấu Trúc File Quan Trọng

```
MichangerAPIControl/
├── Forms/
│   ├── AdbAutomationEditorForm.cs         # Form chính: UI, events, logic điều phối
│   ├── AdbAutomationEditorForm.Designer.cs # Layout WinForms (auto-generated)
│   └── AdbTextPickerForm.cs               # Form phụ: Picker Text từ UI dump XML
├── src/Automation/
│   └── ADBCommand.cs                      # Engine: toàn bộ logic thực thi lệnh ADB
└── Docs/
    ├── HuongDanSuaCode.md                 # Tài liệu này
    └── HuongDanSuDung.md                  # Hướng dẫn sử dụng cho người dùng
```

---

## 🧠 Kiến Trúc Module ADB Automation

### Luồng hoạt động chính

```
[Người dùng click UI]
        ↓
[AdbAutomationEditorForm.cs]   ← Xử lý events, quản lý state
        ↓
[ADBCommand.ExecuteCommand()]  ← Parser & dispatcher (switch/case)
        ↓
[Method cụ thể: Tap, Swipe...] ← Gọi KAutoHelper hoặc AdbClient
        ↓
[KAutoHelper.ADBHelper]        ← Giao tiếp thực sự với thiết bị qua ADB
```

### Thư viện nền tảng
| Thư viện | Vai trò |
|---|---|
| `KAutoHelper.dll` | Lõi điều khiển ADB: Tap, Swipe, Key, Screenshot |
| `Emgu.CV` + `cvextern.dll` | OpenCV: Image Matching (tìm ảnh trên màn hình) |
| `MichangerAPIControl.Core.AdbClient` | Giao tiếp ADB cấp thấp (shell commands) |

---

## 📋 API Reference: ADBCommand.cs

### Lệnh cơ bản

| Lệnh Script | Hàm C# | Định dạng | Ghi chú |
|---|---|---|---|
| `Tap\|XxY` | `Tap(deviceId, cmd)` | `Tap\|135x200` | Tọa độ theo kích thước ref 270x555 |
| `Tap\|X\|Y` | `Tap(deviceId, cmd)` | `Tap\|540\|960` | Tọa độ pixel thực |
| `Swipe\|X1xY1\|X2xY2` | `Swipe(deviceId, cmd)` | `Swipe\|135x400\|135x100` | Vuốt theo tọa độ ref |
| `DoubleTap\|XxY` | `DoubleTap(deviceId, cmd)` | `DoubleTap\|135x200` | Click đúp với delay 100ms |
| `LongPress\|XxY` | `LongPress(deviceId, cmd)` | `LongPress\|135x200` | Nhấn giữ 1000ms |
| `Sleep\|ms` | `Sleep(deviceId, cmd)` | `Sleep\|2000` | Chờ cố định (ms) |
| `WaitRandom\|min\|max` | `WaitRandom(cmd)` | `WaitRandom\|1000\|3000` | Chờ ngẫu nhiên từ min đến max ms |

### Lệnh nhập liệu & phím

| Lệnh Script | Hàm C# | Định dạng | Ghi chú |
|---|---|---|---|
| `SendText\|nội_dung` | `Send(deviceId, cmd)` | `SendText\|Hello World` | Nhập văn bản |
| `SendKey\|tên_phím` | `Send(deviceId, cmd)` | `SendKey\|Home` | Phím: `Home`, `Back`, `AppSwitch` |

### Lệnh quản lý app

| Lệnh Script | Hàm C# | Định dạng | Ghi chú |
|---|---|---|---|
| `OpenApp\|package` | `Openapp(deviceId, cmd)` | `OpenApp\|com.android.chrome` | Dùng `monkey` |
| `CloseApp\|package` | `Closeapp(deviceId, cmd)` | `CloseApp\|com.android.chrome` | Dùng `am force-stop` |
| `ClearApp\|package` | `ClearApp(deviceId, cmd)` | `ClearApp\|com.android.chrome` | Dùng `pm clear` |

### Lệnh nhãn & điều hướng kịch bản

| Lệnh Script | Ghi chú |
|---|---|
| `Label\|TenNhan` | Đánh dấu vị trí trong kịch bản để nhảy đến |
| `Goto\|TenNhan` | Nhảy đến nhãn (hoặc số dòng 1-based) |

### Lệnh Image Matching

| Lệnh Script | Định dạng | Ghi chú |
|---|---|---|
| `ClickImage\|ten_anh.png` | `ClickImage\|button.png` | Tìm và click ảnh đầu tiên trên màn hình |
| `IfImageFound\|ten_anh.png\|Goto:NhanA\|Else:NhanB` | — | Nếu tìm thấy ảnh → nhảy NhanA, ngược lại → NhanB |
| `ImageNotFound\|ten_anh.png\|Continue` | — | Xử lý khi không tìm thấy ảnh |

> **Lưu ý**: Hình ảnh được lưu trong thư mục `{AppFolder}/Images/`. Dùng `ClickImage|button.png` (không cần đường dẫn đầy đủ); runtime sẽ tự tìm theo thư mục chuẩn.

### Lệnh Text-based (UI Dump)

| Lệnh Script | Định dạng | Ghi chú |
|---|---|---|
| `TapText\|văn_bản` | `TapText\|Login` | Dump XML UI, tìm node có text/content-desc này và tap vào tâm |
| `IfTextFound\|văn_bản\|Goto:NhanA\|Else:NhanB` | — | Kiểm tra text hiện diện trên màn hình và phân nhánh |

---

## 🔌 Hệ Thống Custom Flow (IFlow Plugin)

Từ phiên bản 2.0, bạn có thể tạo **luồng tự động hóa riêng** mà không cần sửa bất kỳ file nào trong core. Chỉ cần tạo class implement `IFlow`.

### Cách tạo Custom Flow

1. **Tạo file mới** trong `src/Automation/Flows/` (hoặc bất kỳ đâu trong project):

```csharp
using System;
using System.Drawing;
using System.Threading.Tasks;
using MichangerAPIControl.ApiClients;
using MichangerAPIControl.Automation.Flows;

public class MyCustomFlow : IFlow
{
    // Tên hiển thị trên nút UI
    public string Name => "My Custom Flow";

    public async Task ExecuteAsync(
        BaseApiClient apiClient,
        string serial,
        Action<string> log,
        Action<string, Color> updateStatus)
    {
        log($"[MyFlow] Starting on {serial}");
        updateStatus("Running...", Color.Orange);

        // Gọi API Michanger / OneChanger
        if (apiClient is MichangerApiClient mc)
            await mc.ChangeDeviceAsync(serial, filterBrand: "samsung");

        // Gọi ADB
        await Core.AdbClient.OpenAppAsync(serial, "com.android.chrome");

        updateStatus("Done", Color.LightGreen);
    }
}
```

2. **Thêm vào `.csproj`**:
```xml
<Compile Include="src\Automation\Flows\MyCustomFlow.cs" />
```

3. **Chạy app** — flow tự xuất hiện, không cần đăng ký gì thêm ✅

`FlowRegistry` tự động tìm kiếm tất cả class implement `IFlow` trong assembly qua reflection.

### Giá trị trả về của flow
Không cần trả về gì — khi hoàn thành hãy gọi `updateStatus("Completed", Color.LightGreen)`.
Khi có lỗi, throw exception — `ExecuteFlowOnSelectedDevices` sẽ bắt và log tự động.

---

## 🏗️ Cách Thêm Lệnh Mới (ADB Script Command)


1. **Thêm hàm xử lý** trong `ADBCommand.cs`:
```csharp
public static string MyNewCommand(string deviceId, string command)
{
    string[] parts = command.Split('|');
    // ... logic ...
    return "NEXT"; // hoặc "GOTO|LabelName" hoặc "STOP"
}
```

2. **Đăng ký vào dispatcher** trong `ExecuteCommand()`:
```csharp
case "mynewcommand":
    return MyNewCommand(deviceId, line);
```

3. **Thêm nút bấm vào UI** (nếu cần):
   - Khai báo `Button` trong `AdbAutomationEditorForm.Designer.cs`
   - Thêm vào `FlowLayoutPanel` tương ứng
   - Viết event handler trong `AdbAutomationEditorForm.cs`

### Giá trị trả về của `ExecuteCommand`

| Giá trị | Ý nghĩa |
|---|---|
| `"NEXT"` | Tiếp tục dòng tiếp theo |
| `"GOTO\|TenNhan"` | Nhảy đến nhãn |
| `"STOP"` | Dừng toàn bộ script |
| `"FAIL_BRANCH"` | Nhánh thất bại (hiện tại bỏ qua, tiếp tục) |
| Chuỗi khác | Ghi log lỗi, tiếp tục |

---

## 🖥️ AdbAutomationEditorForm — Chi Tiết Trạng Thái & Events

### Biến trạng thái quan trọng

| Biến | Kiểu | Ý nghĩa |
|---|---|---|
| `_selectedDeviceId` | `string` | ID thiết bị ADB đang chọn |
| `_currentScreenshot` | `Bitmap` | Ảnh chụp màn hình hiện tại |
| `_refWidth/_refHeight` | `int` | Kích thước tham chiếu PictureBox (270x555 Portrait, 555x270 Landscape) |
| `_isSwipeMode` | `bool` | Bật/tắt chế độ Swipe khi kéo chuột |
| `_isSelecting` | `bool` | Đang kéo chọn vùng crop |
| `_cropRect` | `Rectangle` | Vùng đã chọn trên PictureBox |
| `_stopScript` | `bool` | Cờ dừng script khi chạy |
| `_lastUiDumpXml` | `string` | Cache XML UI dump gần nhất |

### Sơ đồ chụp ảnh màn hình (`TakeScreenshot`)

```
btnScreenshot_Click
    → TakeScreenshot()
        → AdbClient.ExecuteCommandAsync("screencap") 
        → AdbClient.ExecuteCommandAsync("pull")
        → Fallback: KAutoHelper.ADBHelper.ScreenShoot() nếu pull thất bại
        → Load ảnh qua MemoryStream (tránh file lock)
        → Phát hiện Landscape/Portrait → điều chỉnh _refWidth/_refHeight
        → CenterPictureBox()
```

### Sơ đồ tương tác màn hình (Click/Drag)

```
MouseDown → khởi tạo _startPoint / _startPointSwipe
MouseMove → cập nhật _cropRect (chế độ thông thường) hoặc Swipe preview
MouseUp   → 
  - Nếu drag rộng: UpdateCropPreview() + txtCommandPreview = "Tap|XxY"
  - Nếu click đơn: txtCommandPreview = "Tap|XxY"
  - Nếu Swipe Mode: txtCommandPreview = "Swipe|X1xY1|X2xY2"
Paint     → vẽ hình chữ nhật đỏ đứt khi đang kéo chọn
```

---

## 🔬 AdbTextPickerForm — Chi Tiết

Form này được mở từ nút **Get Text Map**:

1. `AdbClient.DumpUIAsync()` → lấy XML UI hierarchy từ thiết bị
2. Parse XML: lấy tất cả `<node>` có `text` hoặc `content-desc`
3. Hiển thị `DataGridView` với 3 cột: **Text**, **Bounds**, **ContentDesc**
4. Người dùng chọn dòng → nhấn:
   - **Add IfTextFound**: tạo lệnh `IfTextFound|text|Goto:LABEL_NAME|Else:Continue`
   - **Add TapText**: tạo lệnh `TapText|text`
5. Lệnh được trả về qua `SelectedCommand` → append vào `rtbScript`

---

## ⚠️ Vấn Đề & Cải Tiến Đã Biết

| Vấn đề | Trạng thái | Giải pháp |
|---|---|---|
| `LongPress` cũ dùng hardcoded `100x100` | ✅ Đã sửa | Đọc từ `txtCommandPreview` hoặc `txtAdvancedValue` |
| `WaitRandom` format sai (`val` thay vì `min\|max`) | ✅ Đã sửa | Parse đúng định dạng `min\|max` hoặc `min-max` |
| Layout FlowLayoutPanel tràn ngang | ✅ Đã sửa | Thêm `MaximumSize` và `WrapContents=true` |
| Nút bị mất do màu chữ đen trên nền đen | ✅ Đã sửa | Ép `ForeColor=White`, `BackColor=Gray` |
| Script chạy bị `CrossThreadException` | ✅ Đã sửa | Đọc `rtbScript.Lines` trước `Task.Run` |
| `WaitRandom` không delay 300ms như các lệnh khác | ⚠️ Cần xem xét | Đây là `intentional` — Sleep đã được tích hợp trong lệnh |
| Zoom chưa hoạt động | 🔜 Tính năng tương lai | Handler `AdbAutomationEditorForm_MouseWheel` chưa implement |

---

## 🚀 Ví Dụ Code Developer

```csharp
// Chạy một lệnh đơn
string result = ADBCommand.ExecuteCommand(serial, "Tap|135x200");

// Chạy toàn bộ script (trong Task.Run để không block UI)
var lines = File.ReadAllLines("script.txt").ToList();
foreach (var line in lines)
{
    var result = ADBCommand.ExecuteCommand(serial, line);
    if (result == "STOP") break;
    // xử lý GOTO...
}
```

---

## 🇺🇸 ENGLISH SUMMARY

### Architecture
- `ADBCommand.cs`: Static command engine. Each script line is parsed and dispatched to a specific function.
- `AdbAutomationEditorForm.cs`: UI controller — manages device state, screenshot, mouse interaction, script editor.  
- `AdbTextPickerForm.cs`: Auxiliary picker — shows all UI text elements from ADB XML dump.

### Adding a New Command
1. Add a static method in `ADBCommand.cs` returning `"NEXT"` / `"GOTO|label"` / `"STOP"`.
2. Register it in `ExecuteCommand()` switch/case.
3. Optionally add a button in the UI form.

### Script Engine Entry Points
- `ExecuteCommand(deviceId, line)` — execute a single command line.
- Script runner in `btnRunScript_Click` — runs all lines with pre-scanned label map and GOTO support.
- `btnRunLine_Click` — executes the currently selected line in the editor.

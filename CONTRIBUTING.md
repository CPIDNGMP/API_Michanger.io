# CONTRIBUTING — MichangerAPIControl

Cảm ơn bạn đã quan tâm đến việc đóng góp! Tài liệu này hướng dẫn cách tham gia phát triển project.

---

## 🔧 Yêu Cầu Môi Trường

- Visual Studio 2019+ (hoặc mới hơn)
- .NET Framework 4.8 SDK
- ADB + một thiết bị Android để test

---

## ✨ Cách Đóng Góp Dễ Nhất: Tạo Custom Flow

Cách nhanh nhất để đóng góp là tạo một **automation flow** mới:

### 1. Tạo file mới trong `src/Automation/Flows/`

```csharp
using System;
using System.Drawing;
using System.Threading.Tasks;
using MichangerAPIControl.ApiClients;

namespace MichangerAPIControl.Automation.Flows
{
    public class MyAwesomeFlow : IFlow
    {
        public string Name => "My Awesome Flow"; // Tên hiện trên UI

        public async Task ExecuteAsync(
            BaseApiClient apiClient,
            string serial,
            Action<string> log,
            Action<string, Color> updateStatus)
        {
            updateStatus("Step 1...", Color.Orange);
            log($"[MyFlow] Starting on {serial}");

            // Gọi API
            if (apiClient is MichangerApiClient mc)
                await mc.ChangeDeviceAsync(serial);

            // Gọi ADB
            await Core.AdbClient.OpenAppAsync(serial, "com.android.chrome");

            updateStatus("Done", Color.LightGreen);
        }
    }
}
```

### 2. Thêm vào `.csproj`

```xml
<Compile Include="src\Automation\Flows\MyAwesomeFlow.cs" />
```

### 3. Chạy app — flow tự xuất hiện ✅

Không cần đăng ký gì thêm. `FlowRegistry` tự discovery qua reflection.

---

## 🔌 Thêm Lệnh ADB Mới

Để thêm lệnh mới cho ADB Script Engine:

1. **Thêm hàm** vào `src/Automation/ADBCommand.cs`:

```csharp
public static string MyNewCommand(string deviceId, string command)
{
    string[] parts = command.Split('|');
    // ... logic ...
    return "NEXT"; // hoặc "GOTO|LabelName" hoặc "STOP"
}
```

2. **Đăng ký** vào `ExecuteCommand()` switch/case:

```csharp
case "mynewcommand":
    return MyNewCommand(deviceId, line);
```

---

## 📝 Coding Style

- Bilingual comments: Vietnamese + English cho public methods
- XML doc comments (`///`) cho tất cả public API
- Async/await cho tất cả I/O (không dùng `.Result` hoặc `.Wait()` trừ trong `ADBCommand.cs`)
- Trả về `"NEXT"` / `"GOTO|label"` / `"STOP"` từ script commands

---

## 📁 Cấu Trúc Project

```
MichangerAPIControl/
├── Form1.cs                          # Main form
├── Controls/
│   └── DeviceControlItem.cs          # Per-device UI card
├── Forms/
│   ├── AdbAutomationEditorForm.cs    # Script editor UI
│   └── DeviceSettingsForm.cs         # Per-device settings
└── src/
    ├── ApiClients/
    │   ├── BaseApiClient.cs          # HTTP base + delay
    │   ├── MichangerApiClient.cs     # Michanger Pro endpoints
    │   └── OnechangerApiClient.cs    # OneChanger endpoints
    ├── Automation/
    │   ├── Flows/
    │   │   ├── IFlow.cs              # Interface chuẩn cho flows
    │   │   └── FlowRegistry.cs      # Auto-discovery
    │   ├── GeminiProFlow.cs          # Built-in flow (example)
    │   ├── ADBCommand.cs             # Script command engine
    │   └── AdbScriptRunner.cs        # Line-by-line runner
    ├── Core/
    │   ├── AdbClient.cs             # ADB command wrapper
    │   └── DeviceManager.cs          # Device list manager
    └── Models/
        └── DeviceConfig.cs           # Per-device config model
```

---

## 📬 Pull Request

1. Fork repo
2. Tạo branch: `feature/my-flow-name` hoặc `fix/issue-description`
3. Commit rõ ràng: `feat: add TikTok farming flow` hoặc `fix: handle empty SOCKS5`
4. Tạo PR với mô tả ngắn gọn về những gì thay đổi

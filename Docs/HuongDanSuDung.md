# Hướng Dẫn Sử Dụng: ADB Multi-Device Control Tool

Chào mừng bạn đến với tài liệu hướng dẫn sử dụng chính thức của **ADB Multi-Device Control Tool** - Công cụ quản lý, điều khiển và tự động hóa hàng loạt thiết bị Android siêu tốc, tích hợp liền mạch với **Michanger Pro** và **OneChanger**.

---

## 1. Giới Thiệu Giao Diện Chính

Giao diện phần mềm được thiết kế theo phong cách tối giản (Dark Mode) chia thành 3 khu vực chính:
1. **Bảng Điều Khiển Trái:** Chọn công cụ (Michanger/Onechanger), Quét thiết bị và Trạng thái kết nối API.
2. **Danh Sách Thiết Bị (Giữa):** Hiển thị các điện thoại đã kết nối ADB, trạng thái hoạt động và cấu hình riêng lẻ.
3. **Khu Vực Tính Năng (Phải):** Các bộ lọc (Brand, Model, Country), nút chạy Tự động hóa và Bảng log (Console).

![Tổng quan Giao Diện Chính](placeholder_hinh_anh_giao_dien_tong_quan.jpg)  
*(Hình 1: Tổng quan giao diện quản lý đa thiết bị)*

---

## 2. Các Bước Sử Dụng Cơ Bản

### Bước 0: Cấu Hình Tối Ưu Hóa Trên Phần Mềm OneChanger (Bắt Buộc)
Để đảm bảo các luồng Automation (đặc biệt là GeminiPro Flow) chạy mượt mà và sạch sẽ nhất, trước khi sử dụng ADB Control Tool, bạn cần thiết lập cấu hình trên chính giao diện của OneChanger:

1. **Bật chế độ Đăng xuất Gmail:** Mở bảng **Setting Device** trên OneChanger, đảm bảo bạn đã tích chọn ✅ **"Logout gmail trước khi change"**. Điều này giúp máy mới không bao giờ bị dính thẻ hay lưu cache của tài khoản trước đó.
![Cấu hình OneChanger](file:///C:/Users/thuon/.gemini/antigravity/brain/672ab824-ea70-4b23-a013-7c857a4951e6/media__1772513734718.png)  
*(Hình 2: Chọn tính năng Đăng xuất Gmail trước khi đổi máy)*

2. **Cấu hình Xóa Package (Wipe):** Tại bảng **Package manager**, ngoài ứng dụng chính mà bạn muốn nuôi (ví dụ: YouTube vanced), bạn CẦN gõ thêm các package hệ thống vào danh sách Wipe để dọn tàn dư rác:
   - `com.google.android.apps.googleone` (Google One)
   - `com.google.android.apps.subscriptions.red`
![Cấu hình Package Restore/Wipe](file:///C:/Users/thuon/.gemini/antigravity/brain/672ab824-ea70-4b23-a013-7c857a4951e6/media__1772513752895.png)  
*(Hình 3: Bổ sung thêm Google One và Subscriptions vào Wipe List)*

### Bước 1: Lựa Chọn Công Cụ (Michanger Pro hoặc OneChanger)
Phần mềm ADB Control đóng vai trò là "Bộ Não Trung Tâm" gắn kết với 2 phần mềm đổi thông tin phổ biến nhất.
- Tại menu bên trái, click vào nút **Michanger Pro** hoặc **OneChanger**.
- Nút được chọn sẽ **Bật Sáng Màu Xanh (Cyan Border)** để biểu thị công cụ đang hoạt động.
- **Lưu ý:** Đèn tín hiệu `Status` ngay bên dưới phải hiện **ON (Màu Xanh)**. Nếu hiện OFF (Màu Đỏ), hãy đảm bảo phần mềm gốc (OneChanger hoặc Michanger) đã được bật trên máy tính.

![Chọn công cụ và Trạng thái kết nối](placeholder_hinh_anh_chon_cong_cu.jpg)  
*(Hình 4: Nút Michanger Pro đang được chọn (Màu xanh) và Status báo ON)*

### Bước 2: Quét Thiết Bị (Scan Devices)
- Cắm cáp (hoặc kết nối Wi-Fi) các điện thoại Android vào máy tính. Đảm bảo đã bật **USB Debugging**.
- Bấm nút **Scan Devices / Quét Thiết Bị** màu xanh xám.
- Danh sách máy sẽ hiện ra ở giữa màn hình. Hãy **Tick (✓)** vào ô trống cạnh các máy mà bạn muốn thao tác.

![Quét thiết bị](placeholder_hinh_anh_quet_thiet_bi.jpg)  
*(Hình 5: Kết quả sau khi bấm Scan hiển thị danh sách ID thiết bị)*

### Bước 3: Thiết Lập Cấu Hình Đổi Máy (Global Settings)
Phía trên cùng bên phải là khung **Settings & Filters**.
- Điền các thông số bạn muốn đồng bộ cho loạt máy: `Brand` (ví dụ: google), `Model` (ví dụ: Pixel 10 Pro), `Country` (ví dụ: US).
- Các thông số này sẽ tự động được ghi nhớ cho lần mở phần mềm tiếp theo.

![Cấu hình thiết bị](placeholder_hinh_anh_cau_hinh_doi_may.jpg)  
*(Hình 6: Khung thiết lập Brand, Model, Country)*

### Bước 4: Thiết Lập Proxy (SOCKS5) Cho Từng Máy
Mỗi điện thoại có thể chạy một địa chỉ Proxy riêng biệt.
- Trong danh sách thiết bị (cột giữa), nhìn vào ô **SOCKS5**.
- Nhập định dạng SOCKS5 (ví dụ: `IP:Port:User:Pass` hoặc `IP:Port`).
- Bấm nút hình Bánh Răng (⚙ Cài Đặt) trên từng thiết bị nếu bạn muốn chỉnh sửa sâu hơn (Wipe App, Tùy chỉnh Brand riêng biệt).

![Thiết lập IP](placeholder_hinh_anh_nhap_socks5.jpg)  
*(Hình 7: Nhập Socks5 riêng cho từng Device)*

---

## 3. Chạy Các Tác Vụ Tự Động Hóa (Actions)

Khi đã chọn máy vuông góc và cài đặt xong, hãy nhìn lên bảng **Actions** trên cùng bên phải:

1. **Random & Change:** 
   Công cụ sẽ gọi lệnh API tới phần mềm đang chọn (Michanger/Onechanger) để Đổi Thông Tin điện thoại dựa trên bộ lọc Brand/Model/Country của bạn.
   
2. **Config Socks5 (Hàng Loạt):** 
   Gắn IP Socks5 cho tất cả các điện thoại đang được Tick chọn.

3. **✨ RUN GEMINIPRO (Luồng Độc Quyền):**
   Đây là luồng tự động hóa tích hợp sâu:
   - Tự động thay đổi thiết bị (Random & Change).
   - Tự động Fake IP (Set Socks).
   - Tự động Clear Data & Open ứng dụng mục tiêu (vd: YouTube hoặc ứng dụng đang cày).
   
![Chạy thao tác](placeholder_hinh_anh_bam_nut_run.jpg)  
*(Hình 8: Các nút tính năng chạy trên toàn bộ điện thoại đã chọn)*

---

## 4. Bảng Theo Dõi & Lịch Sử (Logs)
Mọi diễn biến (Thành công, Lỗi API, Mất kết nối cáp) đều được in trực tiếp ngay góc dưới cùng bên phải theo thời gian thực (Console). Khung giao diện và các tùy chọn của bạn đều được thiết kế **tự động lưu vào ứng dụng** và khôi phục khi bạn tắt/mở lại phần mềm.

![Bảng Log](placeholder_hinh_anh_bang_logs.jpg)  
*(Hình 9: Khung theo dõi trạng thái Real-time)*

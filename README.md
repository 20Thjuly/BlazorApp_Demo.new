# 🌟 BlazorApp_Demo & eShop Beauty Store
Họ tên: Đinh Hữu Quang
Mã sinh viên: 23K4080042
> **Dự án Môn học: Lập Trình Web (Phần 1 - Blazor Web App với .NET 8)**  
> Ứng dụng bao gồm **Hệ thống Bài tập Lab thực hành** và **Dự án Cửa hàng Mỹ phẩm eShop** được xây dựng theo kiến trúc đa tầng (Clean Architecture / Plugin Pattern).

[![.NET 8](https://img.shields.io/badge/.NET-8.0-blue.svg)](https://dotnet.microsoft.com/)
[![Blazor](https://img.shields.io/badge/Blazor-InteractiveServer-purple.svg)](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor)
[![License](https://img.shields.io/badge/License-MIT-green.svg)](#)

---

## 📑 Mục Lục
- [Giới Thiệu Tổng Quan](#-giới-thiệu-tổng-quan)
- [Cấu Trúc 2 Solution Độc Lập](#-cấu-trúc-2-solution-độc-lập)
- [Chi Tiết Chức Năng](#-chi-tiết-chức-năng)
  - [1. Phân Hệ Bài Tập Lab (`BaiTap_Lab.sln`)](#1-phân-hệ-bài-tập-lab-baitap_labsln)
  - [2. Phân Hệ Cửa Hàng eShop (`eShop.sln`)](#2-phân-hệ-cửa-hàng-eshop-eshopsln)
- [Kiến Trúc Dự Án (Clean Architecture)](#-kiến-trúc-dự-án-clean-architecture)
- [Hướng Dẫn Khởi Chạy](#-hướng-dẫn-khởi-chạy)
  - [Chạy bằng Visual Studio](#cách-1-chạy-bằng-visual-studio-khuyên-dùng)
  - [Chạy bằng Dòng Lệnh (.NET CLI)](#cách-2-chạy-bằng-dòng-lệnh-net-cli)
- [Thông Tin Đăng Nhập Quản Trị](#-thông-tin-đăng-nhập-quản-trị-admin)

---

## 🎯 Giới Thiệu Tổng Quan

Dự án được xây dựng phục vụ học tập và nghiên cứu công nghệ **Blazor Server (.NET 8)**, áp dụng các tiêu chuẩn thiết kế hiện đại:
* **Giao diện hiện đại, sang trọng**: Sử dụng bảng màu cao cấp, Typography Plus Jakarta Sans, Bootstrap Icons, các hiệu ứng vi mô (micro-interactions) và responsive toàn diện trên máy tính, tablet và điện thoại.
* **Tách bạch hoàn toàn**: Hệ thống được cấu hình thành 2 dự án Web và 2 file Solution `.sln` riêng biệt, cho phép chạy độc lập phần bài tập thực hành trên lớp và phần dự án thương mại điện tử eShop.

---

## 📂 Cấu Trúc 2 Solution Độc Lập

| File Solution | Dự án Web Khởi Chạy | Cổng Mặc Định | Mục Đích |
| :--- | :--- | :--- | :--- |
| **`eShop.sln`** | `eShop.Web` | `http://localhost:5194` | Cửa hàng thương mại điện tử mỹ phẩm hoàn chỉnh (Khách hàng & Admin). |
| **`BaiTap_Lab.sln`** | `BlazorApp_Demo` | `http://localhost:5193` | Hệ thống các bài tập thực hành Lab Blazor Server với menu Sidebar. |
| **`BlazorApp_Demo.sln`** | Cả 2 dự án | Tuỳ chọn | Solution tổng hợp, có thể chọn project bất kỳ làm **Startup Project**. |

---

## 🚀 Chi Tiết Chức Năng

### 1. Phân Hệ Bài Tập Lab (`BaiTap_Lab.sln`)
Chạy trên layout dạng Sidebar truyền thống ([MainLayout.razor](file:///d:/L%E1%BA%ADp%20tr%C3%ACnh%20web/part%201/BlazorApp_Demo/BlazorApp_Demo/Components/Layout/MainLayout.razor)), bao gồm:
* **Trang Chủ Lab (`/`)**: Dashboard giới thiệu môn học và các thẻ truy cập nhanh từng bài thực hành.
* **Forms & Validation (`/forms`)**: Thực hành xây dựng Form nhập liệu sử dụng `EditForm`, `DataAnnotationsValidator`, hiển thị lỗi bằng `ValidationMessage` và `ValidationSummary`.
* **Counter & Cascading (`/counter`)**: Minh họa cơ chế truyền dữ liệu đa cấp độ không cần qua tham số trung gian với `CascadingValue` và `CascadingParameter`.
* **Weather Forecast (`/weather`)**: Kỹ thuật tải dữ liệu bất đồng bộ dạng luồng với thuộc tính `@attribute [StreamRendering]`.
* **Dynamic Content (`/dynamic`)**: Minh họa vòng đời render và sự khác biệt giữa Blazor Server và Blazor WebAssembly.
* **Todo List (`/todo`)**: Ứng dụng quản lý công việc chuyên nghiệp với thanh tiến độ hoàn thành, bộ lọc (Tất cả / Đang làm / Đã xong), đánh dấu trạng thái và dọn dẹp danh sách.

---

### 2. Phân Hệ Cửa Hàng eShop (`eShop.sln`)
Chạy trên giao diện riêng biệt chuyên nghiệp ([EShopLayout.razor](file:///d:/L%E1%BA%ADp%20tr%C3%ACnh%20web/part%201/BlazorApp_Demo/eShop.Web/Components/Layout/EShopLayout.razor)):

#### 🛍️ Cổng Khách Hàng (Customer Portal)
* **Trang chủ & Danh mục (`/`)**:
  * Banner Hero thời thượng, thanh thông báo ưu đãi (Announcement bar).
  * Bộ lọc nhanh theo các danh mục mỹ phẩm hot: *Bronzer, Blush (Phấn má), Foundation (Kem nền), Eyeshadow (Phấn mắt)*.
  * Ô tìm kiếm sản phẩm tức thì theo từ khóa.
* **Chi tiết sản phẩm (`/product/{id}`)**:
  * Hiển thị ảnh chất lượng cao, thương hiệu, mức giảm giá, đánh giá sao.
  * Mô tả sản phẩm, chính sách bảo đảm (Free shipping, đổi trả 30 ngày, 100% chính hãng).
  * Nút "Thêm vào giỏ hàng" tích hợp hiệu ứng phản hồi trạng thái mượt mà.
* **Giỏ hàng (`/cart`)**:
  * Lưu trữ dữ liệu giỏ hàng trên trình duyệt (`LocalStorage`) đảm bảo dữ liệu không bị mất khi tải lại trang.
  * Cập nhật số lượng động, tính tổng tiền tự động, xóa từng mục hoặc làm trống giỏ hàng.
* **Đặt hàng & Thanh toán (`/placeorder`)**:
  * Quy trình Stepper 3 bước trực quan (*1. Giỏ hàng $\rightarrow$ 2. Thông tin giao hàng $\rightarrow$ 3. Hoàn tất*).
  * Form nhập liệu có kiểm tra tính hợp lệ dữ liệu khách hàng (Họ tên, Địa chỉ, Thành phố, Quốc gia).
* **Xác nhận đơn hàng (`/orderconfirm/{uniqueId}`)**:
  * Tạo mã đơn duy nhất (Unique GUID).
  * Hiển thị tiến trình xử lý đơn hàng (*Đã đặt hàng $\rightarrow$ Đang xác nhận $\rightarrow$ Đang đóng gói $\rightarrow$ Đang giao hàng*).
  * Bảng kê chi tiết đơn giá, số lượng và tổng thanh toán.

#### 🛡️ Cổng Quản Trị Viên (Admin Portal)
* **Đăng nhập quản trị (`/admin`)**:
  * Xác thực người dùng qua Cookie Authentication (`eShop.CookieAuth`).
  * Có sẵn nút điền nhanh tài khoản demo.
* **Đơn hàng chờ xử lý (`/outstandingorders`)**:
  * Danh sách toàn bộ đơn hàng mới từ khách hàng.
  * Xem chi tiết từng đơn hàng (`/orderdetail/{id}`) và thao tác nút **"Đã xử lý"**.
* **Đơn hàng đã xử lý (`/processedorders`)**:
  * Lưu trữ và tra cứu lịch sử các đơn hàng đã được nhân viên duyệt hoàn tất.
* **Đăng xuất an toàn (`/logout`)**: Xóa phiên làm việc và cookie xác thực.

---

## 🏗️ Kiến Trúc Dự Án (Clean Architecture)

Dự án tuân theo mô hình **Onion / Clean Architecture** và **Plugin Architecture**:

```
BlazorApp_Demo/
│
├── 📁 eShop.CoreBusiness/              # Core Domain Entities (Product, Order, OrderLineItem)
├── 📁 eShop.UseCases/                  # Business Logic Use Cases & Plugin Interfaces
│
├── 📁 eShop.Web.Modules/               # Razor Class Libraries (RCL)
│   ├── eShop.Web.CustomerPortal/       # Giao diện & Chức năng Khách hàng
│   ├── eShop.Web.AdminPortal/          # Giao diện & Chức năng Quản trị
│   └── eShop.Web.Common/               # Controls dùng chung (SearchBar, Login)
│
├── 📁 Plugins/                         # Triển khai các cổng cắm dữ liệu (Data & Storage)
│   ├── eShop.DataStore.HardCoded/      # Kho dữ liệu Mock in-memory
│   ├── eShop.ShoppingCart.LocalStorage/# Quản lý Giỏ hàng qua LocalStorage trình duyệt
│   └── eShop.StateStore.DI/            # Quản lý State qua Dependency Injection
│
├── 🌐 eShop.Web/                       # [Project Web Host 1] Chạy riêng Cửa hàng eShop
│   ├── Components/                     # App, Routes, EShopLayout, TopNavBar
│   └── wwwroot/                        # CSS, Fonts, Icons, Assets cho eShop
│
└── 🌐 BlazorApp_Demo/                  # [Project Web Host 2] Chạy riêng Bài tập Lab
    ├── Components/Pages/               # Forms, Counter, Weather, Dynamic, Todo
    └── Components/Layout/              # MainLayout (Sidebar), NavMenu
```

---

## 💻 Hướng Dẫn Khởi Chạy

### Cách 1: Chạy bằng Visual Studio (Khuyên dùng)
1. **Để chạy Cửa hàng eShop:**
   * Mở file **`eShop.sln`** bằng Visual Studio.
   * Nhấn phím **F5** (hoặc nút **`https` / `http`** trên thanh công cụ).
   * Trình duyệt sẽ tự động mở trang web eShop tại: `http://localhost:5194`
2. **Để chạy Bài tập Lab:**
   * Mở file **`BaiTap_Lab.sln`** bằng Visual Studio.
   * Nhấn phím **F5**.
   * Trình duyệt sẽ mở hệ thống bài tập tại: `http://localhost:5193`
3. **Nếu mở file tổng hợp `BlazorApp_Demo.sln`:**
   * Chuột phải vào project bạn muốn chạy (`eShop.Web` hoặc `BlazorApp_Demo`) trong cửa sổ *Solution Explorer*.
   * Chọn **Set as Startup Project**.
   * Nhấn **F5**.

---

### Cách 2: Chạy bằng Dòng Lệnh (.NET CLI)

* **Chạy riêng Cửa hàng eShop:**
  ```powershell
  dotnet run --project "eShop.Web/eShop.Web.csproj"
  ```
  Truy cập: `http://localhost:5194`

* **Chạy riêng Bài tập Lab:**
  ```powershell
  dotnet run --project "BlazorApp_Demo/BlazorApp_Demo.csproj"
  ```
  Truy cập: `http://localhost:5193`

---

## 🔑 Thông Tin Đăng Nhập Quản Trị (Admin)

Để trải nghiệm Cổng Quản trị eShop (`/admin`), sử dụng tài khoản sau:
* **Tên đăng nhập (Username):** `admin`
* **Mật khẩu (Password):** `adminadmin`
*(Trên trang đăng nhập có tích hợp sẵn nút "Điền nhanh" để thử nghiệm tiện lợi)*

---

## 👨‍💻 Tác Giả & Bản Quyền
* **Kho lưu trữ:** [BlazorApp_Demo.new trên GitHub](https://github.com/20Thjuly/BlazorApp_Demo.new.git)
* Được phát triển và hoàn thiện trên nền tảng **ASP.NET Core Blazor .NET 8**.

# ProductManagementDemo

Solution WPF (.NET 8) + Entity Framework Core 8 quản lý sản phẩm theo mô hình
Repository/Service, đúng kiến trúc trong Lab 02.

## Cấu trúc

```
ProductManagementDemo.sln
├── BusinessObjects        (Product, Category, AccountMember - entity)
├── DataAccessLayer        (MyStoreContext, ProductDAO, CategoryDAO, AccountDAO)
├── Repositories           (Interfaces + implementations)
├── Services               (Interfaces + implementations, business validation)
├── ProductManagement      (WPF app: LoginWindow, MainWindow)
└── CreateMyStoreDB.sql    (script tạo database MyStore, không kèm file .mdf)
```

## Cách chạy

1. **Tạo database**: mở SQL Server Management Studio, chạy file `CreateMyStoreDB.sql`
   để tạo database `MyStore` cùng 3 bảng (Categories, Products, AccountMember)
   và dữ liệu mẫu (tài khoản đăng nhập: `admin` / `123456`).

2. **Sửa connection string** nếu cần, trong:
   - `DataAccessLayer/appsettings.json`
   - `ProductManagement/appsettings.json`

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnectionString": "Server=(local);Database=MyStore;Uid=sa;Pwd=1234567890;TrustServerCertificate=True;"
     }
   }
   ```

3. **Mở solution** `ProductManagementDemo.sln` bằng Visual Studio 2022 (cần cài
   .NET 8 SDK + workload ".NET Desktop Development").

4. Đặt **ProductManagement** làm Startup Project, nhấn F5.

5. Đăng nhập với `admin` / `123456` → màn hình Product Management cho phép
   Create / Update / Delete / xem danh sách sản phẩm.

## Lưu ý

- Không có file database (.mdf/.bak) kèm theo — bạn tự chạy script SQL ở bước 1.
- Nếu dùng SQL Server Express/LocalDB, đổi `Server=(local)` thành tên instance
  tương ứng (ví dụ `(localdb)\MSSQLLocalDB`).
- Đã cấu hình NuGet packages cần thiết trong các file `.csproj` (EF Core
  SqlServer/Tools 8.0.2, Configuration.Json 8.0.0) — Visual Studio sẽ tự restore.

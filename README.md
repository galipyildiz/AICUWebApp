# AICUWebApp
- [Canva Sunumu](https://www.canva.com/design/DAGWl0ZIGIA/yOqvzrhhqOGLPobf279_2w/edit)

----

### To-Do List Uygulaması
- **Amaç:** Kullanıcıların basit bir yapılacaklar listesi oluşturmasını sağlamak.
- **Özellikler:**
  - [ ] Görev ekleme.
  - [ ] Görev düzenleme ve silme.
  - [ ] Görevleri listeleme.
  - [ ] Tamamlanmış görevleri işaretleme.
----

### Adımlar
1. [X] Frontend => vite ile ts react app oluşturulması.
   - [vite docs](https://vite.dev/guide/)
     - ```npm create vite@latest```
   - initial gelen resim,svg,css dosyalarının temizlenmesi.
   - component klasörü oluşturup counter typescript ile yazılması ve usestate,useffect kullanımı.
2. [X] Backend => .net api oluşturulması.
   - Visual Studio > Web Api > .net 8 > IIS Express de çalıştır.
   - swagger ile weather get methodunun çalıştığını kontrol et.
   - gitignore ekle.
3. [X] Docker ile postgresql ayağa kaldırılması.
   - ```docker run --name aicu-db-pg-container -e POSTGRES_USER=postgres -e POSTGRES_PASSWORD=123456 -e POSTGRES_DB=TodoAppDB -p 5432:5432 -d postgres:latest```
4. [ ] Backend işlemlerinin tamamlanması.
   - Connection string yazılması.
   - [Diğer connection stringler için](https://www.connectionstrings.com/)
   - 
   ```json
    {
    "ConnectionStrings": {
      "DefaultConnection": "Host=localhost;Port=5432;Database=TodoAppDB;Username=postgres;Password=123456;"
    },
    "Logging": {
      "LogLevel": {
        "Default": "Information",
        "Microsoft.AspNetCore": "Warning"
      }
    },
    "AllowedHosts": "*"
    }
   ```
  - Folder structure oluşturulması ve entitylerin tanımlanması.
    ```
    Root/
    │
    ├── Entities/
    │   └── Todo.cs
    |   └── User.cs
    │
    ├── Services/
    │   ├── Abstract/
    │   │   └── ITodoService
    │   └── Concrete/
    │       └── TodoService
    │
    ├── Controllers/
    │   └── TodoController.cs
    │
    ├── Dtos/
    │   └── CreateTodoDto.cs
    │
    ├── Migrations/
    │
    └── Data/
        └── DatabaseContext.cs
    ```
  - EF kurulumu ile migration ile db tabloları oluşturulması.
  - Servis ve controllerın hazırlanması.
  - CORS
5. [ ] Frontend işlemlerinin tamamlanması.
   - gerekli kütüphanelerin (axios, bootstrap, orval) kurulması
   - swager.json dan code generation
   - list Todo
   - add Todo
   - delete Todo
   - edit Todo
----

#### Oynatma listeleri
- [Bilgisayarlar Nasıl Çalışır?](https://www.youtube.com/watch?v=OAx_6-wdslM&list=PLzdnOPI1iJNcsRwJhvksEo1tJqjIqWbN-)
- [İnternet Nasıl Çalışır?](https://www.youtube.com/watch?v=Dxcc6ycZ73M&list=PLzdnOPI1iJNfMRZm5DDxco3UdsFegvuB7)
- [Bilgisayar Bilimleri Prensipleri](https://www.youtube.com/watch?v=15aqFQQVBWU&list=PLzdnOPI1iJNfV5ljCxR8BZWJRT_m_6CpB)
- [AI Nasıl Çalışır?](https://www.youtube.com/watch?v=Ok-xpKjKp2g&list=PLzdnOPI1iJNeehd1RXhnVMBFi1WhWLx_Y)
  
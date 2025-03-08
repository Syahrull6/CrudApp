# Employee Management CRUD Application

Aplikasi manajemen karyawan sederhana menggunakan ASP.NET Core MVC dengan akses database SQL Server.

## Deskripsi

Aplikasi web ini memungkinkan pengguna untuk melakukan operasi CRUD (Create, Read, Update, Delete) pada data karyawan. Aplikasi ini dibangun menggunakan ASP.NET Core MVC dan menggunakan SQL Server sebagai database.

## Fitur

- Menampilkan daftar semua karyawan
- Melihat detail karyawan tertentu
- Menambahkan karyawan baru
- Mengedit data karyawan yang sudah ada
- Menghapus karyawan dari database

## Teknologi yang Digunakan

- ASP.NET Core MVC
- SQL Server
- Entity Framework Core
- Bootstrap 5 (untuk UI)
- jQuery (untuk validasi client-side)

## Persyaratan Sistem

- .NET 6.0 SDK atau lebih tinggi
- SQL Server (versi 2019 atau lebih tinggi)
- Visual Studio 2022 (disarankan) atau Visual Studio Code

## Cara Instalasi

1. Clone repository ini ke komputer lokal Anda:
   ```
   git clone https://github.com/username/EmployeeManagementApp.git
   ```

2. Buka direktori proyek:
   ```
   cd EmployeeManagementApp
   ```

3. Buat database dan tabel yang diperlukan dengan menjalankan skrip SQL berikut di SQL Server Management Studio:
   ```sql
   CREATE DATABASE EmployeeDB;
   GO

   USE EmployeeDB;
   GO

   CREATE TABLE Employees (
       EmployeeId INT PRIMARY KEY IDENTITY(1,1),
       Name NVARCHAR(100) NOT NULL,
       Email NVARCHAR(100) NOT NULL,
       Department NVARCHAR(100) NOT NULL,
       Salary DECIMAL(18,2) NOT NULL,
       HireDate DATETIME NOT NULL
   );
   GO
   ```

4. Update connection string di file `appsettings.json` sesuai dengan konfigurasi SQL Server Anda:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Data Source=NAMA_SERVER\\INSTANCE;Initial Catalog=EmployeeDB;Integrated Security=True;TrustServerCertificate=True;"
   }
   ```

5. Jalankan aplikasi:
   ```
   dotnet run
   ```

## Cara Penggunaan

1. Buka aplikasi di browser dengan URL `http://localhost:5250`
2. Halaman utama akan menampilkan daftar semua karyawan
3. Klik tombol "Tambah Karyawan Baru" untuk menambahkan karyawan baru
4. Klik tombol "Edit" pada daftar karyawan untuk mengedit data karyawan
5. Klik tombol "Lihat" untuk melihat detail karyawan
6. Klik tombol "Hapus" untuk menghapus karyawan dari database

## Struktur Proyek

- **Controllers/**
  - `EmployeesController.cs` - Controller untuk operasi CRUD karyawan
- **Models/**
  - `Employee.cs` - Model data karyawan
- **Views/**
  - `Employees/` - View untuk operasi CRUD karyawan
- **Data/**
  - `EmployeeRepository.cs` - Repository untuk akses data

## Pemecahan Masalah

Jika Anda mengalami masalah "SSL Connection Error":
1. Pastikan Anda mengakses aplikasi menggunakan protokol HTTP, bukan HTTPS
2. Gunakan URL `http://localhost:5250` alih-alih `https://localhost:7250`
3. Jika masih terjadi error, cek firewall dan antivirus yang mungkin memblokir koneksi

Jika Anda mengalami masalah koneksi database:
1. Pastikan SQL Server sudah berjalan
2. Verifikasi connection string di `appsettings.json`
3. Pastikan database dan tabel Employees sudah dibuat

## Kontribusi

Jika Anda ingin berkontribusi pada proyek ini, silakan lakukan langkah berikut:
1. Fork repository ini
2. Buat branch fitur baru (`git checkout -b feature/fitur-baru`)
3. Commit perubahan Anda (`git commit -m 'Menambahkan fitur baru'`)
4. Push ke branch (`git push origin feature/fitur-baru`)
5. Buat Pull Request baru

## Lisensi

Proyek ini dilisensikan di bawah lisensi MIT. Lihat file `LICENSE` untuk informasi lebih lanjut.

## Kontak

Jika Anda memiliki pertanyaan atau masukan, silakan hubungi melalui email: email@example.com

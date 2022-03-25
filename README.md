# Tugas-Besar-2-STIMA
Tugas Besar 2 IF2211 Strategi Algoritma Semester II Tahun 2021/2022 Pengaplikasian Algoritma BFS dan DFS dalam Implementasi Folder Crawling

## Algoritma Traversal Graf
Algoritma traversal graf adalah algoritma mengunjungi simpul secara sistematik. Algoritma traversal graf merupakan salah satu algoritma pencarian solusi untuk representasi persoalan menggunakan graf.

## Algoritma Breadth First Search (BFS)
Algoritma pencarian melebar (Breadth First Search) menggunakan antrean dalam pencariannya. Pencarian dimulai dari akar graf, kemudian akan dicari setiap simpul yang bersisian dengan akar graf. Setiap simpul tersebut akan masuk ke dalam antrean. Proses akan diulang untuk setiap elemen pada antrean. Proses pencarian berhenti ketika elemen sudah ditemukan atau antrean kosong (semua simpul sudah dikunjungi).  

## Algoritma Depth First Search (DFS)
Berbeda dengan BFS yang melebar, DFS melakukan pencarian secara mendalam. Artinya BFS akan mencari simpul sampai simpul tersebut adalah simpul daun. Jika simpul tersebut adalah elemen yang akan dicari maka pencarian dihentikan. Jika belum ditemukan maka algoritma akan melakukan runut balik (backtrack) pada simpul sebelumnya dan mengulang langkah pencarian. Pencarian DFS ini bisa diimplementasikan menggunakan rekursif atau menggunakan struktur data tumpukan (stack). 

## Environment Requirements
* Visual Studio : [Download](https://visualstudio.microsoft.com/)
* C# : [Download](https://www.microsoft.com/en-us/download/details.aspx?id=7029)

## Setup
* Pastikan semua requirement di atas sudah terinstall pada perangkat keras yang akan digunakan.
* Untuk menjalankan program, dapat membuka executable file yang ada di dalam folder bin
* Untuk melakukan perubahan dapat membuka folder melalui visual studioU
* Untuk meng-compile program dapat dilakukan dengan cara menekan tombol build pada bagian atas folder, kemudian akan muncul executable file pada folder asal

## Authors
| Nama | NIM | Email |
| ----- | --- | ----------|
|Ilham Prasetyo Wibowo | 13520013 | <13520013@std.stei.itb.ac.id> |
|Muhammad Akmal Arifin | 13520037 | <13520037@std.stei.itb.ac.id> |
|Gregorius Moses Mareyson | 13520052 | <13520052@std.stei.itb.ac.id> |

## Referensi
Munir, R., 2022. BFS dan DFS (Bagian 1). [online] Informatika.stei.itb.ac.id. Available at: <https://informatika.stei.itb.ac.id/~rinaldi.munir/Stmik/2020-2021/BFS-DFS-2021-Bag1.pdf> [Accessed 25 Maret 2022].

Munir, R., 2022. BFS dan DFS (Bagian 2). [online] Informatika.stei.itb.ac.id. Available at: <https://informatika.stei.itb.ac.id/~rinaldi.munir/Stmik/2020-2021/BFS-DFS-2021-Bag2.pdf> [Accessed 25 Maret 2022].

Microsoft Windows Form .NET Documentation [online] docs.microsoft.com. Available at: <https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms?view=windowsdesktop-6.0 > [Accessed 2 February 2022].


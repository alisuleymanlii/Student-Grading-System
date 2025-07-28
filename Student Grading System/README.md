# 📚 Şagird Qiymətləndirmə / Student Grading System

Bu proqram **şagirdlərin adlarını, fənləri və qiymətlərini idarə etmək**, saxlamaq və izləmək üçün hazırlanmış sadə bir **C# konsol tətbiqidir**.  
This is a simple **C# console application** designed to manage, store, and track students' names, subjects, and grades.

---

## 🔧 Xüsusiyyətlər / Features

- ✅ Şagird əlavə etmək, silmək və siyahıya baxmaq  
- ✅ Fənləri əlavə etmək, silmək və siyahıya baxmaq  
- ✅ Şagirdlərə müxtəlif fənlər üzrə qiymət vermək  
- ✅ Orta balın hesablanması  
- ✅ Məlumatların `.txt` fayllarında saxlanması və oxunması  
- ✅ Konsol əsaslı interaktiv menyu sistemi

- ✅ Add, remove, and view students  
- ✅ Add, remove, and view subjects  
- ✅ Assign grades to students per subject  
- ✅ Calculate average grades  
- ✅ Store and read data from `.txt` files  
- ✅ Interactive console menu system

---

## 📁 Fayl Strukturu / File Structure

- `sagirdata.txt` → Şagird adları və soyadları / Students' full names  
- `fendata.txt` → Fənlərin siyahısı / List of subjects  
- `qiymetdata.txt` → Qiymətlər `Şagird,Fənn,Qiymət` formatında / Grades in `Student,Subject,Grade` format

---

## 📌 İstifadə Qaydası / Usage

1. Proqram başladıqda mövcud `.txt` fayllarından məlumatları oxuyur.  
2. Əsas menyudan seçim edərək şagirdlərə, fənlərə və qiymətlərə baxa, əlavə edə və ya silə bilərsiniz.  
3. Qiymət verərkən 0-dan 100-ə qədər tam ədədlər qəbul olunur.

1. The program loads data from existing `.txt` files on start.  
2. Use the main menu to view, add, or remove students, subjects, and grades.  
3. Grades must be whole numbers between 0 and 100.

---

## 📌 Nümunə Qiymet Formatı (`qiymetdata.txt`)

```
Ali Veliyev,Riyaziyyat,90
Ali Veliyev,Fizika,85
Leyla Məmmədova,Riyaziyyat,78
```

---

## 🔒 Qeyd / Notes

- Qiymətlər tam ədəd və 0-100 aralığında olmalıdır.  
- Hər şagird və fənn üçün yalnız bir qiymət qeyd olunur, yenisi köhnəsini əvəz edir.

- Grades must be whole numbers within 0-100.  
- Only one grade per student and subject is stored; new entries overwrite old ones.

---

## 🚀 Gələcək Planlar / Future Plans

- Qiymətlərə görə sıralama əlavə etmək  
- Ən yüksək və ən aşağı qiymətləri göstərmək  
- Məlumatları `JSON` formatına keçirmək  
- Windows Forms və ya web interfeysi hazırlamaq

- Add sorting by grades  
- Show highest and lowest grades  
- Switch data storage to `JSON` format  
- Create Windows Forms or web interface

---

## 👨‍💻 Müəllif / Author

**Ad:** Əli  
**Dil:** C#  
**Tətbiq Tipi:** Konsol tətbiqi  

**Name:** Ali  
**Language:** C#  
**Application Type:** Console app  

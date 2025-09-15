// CleanSchoolProgram.cs
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolManagement
{
    // 1. Tạo class Student thay vì dùng string "id|name|age|gpa"
    public class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double GPA { get; set; }

        public override string ToString()
        {
            return $"ID:{Id} | Name:{Name} | Age:{Age} | GPA:{GPA}";
        }
    }

    // 2. Tách logic quản lý sinh viên vào class StudentManager
    public class StudentManager
    {
        private readonly List<Student> students = new List<Student>();

        public void AddStudent()
        {
            Console.Write("Nhap id: ");
            string id = Console.ReadLine();
            Console.Write("Nhap ten: ");
            string name = Console.ReadLine();
            Console.Write("Nhap tuoi: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Nhap GPA: ");
            double gpa = double.Parse(Console.ReadLine());

            students.Add(new Student { Id = id, Name = name, Age = age, GPA = gpa });
        }

        public void RemoveStudent()
        {
            Console.Write("Nhap id can xoa: ");
            string id = Console.ReadLine();
            students.RemoveAll(s => s.Id == id);
        }

        public void UpdateStudent()
        {
            Console.Write("Nhap id can cap nhat: ");
            string id = Console.ReadLine();
            var student = students.FirstOrDefault(s => s.Id == id);

            if (student != null)
            {
                Console.Write("Nhap ten moi: ");
                student.Name = Console.ReadLine();
                Console.Write("Nhap tuoi moi: ");
                student.Age = int.Parse(Console.ReadLine());
                Console.Write("Nhap GPA moi: ");
                student.GPA = double.Parse(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("Khong tim thay sinh vien.");
            }
        }

        public void DisplayAll()
        {
            if (!students.Any())
            {
                Console.WriteLine("Danh sach rong.");
                return;
            }

            students.ForEach(s => Console.WriteLine(s));
        }

        public void FindByName()
        {
            Console.Write("Nhap ten: ");
            string name = Console.ReadLine();
            var found = students.Where(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            foreach (var s in found)
            {
                Console.WriteLine("Tim thay: " + s);
            }
        }

        public void DisplayExcellentStudents()
        {
            var excellent = students.Where(s => s.GPA > 8.0);
            foreach (var s in excellent)
            {
                Console.WriteLine("Sinh vien gioi: " + s);
            }
        }

        public void SortByName()
        {
            students.Sort((a, b) => a.Name.CompareTo(b.Name));
            Console.WriteLine("Da sap xep theo ten.");
        }

        public void SortByGPA()
        {
            students.Sort((a, b) => b.GPA.CompareTo(a.GPA));
            Console.WriteLine("Da sap xep theo GPA.");
        }
    }

    // 3. Chương trình chính
    public class CleanSchoolProgram
    {
        public static void Main()
        {
            var studentManager = new StudentManager();
            int menu = 0;

            while (menu != 99)
            {
                Console.WriteLine("============= MENU CHINH =============");
                Console.WriteLine("1. Quan ly Sinh vien");
                Console.WriteLine("99. Thoat");
                Console.Write("Nhap lua chon: ");
                menu = int.Parse(Console.ReadLine());

                if (menu == 1)
                {
                    int smenu = 0;
                    while (smenu != 9)
                    {
                        Console.WriteLine("--- QUAN LY SINH VIEN ---");
                        Console.WriteLine("1. Them SV");
                        Console.WriteLine("2. Xoa SV");
                        Console.WriteLine("3. Cap nhat SV");
                        Console.WriteLine("4. Hien thi tat ca SV");
                        Console.WriteLine("5. Tim SV theo ten");
                        Console.WriteLine("6. Tim SV GPA > 8");
                        Console.WriteLine("7. Sap xep theo ten");
                        Console.WriteLine("8. Sap xep theo GPA");
                        Console.WriteLine("9. Quay lai");

                        smenu = int.Parse(Console.ReadLine());
                        switch (smenu)
                        {
                            case 1: studentManager.AddStudent(); break;
                            case 2: studentManager.RemoveStudent(); break;
                            case 3: studentManager.UpdateStudent(); break;
                            case 4: studentManager.DisplayAll(); break;
                            case 5: studentManager.FindByName(); break;
                            case 6: studentManager.DisplayExcellentStudents(); break;
                            case 7: studentManager.SortByName(); break;
                            case 8: studentManager.SortByGPA(); break;
                        }
                    }
                }
            }
        }
    }
}

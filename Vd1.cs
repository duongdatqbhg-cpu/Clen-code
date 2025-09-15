// Chương trình quản lý trường học cực kỳ BAD CODE
// Lưu ý: code này chỉ để sinh viên phân tích, KHÔNG nên dùng thật
// Tất cả dữ liệu lưu trữ trong ArrayList<String> dạng "id|name|field1|field2|..."

import java.util.*;

// ❌ LỖI: Trước dùng ArrayList<String> lưu "id|name|age|gpa"
//        => Magic string / Stringly-typed data / Primitive Obsession
// ✅ SỬA: Tạo class Student với thuộc tính, getter/setter, toString
//        => Encapsulation, rõ ràng, dễ bảo trì, tránh lỗi split chuỗi

public class Student {
    // Thuộc tính (Encapsulation)
    private String id;
    private String name;
    private int age;
    private double gpa;

    // ✅ Constructor: tạo Student từ dữ liệu chuẩn
    public Student(String id, String name, int age, double gpa) {
        this.id = id;
        this.name = name;
        this.age = age;
        this.gpa = gpa;
    }

    // ✅ Getter/Setter: thay vì thao tác string thủ công
    public String getId() { return id; }
    public void setId(String id) { this.id = id; }

    public String getName() { return name; }
    public void setName(String name) { this.name = name; }

    public int getAge() { return age; }
    public void setAge(int age) { this.age = age; }

    public double getGpa() { return gpa; }
    public void setGpa(double gpa) { this.gpa = gpa; }

    // ✅ Override toString: thay cho ghép chuỗi "id|name|..."
    @Override
    public String toString() {
        return "ID:" + id + " | Name:" + name + " | Age:" + age + " | GPA:" + gpa;
    }
}

// ✅ Thêm class Teacher để thay thế việc dùng String "id|name|major"
class Teacher {
    private String id;
    private String name;
    private String major;

    public Teacher(String id, String name, String major) {
        this.id = id;
        this.name = name;
        this.major = major;
    }

    public String getId() {
        return id;
    }

    public void setName(String name) {
        this.name = name;
    }

    public void setMajor(String major) {
        this.major = major;
    }

    @Override
    public String toString() {
        return "ID:" + id + " Name:" + name + " Major:" + major;
    }
}


import java.util.ArrayList;
import java.util.Scanner;

import java.util.ArrayList;
import java.util.Scanner;
// dã sửa bởi cong do 
public class EnrollmentManager {
    private final ArrayList<String> enrollments;
    private final Scanner scanner;

    // Định nghĩa các lựa chọn menu dưới dạng hằng số
    private static final int ADD = 1;
    private static final int REMOVE = 2;
    private static final int LIST = 3;
    private static final int BACK = 9;

    public EnrollmentManager(ArrayList<String> enrollments, Scanner scanner) {
        this.enrollments = enrollments;
        this.scanner = scanner;
    }

    public void menu() {
        while (true) {
            printMenu();
            int choice = getUserChoice();

            switch (choice) {
                case ADD:
                    addEnrollment();
                    break;
                case REMOVE:
                    removeEnrollment();
                    break;
                case LIST:
                    listEnrollments();
                    break;
                case BACK:
                    System.out.println("Quay lai menu chinh...");
                    return; // Thoát khỏi vòng lặp menu
                default:
                    System.out.println("Lua chon khong hop le!");
            }
        }
    }

    private void printMenu() {
        System.out.println("--- QUAN LY DANG KY HOC ---");
        System.out.println("1. Dang ky mon hoc");
        System.out.println("2. Huy dang ky");
        System.out.println("3. Xem tat ca dang ky");
        System.out.println("9. Quay lai");
        System.out.print("Nhap lua chon: ");
    }

    private int getUserChoice() {
        while (!scanner.hasNextInt()) {
            System.out.println("Vui long nhap so!");
            scanner.next(); // bỏ input không hợp lệ
            System.out.print("Nhap lua chon: ");
        }
        int choice = scanner.nextInt();
        scanner.nextLine(); // clear buffer
        return choice;
    }

    private void addEnrollment() {
        System.out.print("Nhap id SV: ");
        String studentId = scanner.nextLine();
        System.out.print("Nhap id MH: ");
        String courseId = scanner.nextLine();
        enrollments.add(studentId + "|" + courseId);
        System.out.println("Dang ky thanh cong!");
    }

    private void removeEnrollment() {
        System.out.print("Nhap id SV: ");
        String studentId = scanner.nextLine();
        System.out.print("Nhap id MH: ");
        String courseId = scanner.nextLine();

        boolean removed = enrollments.removeIf(e -> {
            String[] parts = e.split("\\|");
            return parts[0].equals(studentId) && parts[1].equals(courseId);
        });

        if (removed) {
            System.out.println("Da huy dang ky.");
        } else {
            System.out.println("Khong tim thay dang ky.");
        }
    }

    private void listEnrollments() {
        if (enrollments.isEmpty()) {
            System.out.println("Chua co dang ky nao.");
            return;
        }
        System.out.println("Danh sach dang ky:");
        for (String e : enrollments) {
            String[] parts = e.split("\\|");
            System.out.println("SV: " + parts[0] + " -> MH: " + parts[1]);
        }
    }
}


    private void addEnrollment() {
        System.out.print("Nhap id SV: ");
        String sid = sc.nextLine();
        System.out.print("Nhap id MH: ");
        String cid = sc.nextLine();
        enrollments.add(sid + "|" + cid);
        System.out.println("Đã đăng ký thành công!");
    }

    private void removeEnrollment() {
        System.out.print("Nhap id SV: ");
        String sid = sc.nextLine();
        System.out.print("Nhap id MH: ");
        String cid = sc.nextLine();

        boolean removed = false;
        for (int i = 0; i < enrollments.size(); i++) {
            String[] p = enrollments.get(i).split("\\|");
            if (p[0].equals(sid) && p[1].equals(cid)) {
                enrollments.remove(i);
                removed = true;
                break;
            }
        }
        if (removed) {
            System.out.println("Huy dang ky thanh cong!");
        } else {
            System.out.println("Khong tim thay dang ky nay.");
        }
    }

    private void listEnrollments() {
        if (enrollments.isEmpty()) {
            System.out.println("Chua co dang ky nao.");
            return;
        }
        for (String e : enrollments) {
            String[] p = e.split("\\|");
            System.out.println("SV: " + p[0] + " dang ky MH: " + p[1]);
        }
    }
}

public class GoodSchoolProgram {
    // ❌ Lỗi: Trước để tất cả logic trong main() => God Method
    // ✅ Sửa: Tách dữ liệu thành List<Entity>
    private static List<Student> students = new ArrayList<>();
    private static List<Teacher> teachers = new ArrayList<>();
    private static List<Course> courses = new ArrayList<>();
    private static List<Enrollment> enrollments = new ArrayList<>();
    private static List<Grade> grades = new ArrayList<>();

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int menu = 0;
        while (menu != 99) {
            System.out.println("============= MENU CHINH =============");
            System.out.println("1. Quan ly Sinh vien");
            System.out.println("2. Quan ly Giao vien");
            System.out.println("3. Quan ly Mon hoc");
            System.out.println("4. Quan ly Dang ky hoc");
            System.out.println("5. Quan ly Diem");
            System.out.println("6. Bao cao tong hop");
            System.out.println("99. Thoat");
            System.out.print("Nhap lua chon: ");
            menu = sc.nextInt(); sc.nextLine();

            switch (menu) {
                case 1->studentMenu(sc);
                case 2->teacherMenu(sc);
                case 3->courseMenu(sc);
                case 4->enrollmentMenu(sc);
                case 5->gradeMenu(sc);
                case 6->reportMenu();
            }
        }
    }
    
        // ========================== SUB MENUS ==========================

    private static void studentMenu(Scanner sc) {
        int smenu = 0;
        while (smenu != 9) {
            System.out.println("--- QUAN LY SINH VIEN ---");
            System.out.println("1. Them SV");
            System.out.println("2. Xoa SV");
            System.out.println("3. Cap nhat SV");
            System.out.println("4. Hien thi tat ca SV");
            System.out.println("5. Tim SV theo ten");
            System.out.println("6. Tim SV GPA > 8");
            System.out.println("7. Sap xep theo ten");
            System.out.println("8. Sap xep theo GPA");
            System.out.println("9. Quay lai");
            smenu = sc.nextInt(); sc.nextLine();

            switch (smenu) {
                case 1 -> {
                    System.out.print("Nhap id: "); String id = sc.nextLine();
                    System.out.print("Nhap ten: "); String name = sc.nextLine();
                    System.out.print("Nhap tuoi: "); int age = sc.nextInt(); sc.nextLine();
                    System.out.print("Nhap GPA: "); double gpa = sc.nextDouble(); sc.nextLine();
                    students.add(new Student(id, name, age, gpa));
                }
                case 2 -> {
                    System.out.print("Nhap id can xoa: "); String id = sc.nextLine();
                    students.removeIf(s -> s.getId().equals(id));
                }
                case 3 -> {
                    System.out.print("Nhap id can cap nhat: "); String id = sc.nextLine();
                    for (Student s : students) {
                        if (s.getId().equals(id)) {
                            System.out.print("Nhap ten moi: "); s.setName(sc.nextLine());
                            System.out.print("Nhap tuoi moi: "); s.setAge(sc.nextInt()); sc.nextLine();
                            System.out.print("Nhap GPA moi: "); s.setGpa(sc.nextDouble()); sc.nextLine();
                        }
                    }
                }
                case 4 -> students.forEach(System.out::println);
                case 5 -> {
                    System.out.print("Nhap ten: "); String name = sc.nextLine();
                    students.stream().filter(s -> s.getName().equals(name)).forEach(System.out::println);
                }
                case 6 -> students.stream().filter(s -> s.getGpa() > 8).forEach(System.out::println);
                case 7 -> {
                    students.sort(Comparator.comparing(Student::getName));
                    System.out.println("Da sap xep theo ten.");
                }
                case 8 -> {
                    students.sort(Comparator.comparing(Student::getGpa).reversed());
                    System.out.println("Da sap xep theo GPA.");
                }
            }
        }
    }

    private static void teacherMenu(Scanner sc) {
        int tmenu = 0;
        while (tmenu != 9) {
            System.out.println("--- QUAN LY GIAO VIEN ---");
            System.out.println("1. Them GV");
            System.out.println("2. Xoa GV");
            System.out.println("3. Cap nhat GV");
            System.out.println("4. Hien thi GV");
            System.out.println("9. Quay lai");
            tmenu = sc.nextInt(); sc.nextLine();

            switch (tmenu) {
                case 1 -> {
                    System.out.print("Nhap id GV: "); String id = sc.nextLine();
                    System.out.print("Nhap ten GV: "); String name = sc.nextLine();
                    System.out.print("Nhap chuyen mon: "); String major = sc.nextLine();
                    teachers.add(new Teacher(id, name, major));
                }
                case 2 -> {
                    System.out.print("Nhap id GV can xoa: "); String id = sc.nextLine();
                    teachers.removeIf(t -> t.getId().equals(id));
                }
                case 3 -> {
                    System.out.print("Nhap id GV cap nhat: "); String id = sc.nextLine();
                    for (Teacher t : teachers) {
                        if (t.getId().equals(id)) {
                            System.out.print("Nhap ten moi: "); t.setName(sc.nextLine());
                            System.out.print("Nhap chuyen mon moi: "); t.setMajor(sc.nextLine());
                        }
                    }
                }
                case 4 -> teachers.forEach(System.out::println);
            }
        }
    }

    private static void courseMenu(Scanner sc) {
        int cmenu = 0;
        while (cmenu != 9) {
            System.out.println("--- QUAN LY MON HOC ---");
            System.out.println("1. Them MH");
            System.out.println("2. Xoa MH");
            System.out.println("3. Cap nhat MH");
            System.out.println("4. Hien thi MH");
            System.out.println("9. Quay lai");
            cmenu = sc.nextInt(); sc.nextLine();

            switch (cmenu) {
                case 1 -> {
                    System.out.print("Nhap id MH: "); String id = sc.nextLine();
                    System.out.print("Nhap ten MH: "); String name = sc.nextLine();
                    System.out.print("Nhap so tin chi: "); int tc = sc.nextInt(); sc.nextLine();
                    courses.add(new Course(id, name, tc));
                }
                case 2 -> {
                    System.out.print("Nhap id MH can xoa: "); String id = sc.nextLine();
                    courses.removeIf(c -> c.getId().equals(id));
                }
                case 3 -> {
                    System.out.print("Nhap id MH cap nhat: "); String id = sc.nextLine();
                    for (Course c : courses) {
                        if (c.getId().equals(id)) {
                            System.out.print("Nhap ten moi: "); c.setName(sc.nextLine());
                            System.out.print("Nhap tin chi moi: "); c.setCredits(sc.nextInt()); sc.nextLine();
                        }
                    }
                }
                case 4 -> courses.forEach(System.out::println);
            }
        }
    }

    private static void enrollmentMenu(Scanner sc) {
        int emenu = 0;
        while (emenu != 9) {
            System.out.println("--- QUAN LY DANG KY HOC ---");
            System.out.println("1. Dang ky mon hoc");
            System.out.println("2. Huy dang ky");
            System.out.println("3. Xem tat ca dang ky");
            System.out.println("9. Quay lai");
            emenu = sc.nextInt(); sc.nextLine();

            switch (emenu) {
                case 1 -> {
                    System.out.print("Nhap id SV: "); String sid = sc.nextLine();
                    System.out.print("Nhap id MH: "); String cid = sc.nextLine();
                    enrollments.add(new Enrollment(sid, cid));
                }
                case 2 -> {
                    System.out.print("Nhap id SV: "); String sid = sc.nextLine();
                    System.out.print("Nhap id MH: "); String cid = sc.nextLine();
                    enrollments.removeIf(e -> e.getStudentId().equals(sid) && e.getCourseId().equals(cid));
                }
                case 3 -> enrollments.forEach(System.out::println);
            }
        }
    }

    private static void gradeMenu(Scanner sc) {
        int gmenu = 0;
        while (gmenu != 9) {
            System.out.println("--- QUAN LY DIEM ---");
            System.out.println("1. Nhap diem");
            System.out.println("2. Cap nhat diem");
            System.out.println("3. Hien thi diem");
            System.out.println("9. Quay lai");
            gmenu = sc.nextInt(); sc.nextLine();

            switch (gmenu) {
                case 1 -> {
                    System.out.print("Nhap id SV: "); String sid = sc.nextLine();
                    System.out.print("Nhap id MH: "); String cid = sc.nextLine();
                    System.out.print("Nhap diem: "); double d = sc.nextDouble(); sc.nextLine();
                    grades.add(new Grade(sid, cid, d));
                }
                case 2 -> {
                    System.out.print("Nhap id SV: "); String sid = sc.nextLine();
                    System.out.print("Nhap id MH: "); String cid = sc.nextLine();
                    for (Grade g : grades) {
                        if (g.getStudentId().equals(sid) && g.getCourseId().equals(cid)) {
                            System.out.print("Nhap diem moi: "); g.setScore(sc.nextDouble()); sc.nextLine();
                        }
                    }
                }
                case 3 -> grades.forEach(System.out::println);
            }
        }
    }

    private static void reportMenu() {
        System.out.println("=== BAO CAO ===");
        for (Student s : students) {
            System.out.println("Sinh vien: " + s.getName());
            for (Enrollment e : enrollments) {
                if (e.getStudentId().equals(s.getId())) {
                    for (Course c : courses) {
                        if (c.getId().equals(e.getCourseId())) {
                            System.out.print(" - Mon hoc: " + c.getName());
                            grades.stream()
                                  .filter(g->g.getStudentId().equals(s.getId()) && g.getCourseId().equals(c.getId()))
                                  .forEach(g->System.out.print(" | Diem: " + g.getScore()));
                            System.out.println();
                        }
                    }
                }
            }
        }

    }
}

***************************************************Dokumentacija************************************************************************************

Za implementaciju StudentWebApi-ja koriscena je Microsoft Sql Server relaciona baza podataka, Entity Framework Core za objektno-relaciono mapiranje 
i ASP.NET Core.

U istom direktorijumu je dodat Class Diagram koji opisuje entitete u bazi: students, courses i enrollments.

Postoje tri kontrolera koji odgovaraju ovim resursima:
1. StudentController
2. CourseController
3. EnrollmentController

U StudentController i CourseController-u implementirane su metode koje odgovaraju HTTP GET, POST, PUT i DELETE, odnosno CRUD akcijama.

StudentController ima pet metoda:
1. [HTTP GET] GetAll([FromQuery] StudentsFilterQuery filter) - uzima sve studente iz baze sa mogucnoscu filtriranja po imenu, gradu i drzavi(LIKE-clause).
2. [HTTP GET] FindById(int id) - pronalazi studenta na osnovu id-ja
3. [HTTP POST] Add([FromBody] Student student) - dodaje novog studenta u bazu i vraca kao povratnu vrednost
4. [HTTP PUT] Update(int id, [FromBody] Student student) - pronalazi studenta na osnovu id-ja, azurira i cuva promene u bazi
5. [HTTP DELETE] Remove(int id) - brise studenta iz baze na osnovu id-ja

CourseController ima pet metoda:
1. [HTTP GET] GetAll([FromQuery] string? courseTitle) - uzima sve studente iz baze sa mogucnoscu filtriranja po nazivu kursa(LIKE-clause).
2. [HTTP GET] FindByCode(int courseCode) - pronalazi kurs na osnovu koda koji predstavlja primarni kljuc u bazi
3. [HTTP POST] Add([FromBody] Course course) - dodaje novi kurs u bazu i vraca kao povratnu vrednost
4. [HTTP PUT] Update(int id, [FromBody] Course c) - azurira kurs
5. [HTTP DELETE] Remove(int id) - brise kurs iz baze na osnovu id-ja

EnrollmentController ima tri metode:
1. [HTTP POST] EnrollToCourse(int studentId, int courseCode) - dodaje novu vrstu u tabeli Enrollments, gde pravi kompozitni kljuc na osnovu 
studentId-ja i courseCode-a. Ocena je po defaultu null
2. [HTTP DELETE] LeaveCourse(int studentId, int courseCode) - student napusta kurs tako sto se brise vrsta koja je sadrzala vezu izmedju studenta 
sa studentId-jem i kursa sa courseCode-om
3. [HTTP PUT] Evaluate(int studentId, int courseCode, int mark) - pronalazi odredjenu vrstu u tabeli Enrollments, a zatim azurira ocenu za 
odredjenog studenta na kursu sa zadatim courseCode-om


**********************************************************************************************************************************************************
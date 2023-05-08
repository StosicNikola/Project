INSERT INTO Students
 (Firstname,Lastname,Address,City,State,DateOfBirth,Gender) 
 VALUES ('Pera','Peric','BB','Nis','Srbija','2022-01-20',0), ('Mila','Jovanovic','BB','Nis','Srbija','2022-01-20',1),
 ('Darko','Peric','BB','Nis','Srbija','2022-01-20',2),('Ivan','Ivanovic','BB','Nis','Srbija','2022-01-20',0)
 GO


 INSERT INTO Courses
 Values ('Matematika','Mnozenje/Deljenje'), ('Srpski jezik','Gramatika')

 
INSERT INTO Enrollments
 VALUES (1,1,5),(1,2,6),(2,1,4)

 INSERT INTO Enrollments(StudentId,CourseCode)
 VALUES (4,1)

SELECT * FROM Students;
SELECT * FROM Courses;
SELECT * FROM Enrollments;
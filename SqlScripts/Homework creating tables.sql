use Homework

create table Subjects(
	Id int identity(1,1) constraint PK_Subjects primary key,
	Classroom int,
	SubjectName nvarchar(30)
) 

create table Schedule(
	Id int identity(1,1) constraint  PK_Schedule primary key,
	DayOfTheWeek nvarchar(20),
	FirstSubject int constraint FK_Schedule_Subjects_First references Subjects(Id),
	SecondSubject int constraint FK_Schedule_Subjects_Second references Subjects(Id),
	ThirdSubject int constraint FK_Schedule_Subjects_Third references Subjects(Id)
)

create table Teacher(
	Id int identity(1,1) constraint PK_Teachers primary key,
	TeachersName nvarchar(50),
	TaughtSubject int constraint FK_Teacher_Subjects references Subjects(Id)
)

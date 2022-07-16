use Homework
-- inserting data

insert into Subjects
	(Classroom, SubjectName)
values
	(319,'Math'),
	(403,'Economics'),
	(100,'PE'),
	(304,'CS'),
	(113,'Biology'),
	(214,'Web'),
	(104,'Art'),
	(307,'English'),
	(318,'Russian')

insert into Schedule
	(DayOfTheWeek, FirstSubject, SecondSubject, ThirdSubject)
values
	('Monday',2,3,4),
	('Tuesday',5,3,1),
	('Wednesday',6,8,9),
	('Thusrday',2,7,1),
	('Friday',6,7,5)

insert into Teacher 
	(TeachersName, TaughtSubject)
values
	('Michael',1),
	('Michel',2),
	('Mike',3),
	('Moroz',4),
	('Mirror',5),
	('Katerine',6),
	('Bob',7),
	('Joe',8),
	('Dave',9)
	('Dave',3),
	('Clark',8),
	('Utop',8)

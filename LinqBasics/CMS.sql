
CREATE TABLE [Students] (
    [StudentId] INTEGER NOT NULL PRIMARY KEY,
    [FirstName] TEXT,
    [LastName] TEXT,
    [CourseId] INTEGER
);

CREATE TABLE IF NOT EXISTS [Courses]( 
    [CourseId] INTEGER NOT NULL PRIMARY KEY,
    [CourseName] TEXT NOT NULL);

INSERT INTO "Students" VALUES (101, "James", "Smith", 1);
INSERT INTO "Students" VALUES (102, "Robert", "Smith", 2);
INSERT INTO "Students" VALUES (103, "Maria", "Garcie", 3);
INSERT INTO "Students" VALUES (104, "David", "Smith", 1);
INSERT INTO "Students" VALUES (105, "James", "Johnson", 2);
INSERT INTO "Students" VALUES (106, "John", "SevenLast", 3);
INSERT INTO "Students" VALUES (107, "Maria", "Rodriguez", 1);
INSERT INTO "Students" VALUES (108, "Mary", "Smith", 2);


INSERT INTO "Courses" VALUES (1, "Computer Science");
INSERT INTO "Courses" VALUES (2, "Marketing");
INSERT INTO "Courses" VALUES (3, "Accounting");

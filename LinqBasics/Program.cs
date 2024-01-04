using System;
using System.Linq;
using System.Collections.Generic;
using LinqBasics.CMS;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;
using System.IO;

namespace LinqBasics
{
    class Program
    {
        static List<StudentLinqBasic> students = new List<StudentLinqBasic>();
        static List<CourseLinqBasic> courses = new List<CourseLinqBasic>();

        static void Initialize()
        {


            students.Add(new EngineeringStudent(101, "James", "Smith", 1));
            students.Add(new EngineeringStudent(102, "Gaminiah", "Smith", 2));
            students.Add(new EngineeringStudent(103, "Gemma", "James", 3));
            students.Add(new MedicalStudent(104, "Maria", "Rodriguez", 1));
            students.Add(new MedicalStudent(105, "James", "Johnson", 2));
            students.Add(new EngineeringStudent(106, "John", "SevenLast", 3));
            students.Add(new MedicalStudent(107, "Maria", "Garcia", 1));
            students.Add(new MedicalStudent(108, "Mary", "Smith", 2));
            students.Add(new MedicalStudent(109, "James", "Anderson", 3));

            courses.Add(new CourseLinqBasic(1, "Computer Science"));
            courses.Add(new CourseLinqBasic(2, "Marketing"));
            courses.Add(new CourseLinqBasic(3, "Accounting"));
        }

        public static void Main(string[] args)
        {
            //Querry student
            Initialize();

            #region Linq to object
            //WhereDemo();
            //LinqOfType();
            //LinqSelectAnonymous();
            //LinqSelectMany();
            //LinqOrderBy();
            //LinqOrderByDesc();
            //LinqThenBy();
            //LinqThenByDesc();
            //LinqReverse();
            //LinqJoin();
            //LinqGroupJoin();
            //LinqGroupBy();
            //LinqToLookup();
            //AssigementThree();
            //LinqElementAt();
            //LinqElementAtOrDefault();
            //LinqFirst();
            //LinqFirstOrDefault();
            //LinqLast();
            //LinqLastOrDefault();
            //LinqSingle();
            //LinqSingleOrDefault();
            //LinqAll();
            //LinqAny();
            //LinqContains();
            //LinqMin();
            //LinqMax();
            //LinqSum();
            //LinqCount();
            //LinqAverage();
            #endregion
            
            LinqToEntities_Projections();
            //LinqToEntities_Aggregation();
            //LinqToEntities_Join();
            //LinqJson();
            //LinqXml();
            //XmlRead();
            //CreatingJsonUsingLinq();
            //ParsingJsonFromString();
            //ParsiongJsonFromStream();
            //QueryingJsonUsingPropertyName();
            //QueryingJsonUsingCollectionIndex();
            //QueryingJsonUsingLing();
            //QueryingJsonUsingSelectToken();

            Action<string> greet = name =>
            {
                string greeting = $"Hello {name}!";
                Console.WriteLine(greeting);
            };


            greet("world");

            Test test = new Test();
            test.ExtensionMethod();

            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                ["One"] = 1,
                ["Two"] = 2,
                ["Three"] = 3
            };
            Console.ReadLine();
        }
        #region Linq to object
        #region Filtering in Linq
        static void WhereDemo()
        {
            IEnumerable<StudentLinqBasic> querry = from student in students
                                                   where student.LastName == "Smith"
                                                   where student.FirstName == "Mary"
                                                   select student;

            querry = students.Where(x => x.LastName.Equals("Smith"))
                             .Where(x => x.FirstName.Equals("Mary"));

            foreach (var student in querry)
                Console.WriteLine(student.FirstName);
        }
        static void LinqOfType()
        {
            IEnumerable<EngineeringStudent> enggStudent = students.OfType<EngineeringStudent>();
            foreach (EngineeringStudent item in enggStudent)
                Console.WriteLine(item.FirstName + "   " + item.LastName);
        }
        #endregion

        #region Projections in Linq
        static void LinqSelect()
        {
            IEnumerable<StudentLinqBasic> querry = from student in students
                                                   select student;

            querry = students.Select(x => x);

            foreach (var student in querry)
                Console.WriteLine(student.FirstName);

        }
        static void LinqSelectProjection()
        {
            var querry = from student in students
                         select (student.StudentId, student.FirstName);

            querry = students.Select(x => (x.StudentId, x.FirstName));

            foreach (var student in querry)
                Console.WriteLine(student.FirstName);
        }
        static void LinqSelectAnonymous()
        {
            var querry = from student in students
                         select new {
                             ID = student.StudentId,
                             name = student.LastName
                         };

            querry = students.Select(x => new
            {
                ID = x.StudentId,
                name = x.LastName
            });

            foreach (var student in querry)
                Console.WriteLine(student.ID.ToString() + " " + student.name);

        }
        static void LinqSelectMany()
        {
            var querry = from student in students
                         from a in student.FirstName.ToArray()
                         select a;

            querry = students.SelectMany(x => x.FirstName.ToArray(), (students, x) => (x));

            foreach (var student in querry)
                Console.WriteLine(student);


        }
        #endregion

        #region Ordering in Linq
        static void LinqOrderBy()
        {
            IEnumerable<StudentLinqBasic> querry = from student in students
                                                   orderby student.FirstName
                                                   select student;

            querry = students.OrderBy(x => x.FirstName);

            foreach (var student in querry)
                Console.WriteLine(student.FirstName);

        }
        static void LinqOrderByDesc()
        {
            IEnumerable<StudentLinqBasic> querry = from student in students
                                                   orderby student.FirstName descending
                                                   select student;

            querry = students.OrderByDescending(x => x.FirstName);

            foreach (var student in querry)
                Console.WriteLine(student.FirstName);
        }
        static void LinqThenBy()
        {
            IEnumerable<StudentLinqBasic> querry = from student in students
                                                   orderby student.FirstName, student.LastName
                                                   select student;

            querry = students.OrderBy(x => x.FirstName)
                             .ThenBy(x => x.LastName);

            foreach (var student in querry)
                Console.WriteLine(student.FirstName + " " + student.LastName);
        }
        static void LinqThenByDesc()
        {
            IEnumerable<StudentLinqBasic> querry = from student in students
                                                   orderby student.FirstName, student.LastName descending
                                                   select student;

            querry = students.OrderByDescending(x => x.FirstName)
                             .ThenByDescending(x => x.LastName);

            foreach (var student in querry)
                Console.WriteLine(student.FirstName + " " + student.LastName);
        }
        static void LinqReverse()
        {
            students.Reverse();

            foreach (var student in students)
                Console.WriteLine(student.FirstName + " " + student.LastName);
        }
        #endregion

        #region Joins in Linq
        static void LinqJoin()
        {
            var querry = from student in students
                         join course in courses
                         on student.CourseId equals course.CourseId
                         select new { student.StudentId,
                             student.FirstName,
                             course.CourseName };


            querry = students.Join(courses, x => x.CourseId,
                               x => x.CourseId, (s, c) => new {
                                   s.StudentId,
                                   s.FirstName,
                                   c.CourseName
                               });
        }
        static void LinqGroupJoin()
        {
            var querry = from course in courses
                         join student in students
                         on course.CourseId equals student.CourseId
                         into CourseStudents
                         select new { course.CourseName, CourseStudents };


            querry = courses.GroupJoin(students, x => x.CourseId, x => x.CourseId,
                             (c, CourseStudents) => new { c.CourseName, CourseStudents });


            foreach (var item in querry)
            {
                Console.WriteLine("\n" + item.CourseName);
                foreach (var student in item.CourseStudents)
                {
                    Console.WriteLine($"{student.StudentId}  {student.FirstName}");
                }
            }
        }
        static void LinqGroupBy()
        {
            var querry = from student in students
                         group student by student.CourseId;

            querry = students.GroupBy(x => x.CourseId);

            foreach (var item in querry)
            {
                Console.WriteLine($"course ID: {item.Key}");
                foreach (var it in item)
                {
                    Console.WriteLine($"Student: {it.StudentId}  {it.LastName}");
                }
            }
        }
        static void LinqToLookup()
        {

            var querry = students.ToLookup(x => x.CourseId);

            for (int i = 1; i < 4; i++)
            {
                Console.WriteLine(i);
                foreach (var it in querry[i])
                {
                    Console.WriteLine($"Student: {it.FirstName}  {it.LastName}");
                }
            }
        }
        #endregion

        #region Element operations in Linq
        static void LinqElementAt()
        {
            StudentLinqBasic querry = students.ElementAt(10);
            Console.WriteLine($"{querry.FirstName} {querry.LastName}");
        }
        static void LinqElementAtOrDefault()
        {
            StudentLinqBasic querry = students.ElementAtOrDefault(0);
            if (querry == null)
            {
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"{querry.FirstName} {querry.LastName}");
            }
        }
        static void LinqFirst()
        {
            StudentLinqBasic querry = students.Where(x => x.LastName.Equals("Smith")).First();
            Console.WriteLine($"{querry.FirstName} {querry.LastName}");
        }
        static void LinqFirstOrDefault()
        {
            StudentLinqBasic querry = students.Where(x => x.LastName.Equals("Goldberg")).FirstOrDefault();
            if (querry == null)
            {
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"{querry.FirstName} {querry.LastName}");
            }
        }
        static void LinqLast()
        {
            StudentLinqBasic querry = students.Where(x => x.LastName.Equals("Smith")).Last();
            Console.WriteLine($"{querry.FirstName} {querry.LastName}");
        }
        static void LinqLastOrDefault()
        {
            StudentLinqBasic querry = students.Where(x => x.LastName.Equals("Goldberg")).LastOrDefault();
            if (querry == null)
            {
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"{querry.FirstName} {querry.LastName}");
            }
        }
        static void LinqSingle()
        {
            StudentLinqBasic querry = students.Where(x => x.LastName.Equals("Smith")).Single();
            Console.WriteLine($"{querry.FirstName} {querry.LastName}");
        }
        static void LinqSingleOrDefault()
        {
            StudentLinqBasic querry = students.Where(x => x.LastName.Equals("Goldberg")).SingleOrDefault();
            if (querry == null)
            {
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"{querry.FirstName} {querry.LastName}");
            }
        }
        #endregion

        #region Quantification in Linq
        static void LinqAll()
        {
            bool querry = students.All(x => x.CourseId.Equals(1));
            querry = students.All(x => x.FirstName.Length > 5);
            Console.WriteLine(querry);
        }
        static void LinqAny()
        {
            bool querry = students.Any(x => x.FirstName.Length > 5);
            Console.WriteLine(querry);
        }
        static void LinqContains()
        {
            bool querry = students.Contains(students.ElementAt(0));
            Console.WriteLine(querry);
        }
        #endregion

        #region Aggregation in Linq
        static void LinqAverage()
        {
            double querry = students.Average(x => x.StudentId);
            Console.WriteLine(querry);
        }
        static void LinqMin()
        {
            int querry = students.Min(x => x.StudentId);
            Console.WriteLine(querry);
        }
        static void LinqMax()
        {
            int querry = students.Max(x => x.StudentId);
            Console.WriteLine(querry);
        }
        static void LinqSum()
        {
            int querry = students.Sum(x => x.StudentId);
            Console.WriteLine(querry);
        }
        static void LinqCount()
        {
            int querry = students.Count();
            Console.WriteLine(querry);
        }
        #endregion

        #region Assigements
        static void AssigementOne()
        {
            List<int> numbers = new List<int> { 1, 2, 4, 5, 6, 10, 7 };

            Console.WriteLine("Querry syntax");
            var querrySyntax = from i in numbers
                               where i % 2 == 0
                               select i;
            foreach (int number in querrySyntax)
                Console.WriteLine(number);

            Console.WriteLine("Method syntax");
            var querryMethod = numbers.Where(x => x % 2 == 1);

            foreach (int number in querryMethod)
                Console.WriteLine(number);
        }
        static void AssigementTwo()
        {
            List<int> numbers = new List<int> { 1, 2, 4, 5, 6, 10, 7 };

            Console.WriteLine("Querry syntax");
            var querrySyntax = from i in numbers
                               select i * i;

            foreach (int number in querrySyntax)
                Console.WriteLine(number);

            Console.WriteLine("Method syntax");
            var querryMethod = numbers.Select(x => x * x);

            foreach (int number in querryMethod)
                Console.WriteLine(number);
        }
        static void AssigementThree()
        {
            var querry = students.Where(x => x.LastName.StartsWith("S"))
            .Select(x => new
            {
                ID = x.CourseId,
                FirstName = x.FirstName
            });

            foreach (var item in querry)
                Console.WriteLine($"ID: {item.ID} Name: {item.FirstName}");


            var querry2 = students.OrderByDescending(x => x.LastName)
                                  .Select(x => new
                                  { ID = x.StudentId,
                                      LastName = x.LastName });
            foreach (var item in querry2)
                Console.WriteLine($"{item.ID} {item.LastName}");
        }
        #endregion
        #endregion
        #region Linq to entities

        static void LinqToEntities_Projections()
        {
            CMSContext db = new CMSContext();

            //Querry syntax
            var querry = from student in db.Students
                         select new { student.StudentId,
                             student.FirstName };
            foreach (var student in querry)
            {
                Console.WriteLine($"{student.StudentId} {student.FirstName}");
            }

            querry = db.Students.Select(x => new { x.StudentId, x.FirstName });

            foreach (var student in querry)
            {
                Console.WriteLine($"{student.StudentId} {student.FirstName}");
            }

        }
        static void LinqToEntities_Aggregation()
        {
            CMSContext db = new CMSContext();

            Console.WriteLine(db.Students.Count());
            Console.WriteLine(db.Students.Min(x => x.StudentId));
            Console.WriteLine(db.Students.Max(x => x.StudentId));
        }
        static void LinqToEntities_Join()
        {
            CMSContext db = new CMSContext();
            var querry = db.Students.Join(db.Courses, x => x.CourseId, x => x.CourseId, (c, s) => new { c.FirstName, s.CourseName });
            foreach (var item in querry)
            {
                Console.WriteLine($"{item.FirstName} {item.CourseName}");
            }
        }

        #endregion
        #region Linq to xml

        static void LinqJson()
        {
            CMSContext db = new CMSContext();

            JObject root =
                new JObject(
                    new JProperty("Students",
                        new JArray(
                            students.Select(x => new JObject(
                                    new JProperty("StudentId", x.StudentId),
                                    new JProperty("FirstName", x.FirstName),
                                    new JProperty("LastName", x.LastName)
                                ))
                    )));

            Console.WriteLine(root);
        }
        static void CreatingJsonUsingLinq()
        {
            StudentEntity student = new StudentEntity(101, "James", "Smith", 1);
            JObject root = JObject.FromObject(student);

            Console.WriteLine(root);

            JObject rootArray = JObject.FromObject(new
            {
                students
            });
            Console.WriteLine(rootArray);
        }
        static void ParsingJsonFromString()
        {
            string student = @"{
                                'StudentId': 101,
                                'FirstName': 'James',
                                'LastName': 'Smith',
                                'CourseId': 1
                                }";
            JObject studentObject = JObject.Parse(student);
            Console.WriteLine(studentObject);
        }

        static void ParsiongJsonFromStream()
        {
            JToken token;
            using (StreamReader streamReader = new StreamReader("students.json"))
            {
                token = JToken.ReadFrom(new JsonTextReader(streamReader));
            }
            Console.WriteLine(token);
        }

        static void QueryingJsonUsingPropertyName()
        {
            StudentEntity student = new StudentEntity(101, "James", "Smith", 1);
            JObject root = JObject.FromObject(student);

            Console.WriteLine(root["StudentId"]);
            Console.WriteLine(root["FirstName"]);
            Console.WriteLine(root["LastName"]);
            Console.WriteLine(root["CourseId"]);
        }

        static void QueryingJsonUsingCollectionIndex()
        {
            JToken token;
            using (StreamReader streamReader = new StreamReader("students.json"))
            {
                token = JToken.ReadFrom(new JsonTextReader(streamReader));
            }

            JArray array = (JArray)token["Students"];
            Console.WriteLine(array.Count);
            foreach (var item in array)
            {
                Console.WriteLine(item["StudentId"]);
                Console.WriteLine(item["FirstName"]);
                Console.WriteLine(item["LastName"]);
                Console.WriteLine(item["CourseId"]);
            }
        }

        static void QueryingJsonUsingLing()
        {
            JToken token;
            using (StreamReader streamReader = new StreamReader("students.json"))
            {
                token = JToken.ReadFrom(new JsonTextReader(streamReader));
            }

            var query = token["Students"].Select(x => x["StudentId"]);
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }

        static void QueryingJsonUsingSelectToken()
        {
            JToken token;
            using (StreamReader streamReader = new StreamReader("students.json"))
            {
                token = JToken.ReadFrom(new JsonTextReader(streamReader));
            }
            int studentId = (int)token.SelectToken("Students[4].StudentId");
            Console.WriteLine("Student id in 5th position = "+ studentId);
            JToken query = token.SelectToken("Students[4]");
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }

        }

        static void LinqXml()
        {
            CMSContext db = new CMSContext();

            XElement xmlMethod = new XElement("Students",
                                    students.Select(student => new XElement("Student",
                                        new XAttribute("CourseId", student.CourseId),
                                        new XElement("StudentId", student.StudentId),
                                        new XElement("FirstName", student.FirstName),
                                        new XElement("LastName", student.LastName))));
            Console.WriteLine(xmlMethod.ToString());
         }

        static void XmlRead()
        {
            XDocument doc = XDocument.Load("sample.xml");


            var query = doc.Descendants("Students")
                                  .Descendants("Student")
                                  .Select(student => new {
                                      StudentId = student.Element("StudentId").Value,
                                      FirstName = student.Element("FirstName").Value,
                                      LastName = student.Element("LastName").Value,
                                      CourseId = student.Attribute("CourseId").Value
                                  });
            foreach (var item in query)
            {
                Console.WriteLine($"{item.StudentId} {item.FirstName} {item.LastName} {item.CourseId}");
            }
        }
        #endregion
    }

    class Test
    {
        public Test()
        {

        }
        public void Print()
        { }
        public void Read()
        { }
    }

    static class Extension
    {
        public static void ExtensionMethod(this Test test)
        {

        }
    }

}

namespace GMT.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.VisualBasic.FileIO;
    using System.IO;
    using GMT.Models;
    using System.Reflection;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<GMT.Models.StudentContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GMT.Models.StudentContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            Assembly assembly = Assembly.GetExecutingAssembly();
            string FileName = "GMT.Domain.student-mat.csv";

            List<Student> studentList = new List<Student>();
            using (TextFieldParser parser = new TextFieldParser(new StreamReader(assembly.GetManifestResourceStream(FileName))))
            {
                // use TextFiledParser due to the HasFIeldENclosedInQuotes option, which is quite convenient for various situations
                // In which a column of a csv file contains quotes inside a particular cell
                parser.HasFieldsEnclosedInQuotes = true;
                parser.SetDelimiters(";");
                string[] row;
                int studentId = 1;

                // Due to headers in csv file we will skip the first line
                parser.ReadLine();

                while (!parser.EndOfData)
                {
                    row = parser.ReadFields();

                    studentList.Add(new Student
                    {
                        Id = studentId,
                        School = row[0],
                        Sex = row[1],
                        Age = int.Parse(row[2]),
                        Address = row[3],
                        FamSize = row[4],
                        TravelTime = int.Parse(row[12]),
                        StudyTime = int.Parse(row[13]),
                        Failures = int.Parse(row[14]),
                        Higher = row[20],
                        Internet = row[21],
                        FreeTime = int.Parse(row[24]),
                        Absences = int.Parse(row[29]),
                        G1 = int.Parse(row[30]),
                        G2 = int.Parse(row[31]),
                        G3 = int.Parse(row[32])

                    });
                    studentId += 1;
                }
                // For each object in the studentList add each object to the database
                studentList.ForEach(s => context.Students.AddOrUpdate(s));
                context.SaveChanges();

            }
        }
    }
}

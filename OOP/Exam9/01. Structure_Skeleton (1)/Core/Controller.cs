using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories;
using UniversityCompetition.Repositories.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {
        private IRepository<IStudent> students;
        private IRepository<ISubject> subjects;
        private IRepository<IUniversity> universities;

        public Controller()
        {
            students = new StudentRepository();
            subjects = new SubjectRepository();
            universities= new UniversityRepository();
        }

        public string AddSubject(string subjectName, string subjectType)
        {
            ISubject subject = null;
            int id = subjects.Models.Count + 1;

            if (subjectType == "TechnicalSubject")
            {              
                subject = new TechnicalSubject(id, subjectName);
            }
            else if (subjectType == "EconomicalSubject")
            {
                subject = new EconomicalSubject(id, subjectName);

            }
            else if (subjectType == "HumanitySubject")
            {
                subject = new HumanitySubject(id, subjectName);

            }
            else
            {
                return String.Format(OutputMessages.SubjectTypeNotSupported, subjectType);
            }

            if (subjects.Models.Any(s => s.Name == subjectName))
            {
                return String.Format(OutputMessages.AlreadyAddedSubject, subjectName);

            }

            subjects.AddModel(subject);

            return String
                .Format(OutputMessages.SubjectAddedSuccessfully, subjectType, subjectName, subjects.GetType().Name);

        }


        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            IUniversity university = null;
            int id = universities.Models.Count + 1;


            if (universities.Models.Any(u => u.Name == universityName))
            {
                return String.Format(OutputMessages.AlreadyAddedUniversity, universityName);

            }

            List<int> ids = new List<int>();

            foreach (var subject in requiredSubjects)
            {
                var curSubject = subjects.FindByName(subject);
                ids.Add(curSubject.Id);
            }

            university = new University(id, universityName, category, capacity, ids);

            universities.AddModel(university);

            return String
                .Format(OutputMessages.UniversityAddedSuccessfully, universityName, universities.GetType().Name);

        }

        public string AddStudent(string firstName, string lastName)
        {
            IStudent student = null;

            int id = students.Models.Count + 1;


            string name = $"{firstName} {lastName}";

            if (students.FindByName(name) != null)
            {
                return String.Format(OutputMessages.AlreadyAddedStudent, firstName, lastName);
            }

            student = new Student(id, firstName, lastName);

            students.AddModel(student);

            return String.Format(OutputMessages.StudentAddedSuccessfully, firstName, lastName, students.GetType().Name);

        }

        public string TakeExam(int studentId, int subjectId)
        {
            var student = students.FindById(studentId);
            var subject = subjects.FindById(subjectId);


            if (student == null)
            {
                return String.Format(OutputMessages.InvalidStudentId);

            }

            if (subject == null)
            {
                return String.Format(OutputMessages.InvalidSubjectId);

            }

            if (student.CoveredExams.Contains(subjectId))
            {
                return String
           .Format(OutputMessages.StudentAlreadyCoveredThatExam, student.FirstName, student.LastName, subject.Name);

            }

            student.CoverExam(subject);

            return String
             .Format(OutputMessages.StudentSuccessfullyCoveredExam, student.FirstName, student.LastName, subject.Name);


        }


        public string ApplyToUniversity(string studentName, string universityName)
        {
            var student = students.FindByName(studentName);
            var university = universities.FindByName(universityName);

            string[] nameinfo = studentName.Split(" ");
            string firstName = nameinfo[0];
            string lastName = nameinfo[1];

            if (student == null)
            {
                return String.Format(OutputMessages.StudentNotRegitered, firstName, lastName);

            }

            if (university == null)
            {
                return String.Format(OutputMessages.UniversityNotRegitered, universityName);

            }

            foreach (var reqSub in university.RequiredSubjects)
            {
                if (!student.CoveredExams.Contains(reqSub))
                {
                    return String
                  .Format(OutputMessages.StudentHasToCoverExams, studentName, universityName);

                }
            }

            if (student.University == university)
            {
                return String
                  .Format(OutputMessages.StudentAlreadyJoined, firstName, lastName, universityName);
            }

            student.JoinUniversity(university);

            return String
                  .Format(OutputMessages.StudentSuccessfullyJoined, firstName, lastName, universityName);
        }

        

        public string UniversityReport(int universityId)
        {
            var university = universities.FindById(universityId);

            StringBuilder sb = new StringBuilder();

            var studentsList = students.Models.Where(s => s.University == university).ToList();

            int capacityLeft = university.Capacity - studentsList.Count;

            sb
                .AppendLine($"*** {university.Name} ***")
                .AppendLine($"Profile: {university.Category}")
                .AppendLine($"Students admitted: {studentsList.Count}")
                .AppendLine($"University vacancy: {capacityLeft}");

            return sb.ToString().Trim();

        }
    }
}

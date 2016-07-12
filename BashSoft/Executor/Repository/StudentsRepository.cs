using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Executor.Contracts;
using Executor.Exceptions;
using Executor.Models;
using Executor.IO;

namespace Executor.Repository
{
    public class StudentsRepository
    {
        private Dictionary<string, Course> courses;
        private Dictionary<string, Student> students;

        private bool isDataInitialized;

        private RepositioryFilter filter;
        private RepositorySorter sorter;

        public IReadOnlyDictionary<string, Course> Courses
        {
            get
            {
                return this.courses;
            }
        }

        public IReadOnlyDictionary<string, Student> Students
        {
            get
            {
                return this.students;
            }
        }

        public bool IsDataInitialized
        {
            get
            {
                return this.isDataInitialized;
            }
        }

        public StudentsRepository(RepositorySorter sorter, RepositioryFilter filter)
        {
            this.filter = filter;
            this.sorter = sorter;
        }

        public void LoadData(string fileName)
        {
            if (this.IsDataInitialized)
            {
                throw new ArgumentException(ExceptionMessages.DataAlreadyInitializedException);
            }

            this.students = new Dictionary<string, Student>();
            this.courses = new Dictionary<string, Course>();
            this.ReadData(fileName);
        }

        public void UnloadData()
        {
            if (!this.IsDataInitialized)
            {
                throw new ArgumentException(ExceptionMessages.DataNotInitializedExceptionMessage);
            }

            this.sorter = null;
            this.courses = null;
            this.isDataInitialized = false;
        }

        private void ReadData(string fileName)
        {
            string path = SessionData.currentPath + "\\" + fileName;
            if (File.Exists(path))
            {
                OutputWriter.WriteMessageOnNewLine("Reading data...");

                string pattern = @"([A-Z][a-zA-Z#\++]*_[A-Z][a-z]{2}_\d{4})\s+([A-Za-z]+\d{2}_\d{2,4})\s([\s0-9]+)";
                Regex rgx = new Regex(pattern);
                string[] allInputLines = File.ReadAllLines(path);

                for (int line = 0; line < allInputLines.Length; line++)
                {
                    if (!string.IsNullOrEmpty(allInputLines[line]) && rgx.IsMatch(allInputLines[line]))
                    {
                        Match currentMatch = rgx.Match(allInputLines[line]);
                        string courseName = currentMatch.Groups[1].Value;
                        string username = currentMatch.Groups[2].Value;
                        string scoresStr = currentMatch.Groups[3].Value;
                        try
                        {
                            int[] scores = scoresStr.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();

                            if (scores.Any(x => x > 100 || x < 0))
                            {
                                OutputWriter.DisplayException(ExceptionMessages.InvalidScore);
                                continue;
                            }

                            if (scores.Length > SoftUniCourse.NumberOfTasksOnExam)
                            {
                                OutputWriter.DisplayException(ExceptionMessages.InvalidNumberOfScores);
                                continue;
                            }

                            if (!this.Students.ContainsKey(username))
                            {
                                this.students.Add(username, new SoftUniStudent(username));
                            }

                            if (!this.Courses.ContainsKey(courseName))
                            {
                                this.courses.Add(courseName, new SoftUniCourse(courseName));
                            }

                            Course course = this.Courses[courseName];
                            Student student = this.Students[username];

                            student.EnrollInCourse(course);
                            student.SetMarkOnCourse(courseName, scores);

                            course.EnrollStudent(student);
                        }                  
                        catch (Exception ex)
                        {
                            OutputWriter.DisplayException(ex.Message + $"at line : {line}");}
                    }
                }

                this.isDataInitialized = true;
                OutputWriter.WriteMessageOnNewLine("Data read!");
            }
            else
            {
                throw new InvalidPathException();
            }
        }

        public void GetStudentScoresFromCourse(string courseName, string username)
        {
            if (this.IsQueryForStudentPossible(courseName, username))
            {
                string output = this.students[username].GetMarkForCourse(courseName);
                OutputWriter.WriteMessageOnNewLine(output);
            }
        }

        public void GetAllStudentsFromCourse(string courseName)
        {
            if (this.IsQueryForCoursePossible(courseName))
            {
                OutputWriter.WriteMessageOnNewLine($"{courseName}:");
                foreach (var studentMarksEntry in this.Courses[courseName].StudentByName)
                {
                    this.GetStudentScoresFromCourse(courseName, studentMarksEntry.Key);
                }
            }
        }

        public void OrderAndTake(string courseName, string comparison, int? studentsToTake = null)
        {
            if (this.IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = this.Courses[courseName].StudentByName.Count;
                }

                Dictionary<string, double> marks = this.Courses[courseName].StudentByName
                                                     .ToDictionary(x => x.Key, x => x.Value.MarksByCourseName[courseName]);

                this.sorter.OrderAndTake(marks, comparison, studentsToTake.Value);
            }
        }

        public void FilterAndTake(string courseName, string givenFilter, int? studentsToTake = null)
        {
            if (this.IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = this.Courses[courseName].StudentByName.Count;
                }

                Dictionary<string, double> marks = this.Courses[courseName].StudentByName
                                                    .ToDictionary(x => x.Key, x => x.Value.MarksByCourseName[courseName]);

                this.filter.FilterAndTake(marks, givenFilter, studentsToTake.Value);
            }
        }

        private bool IsQueryForCoursePossible(string courseName)
        {
            if (!this.IsDataInitialized)
            {
                throw new ArgumentNullException(nameof(this.isDataInitialized), ExceptionMessages.DataNotInitializedExceptionMessage);
            }

            if (!this.Courses.ContainsKey(courseName))
            {
                throw new NullReferenceException(ExceptionMessages.InexistingCourseInDataBase);
            }

            return true;
        }

        private bool IsQueryForStudentPossible(string courseName, string studentUserName)
        {
            if (!(this.IsQueryForCoursePossible(courseName) && this.Courses[courseName].StudentByName.ContainsKey(studentUserName)))
            {
                OutputWriter.DisplayException(ExceptionMessages.InexistingStudentInDataBase);
            }

            return true;
        }
    }
}


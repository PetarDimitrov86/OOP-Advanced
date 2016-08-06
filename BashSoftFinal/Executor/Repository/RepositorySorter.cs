using Executor.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using Executor.Contracts;

namespace Executor.Repository
{
    public class RepositorySorter : IDataSorter
    {                                                
        public void PrintSortedStudents(Dictionary<string, double> studentsMarks,
          string comparison, int studentsToTake)
        {
            comparison = comparison.ToLower();
            if (comparison == "ascending")
            {
                this.PrintStudents(studentsMarks.OrderBy(x => x.Value)
                                        .Take(studentsToTake)
                                        .ToDictionary(pair => pair.Key, pair => pair.Value));
            }
            else if (comparison == "descending")
            {
                this.PrintStudents(studentsMarks.OrderByDescending(x => x.Value)
                                        .Take(studentsToTake)
                                        .ToDictionary(pair => pair.Key, pair => pair.Value));
            }
            else
            {                            
                throw new ArgumentException(ExceptionMessages.InvalidComparisonQuery);
            }
        }
                                  
        private void PrintStudents(Dictionary<string, double> studentsSorted)
        {
            foreach (KeyValuePair<string, double> keyValuePair in studentsSorted)
            {
                OutputWriter.WriteMessageOnNewLine(string.Format($"{keyValuePair.Key} - {keyValuePair.Value}"));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Employee
{
    private string name;
    private int workHoursPerWeek;

    protected Employee(string name, int workHoursPerWeek)
    {
        this.Name = name;
        this.WorkHoursPerWeek = workHoursPerWeek;
    }

    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }

    public int WorkHoursPerWeek
    {
        get
        {
            return workHoursPerWeek;
        }

        set
        {
            workHoursPerWeek = value;
        }
    }
}

public class StandartEmployee : Employee
{
    private const int workHoursPerWeek = 40;

    public StandartEmployee(string name)
        : base(name, workHoursPerWeek)
    {
    }
}

public class PartTimeEmployee : Employee
{
    private const int workHoursPerWeek = 20;

    public PartTimeEmployee(string name)
        : base(name, workHoursPerWeek)
    {
    }
}

public delegate void JobUpdateHandler(object sender, JobDoneEventArgs e);

public class Job
{
    private string name;
    private int workHoursRequired;
    private Employee employee;

    public Job(string name, int workHoursRequired, Employee employee)
    {
        this.Name = name;
        this.WorkHoursRequired = workHoursRequired;
        this.Employee = employee;
    }

    public event JobUpdateHandler JobUpdate;

    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }

    public int WorkHoursRequired
    {
        get
        {
            return workHoursRequired;
        }

        set
        {
            workHoursRequired = value;
        }
    }

    public Employee Employee
    {
        get
        {
            return this.employee;
        }

        set
        {
            this.employee = value;
        }
    }

    public void Update()
    {
        this.WorkHoursRequired -= this.Employee.WorkHoursPerWeek;
        if (this.workHoursRequired <= 0)
        {
            Console.WriteLine("Job {0} done!", this.Name);
            this.OnJobUpdate(new JobDoneEventArgs(this));
        }
    }

    public void OnJobUpdate(JobDoneEventArgs e)
    {
        if (this.JobUpdate != null)
        {
            this.JobUpdate(this, e);
        }
    }

    public override string ToString()
    {
        return $"Job: {this.Name} Hours Remaining: {this.WorkHoursRequired}";
    }
}

public class JobDoneEventArgs : EventArgs
{
    private Job job;

    public JobDoneEventArgs(Job job)
    {
        this.Job = job;
    }

    public Job Job
    {
        get
        {
            return job;
        }

        set
        {
            job = value;
        }
    }
}

public class ModifiedList : List<Job>
{
    public void HandleJobCompletion(object sender, JobDoneEventArgs e)
    {
        this.Remove(e.Job);
    }
}

public class WorkForce
{
    static void Main(string[] args)
    {
        ModifiedList jobs = new ModifiedList();
        Dictionary<string, Employee> employeesByName = new Dictionary<string, Employee>();

        string input = Console.ReadLine();
        while (input != "End")
        {
            string[] inputArgs = input.Split();
            switch (inputArgs[0])
            {
                case "StandartEmployee":
                    var standartEmployee = new StandartEmployee(inputArgs[1]);
                    employeesByName[inputArgs[1]] = standartEmployee;
                    break;
                case "PartTimeEmployee":
                    var partTimeEmployee = new PartTimeEmployee(inputArgs[1]);
                    employeesByName[inputArgs[1]] = partTimeEmployee;
                    break;
                case "Job":
                    var employee = employeesByName[inputArgs[3]];
                    var job = new Job(inputArgs[1], int.Parse(inputArgs[2]), employee);
                    jobs.Add(job);
                    job.JobUpdate += jobs.HandleJobCompletion;
                    break;
                case "Pass":
                    
                    List<Job> jobsToUpdate = new List<Job>(jobs);
                    foreach (var jobToUpdate in jobsToUpdate)
                    {
                        jobToUpdate.Update();
                    }             
                    break;
                case "Status":
                    foreach (var jobNumberTwo in jobs)
                    {
                        Console.WriteLine(jobNumberTwo);
                    }
                    break;
            }
            input = Console.ReadLine();
        }
    }
}
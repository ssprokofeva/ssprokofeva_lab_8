using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ssprokofeva_lab_8
{
    internal class Project
    {
        public enum Status
        {
            Project,
            Execution,
            Closed
        }

        public Guid Id { get; private set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Person Initiator { get; set; }
        public Person TeamLead { get; set; }
        public List<Task> Tasks { get; private set; }
        public Status CurrentStatus { get; private set; }

        public Project(string description, DateTime startDate, DateTime endDate, Person initiator, Person teamLead)
        {
            Id = Guid.NewGuid();
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            Initiator = initiator;
            TeamLead = teamLead;
            Tasks = new List<Task>();
            CurrentStatus = Status.Project;
        }

        public void AddTask(Task task)
        {
            if (CurrentStatus != Status.Project)
                throw new InvalidOperationException("Нельзя добавить задачу, когда проект уже находится в стадии исполнения.");

            Tasks.Add(task);
        }

        public void SetExecutionStatus()
        {
            if (Tasks.Count == 0)
                throw new InvalidOperationException("Не возможно перевести проект в стадию исполнения, пока не созданы задачи.");

            CurrentStatus = Status.Execution;
        }

        public bool IsClosed()
        {
            return Tasks.All(t => t.CurrentStatus == Task.Status.Completed);
        }

        public void CloseProject()
        {
            if (!IsClosed())
                throw new InvalidOperationException("Не возможно закрыть проект, пока не выполнены все задачи.");

            CurrentStatus = Status.Closed;
        }
    }
}

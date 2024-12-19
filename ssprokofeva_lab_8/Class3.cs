using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ssprokofeva_lab_8
{
    internal class Task
    {
        public enum Status
        {
            Assigned,
            InProgress,
            OnReview,
            Completed
        }

        public Guid Id { get; private set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public Person Initiator { get; set; }
        public Person Executor { get; set; }
        public Status CurrentStatus { get; private set; }
        public List<Report> Reports { get; private set; }

        public Task(string description, DateTime deadline, Person initiator, Person executor)
        {
            Id = Guid.NewGuid();
            Description = description;
            Deadline = deadline;
            Initiator = initiator;
            Executor = executor;
            Reports = new List<Report>();
            CurrentStatus = Status.Assigned;
        }

        public void StartWork()
        {
            if (CurrentStatus != Status.Assigned)
                throw new InvalidOperationException("Нельзя начать работу над задачей, если она не назначена.");

            CurrentStatus = Status.InProgress;
        }

        public void DelegateTo(Person newExecutor)
        {
            if (CurrentStatus != Status.Assigned && CurrentStatus != Status.OnReview)
                throw new InvalidOperationException("Нельзя делегировать задачу, если она не назначена или находится на проверке.");

            Executor = newExecutor;
            CurrentStatus = Status.Assigned;
        }

        public void Reject()
        {
            if (CurrentStatus != Status.Assigned && CurrentStatus != Status.OnReview)
                throw new InvalidOperationException("Нельзя отклонить задачу, если она не назначена или находится на проверке.");

            Executor = null;
            CurrentStatus = Status.Assigned;
        }

        public void SubmitForReview(Report report)
        {
            if (CurrentStatus != Status.InProgress)
                throw new InvalidOperationException("Нельзя отправить задачу на проверку, если она не в процессе выполнения.");

            Reports.Add(report);
            CurrentStatus = Status.OnReview;
        }

        public void Approve()
        {
            if (CurrentStatus != Status.OnReview)
                throw new InvalidOperationException("Нельзя утвердить задачу, если она не на проверке.");

            CurrentStatus = Status.Completed;
        }

        public void ReturnForRevision()
        {
            if (CurrentStatus != Status.OnReview)
                throw new InvalidOperationException("Нельзя вернуть задачу на доработку, если она не на проверке.");

            CurrentStatus = Status.InProgress;
        }
    }
}

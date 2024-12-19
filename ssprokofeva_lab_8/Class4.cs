using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ssprokofeva_lab_8
{
    internal class Report
    {
        public Guid Id { get; private set; }
        public string Text { get; set; }
        public DateTime SubmissionDate { get; set; }
        public Person Submitter { get; set; }

        public Report(string text, DateTime submissionDate, Person submitter)
        {
            Id = Guid.NewGuid();
            Text = text;
            SubmissionDate = submissionDate;
            Submitter = submitter;
        }
    }
}

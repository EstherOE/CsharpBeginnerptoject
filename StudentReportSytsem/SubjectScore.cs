using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

public class SubjectScore
{
    public string Subjectd { get; set; }
    public double Score { get; set; }
    public SubjectScore(string subject, double score)
    {
        Subjectd = subject;
        Score = score;
    }
}
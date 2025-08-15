using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrolment
{
    record Enrolment(int StudentID, string CourseName, DateOnly DateEnrolled);
}

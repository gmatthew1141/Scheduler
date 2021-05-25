using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduler.Models {
    class Employee {
        public ObjectId _id { get; set; }
        public string Name { get; set; }
        public string JoinDate { get; set; }
        public Position EmployeePosition { get; set; }
        public Section EmployeeSection { get; set; }
        public ShiftType ShiftType { get; set; }
        public ExtraOff PH { get; set; }
        public ExtraOff AL { get; set; }
    }

    /// <summary>
    /// M   : Morning
    /// MD  : Middle
    /// C   : Closing
    /// OFF : Off
    /// S   : Sakit
    /// A   : Alpha
    /// I   : Ijin
    /// PH  : Public Holiday
    /// AL  : Annual Leave
    /// </summary>
    public enum ShiftType {
        M, MD, C, OFF, S, A, I, PH, AL
    }
}

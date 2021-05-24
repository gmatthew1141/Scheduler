using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduler.Models {
    class ExtraOff {
        public ExtraOffType Type { get; set; }
        public int Before { get; set; }
        public int Additional { get; set; }
        public int Taken { get; set; }
        public int Balance { get; set; }
    }

    public enum ExtraOffType {
        PH, AL
    }
}

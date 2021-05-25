using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduler.Models {
    class Section {

        public ObjectId _id;
        public string section { get; set; }
    }
}

using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduler.Models {
    class Position {

        public ObjectId _id { get; set; }
        public string position { get; set; }

    }
}

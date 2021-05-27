using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Diagnostics;
using MongoDB.Bson;

namespace Scheduler.Models {
    class Positions {

        public static ObservableCollection<Position> PositionList = new ObservableCollection<Position>();

        public static void AddPosition(string positionTitle) {
            Position pos = new Position {
                _id = ObjectId.GenerateNewId(),
                position = positionTitle
            };


            PositionList.Add(pos);

            // add position to database
            Database.AddPosition(pos);

            Debug.WriteLine("number of positions: " + PositionList.Count);
        }

        // Find the position in the PositionList
        public static Position GetPosition(string positionTitle) {
            Debug.WriteLine("Position title: " + positionTitle);
            foreach (var pos in PositionList) {
                if (pos.position.CompareTo(positionTitle) == 0) {
                    Debug.WriteLine("Found position with the title: " + positionTitle);
                    return pos;
                }
            }
            return null;
        }

        public static void RemovePosition(Position position) {

            // remove from database
            Database.RemovePositionFromDB(position._id);

            // remove position from the list
            PositionList.Remove(position);
        }
    }
}

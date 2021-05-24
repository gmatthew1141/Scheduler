using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Scheduler.Models {
    class Positions {

        public static ObservableCollection<Position> PositionList = new ObservableCollection<Position>();

        public static void AddPosition(string positionTitle) {
            Position pos = new Position {
                position = positionTitle
            };


            PositionList.Add(pos);

            Debug.WriteLine("number of positions: " + PositionList.Count);
        }

        
    }
}

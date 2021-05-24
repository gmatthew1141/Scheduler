using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Scheduler.Models {
    class Sections {

        public static ObservableCollection<Section> SectionList = new ObservableCollection<Section>();

        public static void AddSection(string sectionTitle) {
            Section sec = new Section {
                section = sectionTitle
            };


            SectionList.Add(sec);

            Debug.WriteLine("number of sections: " + SectionList.Count);
        }
    }
}

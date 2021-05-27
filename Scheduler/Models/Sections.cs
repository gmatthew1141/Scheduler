using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Diagnostics;
using MongoDB.Bson;

namespace Scheduler.Models {
    class Sections {

        public static ObservableCollection<Section> SectionList = new ObservableCollection<Section>();

        public static void AddSection(string sectionTitle) {
            Section sec = new Section {
                _id = ObjectId.GenerateNewId(),
                section = sectionTitle
            };


            SectionList.Add(sec);

            // save section to database
            Database.AddSection(sec);

            Debug.WriteLine("number of sections: " + SectionList.Count);
        }


        // Find the section in the SectionList
        public static Section GetSection(string sectionTitle) {
            Debug.WriteLine("Section title: " + sectionTitle);
            foreach (var sec in SectionList) {
                if (sec.section.CompareTo(sectionTitle) == 0) {
                    Debug.WriteLine("Found section with the title: " + sectionTitle);
                    return sec;
                }
            }
            return null;
        }

        public static void RemoveSection(Section section) {

            // Remove section from database
            Database.RemoveSectionFromDB(section._id);

            // Remove section from list
            SectionList.Remove(section);


        }
    }
}

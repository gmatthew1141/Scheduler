using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.ObjectModel;
using MongoDB.Bson.Serialization;

namespace Scheduler.Models {
    class Database {
        
        private static MongoClient dbClient = new MongoClient("mongodb+srv://Admin:fogoadmin@maincluster.ofdoz.mongodb.net/Test?retryWrites=true&w=majority");

        private static IMongoDatabase database = dbClient.GetDatabase("database");

        public static void TestDB() {
            //MongoClient dbClient = new MongoClient("mongodb+srv://Admin:fogoadmin@maincluster.ofdoz.mongodb.net/Test?retryWrites=true&w=majority");

            var dbList = dbClient.ListDatabases().ToList();

            var database = dbClient.GetDatabase("Test");
            var collection = database.GetCollection<BsonDocument>("TestCol");

            var document = new BsonDocument { { "student_id", 10000 }, {
                "scores",
                new BsonArray {
                new BsonDocument { { "type", "exam" }, { "score", 88.12334193287023 } },
                new BsonDocument { { "type", "quiz" }, { "score", 74.92381029342834 } },
                new BsonDocument { { "type", "homework" }, { "score", 89.97929384290324 } },
                new BsonDocument { { "type", "homework" }, { "score", 82.12931030513218 } }
                }
                }, { "class_id", 480 }
            };

            collection.InsertOne(document);

            //Debug.WriteLine("The list of databases on this server is: ");
            //foreach (var db in dbList) {
            //    Debug.WriteLine(db);
            //}
        }

        public static void AddEmployee(Employee employee) {
            var employeeBson = employee.ToBsonDocument();
            
            //MongoClient dbClient = new MongoClient("mongodb+srv://Admin:fogoadmin@maincluster.ofdoz.mongodb.net/Test?retryWrites=true&w=majority");
            
            //var database = dbClient.GetDatabase("database");
            var collection = database.GetCollection<BsonDocument>("employees");
            collection.InsertOne(employeeBson);
        }

        public static void AddPosition(Position position) {

            var positionBson = position.ToBsonDocument();

            //MongoClient dbClient = new MongoClient("mongodb+srv://Admin:fogoadmin@maincluster.ofdoz.mongodb.net/Test?retryWrites=true&w=majority");

            //var database = dbClient.GetDatabase("database");
            var collection = database.GetCollection<BsonDocument>("positions");
            collection.InsertOne(positionBson);
        }

        public static void AddSection(Section section) {

            var sectionBson = section.ToBsonDocument();

            //MongoClient dbClient = new MongoClient("mongodb+srv://Admin:fogoadmin@maincluster.ofdoz.mongodb.net/Test?retryWrites=true&w=majority");

            //var database = dbClient.GetDatabase("database");
            var collection = database.GetCollection<BsonDocument>("sections");
            collection.InsertOne(sectionBson);
        }

        public static ObservableCollection<Employee> GetEmployeesFromDB() {

            var collection = database.GetCollection<BsonDocument>("employees");

            var documents = collection.Find(new BsonDocument()).ToList();

            ObservableCollection<Employee> output = new ObservableCollection<Employee>();

            foreach (var doc in documents) {
                //Debug.WriteLine("doc: " + doc);
                //Debug.WriteLine("after deserialization: " + BsonSerializer.Deserialize<Position>(doc));

                output.Add(BsonSerializer.Deserialize<Employee>(doc));
            }

            return output;
        }

        public static ObservableCollection<Position> GetPositionsFromDB() {

            var collection = database.GetCollection<BsonDocument>("positions");

            var documents = collection.Find(new BsonDocument()).ToList();

            ObservableCollection<Position> output = new ObservableCollection<Position>();

            foreach (var doc in documents) {
                //Debug.WriteLine("doc: " + doc);
                //Debug.WriteLine("after deserialization: " + BsonSerializer.Deserialize<Position>(doc));

                output.Add(BsonSerializer.Deserialize<Position>(doc));
            }

            return output;
        }

        public static ObservableCollection<Section> GetSectionsFromDB() {

            var collection = database.GetCollection<BsonDocument>("sections");

            var documents = collection.Find(new BsonDocument()).ToList();

            ObservableCollection<Section> output = new ObservableCollection<Section>();

            foreach (var doc in documents) {
                //Debug.WriteLine("doc: " + doc);
                //Debug.WriteLine("after deserialization: " + BsonSerializer.Deserialize<Position>(doc));

                output.Add(BsonSerializer.Deserialize<Section>(doc));
            }

            return output;
        }


        public static void RemoveEmployeeFromDB(ObjectId employeeId) {
            var collection = database.GetCollection<BsonDocument>("employees");

            var deleteFilter = Builders<BsonDocument>.Filter.Eq("_id", employeeId);

            collection.DeleteOne(deleteFilter);

        }

        public static void RemovePositionFromDB(ObjectId positionId) {
            var collection = database.GetCollection<BsonDocument>("positions");

            var deleteFilter = Builders<BsonDocument>.Filter.Eq("_id", positionId);

            collection.DeleteOne(deleteFilter);
        }

        public static void RemoveSectionFromDB(ObjectId sectionId) {
            var collection = database.GetCollection<BsonDocument>("sections");

            var deleteFilter = Builders<BsonDocument>.Filter.Eq("_id", sectionId);

            collection.DeleteOne(deleteFilter);
        }


    }
}

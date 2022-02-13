﻿using CloudKit;
using Foundation;
using UIKit;

namespace XamarinCloudTest.iOS
{
    public class DataService : IDataService
    {
        public AppDelegate ThisApp => (AppDelegate)UIApplication.SharedApplication.Delegate;

        private const string ReferenceItemRecordName = "ReferenceItems";

        public void SaveRecord(string name)
        {
            // Create a new record
            var newRecord = new CKRecord(ReferenceItemRecordName);
            newRecord["name"] = (NSString)name;

            // Save it to the database
            ThisApp.PublicDatabase.SaveRecord(newRecord, (record, err) => {
                // Was there an error?
                if (err != null) {
                }
            });
        }

        public void FetchRecord(string myRecordName)
        {
            // Create a record ID and fetch the record from the database
            var recordID = new CKRecordID(myRecordName);
            ThisApp.PublicDatabase.FetchRecord(recordID, (record, err) => {
                // Was there an error?
                if (err != null) {
                }
            });
        }

        public void UpdateRecord(string myRecordName, string newName)
        {
            // Create a record ID and fetch the record from the database
            var recordID = new CKRecordID(myRecordName);
            ThisApp.PublicDatabase.FetchRecord(recordID, (record, err) => {
                // Was there an error?
                if (err != null) {

                }
                else {
                    // Modify the record
                    record["name"] = (NSString)newName;

                    // Save changes to database
                    ThisApp.PublicDatabase.SaveRecord(record, (r, e) => {
                        // Was there an error?
                        if (e != null) {
                        }
                    });
                }
            });
        }

        public void DeleteRecord(string myRecordName)
        {

        }
    }
}

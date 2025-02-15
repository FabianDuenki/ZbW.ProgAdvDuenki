using System;
using System.ComponentModel;

namespace Validation {
    public class MySource : IDataErrorInfo {
        public string Name { get; set; }
        public double Age { get; set; }



        #region IDataErrorInfo Members

        // Error für Objekt
        public string Error => "";

        // Error für bestimmtes Property
        public string this[string columnName] {
            get {
                switch (columnName) {
                    case "Age":
                        if (Name == "Thomas" && Age < 34) {
                            return "nicht gut ...";
                        }

                        break;


                    case "Name":
                        break;


                    default:
                        throw new ArgumentException("Unknown property: " + columnName, nameof(columnName));
                }

                return "";
            }
        }

        #endregion
    }
}
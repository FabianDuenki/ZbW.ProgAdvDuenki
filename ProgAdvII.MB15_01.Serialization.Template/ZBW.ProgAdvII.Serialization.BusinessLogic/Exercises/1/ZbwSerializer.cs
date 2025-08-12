using PeterO.Cbor;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace ZBW.ProgAdvII.Serialization.BusinessLogic.Exercises._1 {
    public class ZbwSerializer : ISerializer {
        public void Serialize(Student student, Stream stream) {
            var cbor = CBORObject.NewMap()
                .Add("FirstName", student.FirstName)
                .Add("LastName", student.LastName)
                .Add("DateOfBirth", student.DateOfBirth.ToLocalTime());
            byte[] buffer = cbor.EncodeToBytes();

            var fileStream = File.Open("student.dat", FileMode.Create);
            fileStream.Write(buffer);
            fileStream.Close();
        }

        public Student Deserialize(Stream stream)
        {
            var cbor = CBORObject.DecodeFromBytes(
                File.ReadAllBytes("student.dat"), CBOREncodeOptions.Default);

            var student = new Student();
            return student;
        }
    }
}
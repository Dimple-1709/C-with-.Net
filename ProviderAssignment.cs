using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace ProviderAssgnment
{
    class Program
    {
        static void Main(string[] args)
        {
            Client objclient = new Client();
            objclient.Query();
            Console.Read();
        }
    }

    public static class UtilityExtensions
    {
        public static string Dump(this PatientInfo info)
        {
            return ($"{info.MRN},{info.Name},{info.Age},{info.ContactNumber},{info.Email}");
        }
    }

    public class PatientInfo
    {
        //constructor
        public PatientInfo(string mrn)
        {
            this.mrn = mrn;
        }
        //Backing Field - Memory
        private string mrn;
        //Public Property
        public string MRN { get { return this.mrn; } }


        //Auto implemented Properties
        public string Name { get; set; }
        public int Age { get; set; }
        public string ContactNumber { get; set; }

        //Public Field
        public string Email;

    }


    public class PatientCSVProvider
    {
        public string FilePath { get; set; }
        public List<PatientInfo> GetAllPatients()
        {

            var csvdata = File.ReadAllLines(FilePath);

            var query = new List<PatientInfo>(from eachline in csvdata
                                                            let data = eachline.Split(',')
                                                            select new PatientInfo(data[0])
                                                            {
                                                                Name = data[1],
                                                                Age = Convert.ToInt32(data[2]),
                                                                ContactNumber = data[3],
                                                                Email = data[4]
                                                            });
            return query;
        }
    }

    public class Client
    {
        public void Query()
        {
            PatientCSVProvider provider = new PatientCSVProvider();
            provider.FilePath = @"C:\Users\320190556\C#with.Net\patients.csv";
            IEnumerable<PatientInfo> patients = provider.GetAllPatients();
            IEnumerable<PatientInfo> result = patients.Where(p => p.Age > 30);
            foreach (PatientInfo patient in result)
            {
                Console.WriteLine(patient.Dump());
            }
        }
    }
}

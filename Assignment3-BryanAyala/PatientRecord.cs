using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Assignment3_BryanAyala
{
    internal class PatientRecord
    {
        public string patientPath {  get; set; }
        public string patientName { get; set; }

        //string[,] myStrings = new string[20, 2];

       public List<PatientRecord> myPatients = new List<PatientRecord>();
       
        public PatientRecord() { }

        public PatientRecord(string patientPath, string patientName)
        {
            this.patientPath = patientPath;
            this.patientName = patientName;

          /*  int nullIndex = -1;
            for (int i = 0; i < myStrings.GetLength(0); i++)
            {
                if (myStrings[i, 0] == null)
                {
                    nullIndex = i;
                    break;
                }
            }
          */
           

        }

        public void AddPatient(PatientRecord record)
        {
            myPatients.Add(record);
        }

        public string[] GetFields( string file)
        {
            string[] fields = null;
            var selectedItem = myPatients.Where(x => x.patientName == file).FirstOrDefault();
            if (selectedItem != null)
            {
                using (StreamReader reader = new StreamReader(selectedItem.patientPath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        fields = line.Split('|');
                        
                    }
                }
               
            }
            
            if (fields[4].Contains("%%"))
            {
                fields[4] = fields[4].Replace("%%", "\n");
            }
            string[] problems = null;
            string problemRegex = @"[a-zA-Z][1,];;$";

            if (Regex.IsMatch(fields[3], problemRegex))
            {
                int lastIndex = fields[3].LastIndexOf(";;");
                if (lastIndex != -1)
                {
                    fields[3] = fields[3].Substring(0, lastIndex) + fields[3].Substring(lastIndex + 2);
                }

            }
            if (fields[3].Contains(";;"))
            {


                problems = fields[3].Split(";;", StringSplitOptions.RemoveEmptyEntries);

                fields[3] = fields[4];
                Array.Resize(ref fields, fields.Length + problems.Length - 1);
                for (int i = 0; i < problems.Length; i++)
                {
                    fields[fields.Length - problems.Length + i ] = problems[i];
                }
            }
            else
            {
                string toEnd = fields[3];
                fields[3] = fields[4];
                fields[4] = toEnd;
            }
           

            /*for (int i=0;i<fields.Length; i++)
            {
                if (fields[i] ==" ")
                {
                    fields[i]="";
                }
            }*/

            return fields;
        }

        public string getData(string file )
        {
            var selectedItem = myPatients.Where(x => x.patientName == file).FirstOrDefault();

            return selectedItem.patientPath;
        }

        public void deletePatient(string file)
        {
            var selectedItem = myPatients.Where(x => x.patientName == file).FirstOrDefault();
            myPatients.Remove(selectedItem);
        }

        public void changeData(string oldPath, string newPath, string newName)
        {
            var selectedItem = myPatients.Where(x => x.patientPath == oldPath).FirstOrDefault();

            selectedItem.patientPath = newPath;
            selectedItem.patientName=newName;
        }
    }
}

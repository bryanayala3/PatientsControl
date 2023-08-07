using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using static System.Windows.Forms.LinkLabel;

namespace Assignment3_BryanAyala
{
    public class Vitals
    {
        public string VitalTest { get; set; }
        public int Id { get; set; }

        private List<Vitals> vitalList = new List<Vitals>();

        public Vitals(string vitalTest, int id)
        {
            this.VitalTest = vitalTest;
            this.Id = id;

           

        }
        public Vitals() { }

        public int CheckVitals(int id, string nameVital)
        {
            var validation = vitalList.Where(x => x.Id == id).FirstOrDefault();
            int existItem = 0;

            if (validation != null)
            {
                validation=vitalList.Where(x=>x.VitalTest==nameVital).FirstOrDefault();
                if (validation != null)
                {
                    existItem = 1;
                }
                else
                {
                    existItem = 0;
                }
            }
            else
            {

                existItem= -1;
            }
            return existItem;
        }

        public void AddVital(Vitals vital)
        {
            vitalList.Add(vital);
        }

        public void EditVital(int id, string nameVital)
        {
            var validation = vitalList.Where(x => x.Id == id).FirstOrDefault();
            if (validation != null)
            {
                vitalList.Remove(validation);

                Vitals vitalsEdited = new Vitals(nameVital, id);

               AddVital(vitalsEdited);


                

            }
            
        }
        string vitalsDisplayed;
        public String DisplayVitals()
        {
            vitalsDisplayed = "";
            foreach(var vital in vitalList)
            {
                vitalsDisplayed += vital.VitalTest.ToString() + "\n";
            }

            return vitalsDisplayed;
        }

        public void DeleteBP(params string[] lines)
        {
            foreach (var vital in vitalList.ToList())
            {
                bool isThereB = false;
                if (vital.Id == 1 || vital.Id == 2 || vital.Id == 3)
                {
                    string value = vital.VitalTest;
                    Match bpMatch = Regex.Match(value, @"\d{2,3}/\d{2,3}"); // Match the blood pressure value using a more specific pattern
                    string bpValue = bpMatch.Value; // Extract the matched value from the Match object
                    Regex bpRegex = new Regex($"BP[:]? {Regex.Escape(bpValue)}"); // Create a new regex pattern using the extracted value


                    foreach (var line in lines)
                    {
                        Match bpIsthere = bpRegex.Match(line);
                        // Match hrIsthere = hrRegex.Match(line);
                        if (bpIsthere.Success)
                        {
                            isThereB = true;
                        }
                       
                    }
                    if (!isThereB)
                    {
                        vitalList.Remove(vital);
                        break;
                    }
                }
            }
        }

        public void DeleteHR(params string[] lines)
        {
            foreach (var vital in vitalList.ToList())
            {
                bool isThereH = false;
                if (vital.Id == 4 || vital.Id == 5 || vital.Id == 6)
                {
                    string value = vital.VitalTest;
                    Match hrMatch = Regex.Match(value, @"\d{2,3}");
                    string hrValue = hrMatch.Value;
                    Regex hrRegex = new Regex($"HR:? {Regex.Escape(hrValue)}");


                    foreach (var line in lines)
                    {
                        Match hrIsthere = hrRegex.Match(line);
                        if (hrIsthere.Success)
                        {
                            isThereH = true;
                        }

                    }
                    if (!isThereH)
                    {
                        vitalList.Remove(vital);
                        break;
                    }
                }

            }

        }

        public void DeleteRR(params string[] lines)
        {
            foreach (var vital in vitalList)
            {
                bool isThereR = false;
                if (vital.Id == 7 || vital.Id == 8 || vital.Id == 9)
                {
                    string value = vital.VitalTest;
                    Match rrMatch = Regex.Match(value, @"\d{1,2}");
                    string rrValue = rrMatch.Value;
                    Regex rrRegex = new Regex($"RR:? {Regex.Escape(rrValue)}");


                    foreach (var line in lines)
                    {
                        Match rrIsthere = rrRegex.Match(line);
                        if (rrIsthere.Success)
                        {
                            isThereR = true;
                        }

                    }
                    if (!isThereR)
                    {
                        vitalList.Remove(vital);
                        break;
                    }
                }
            }

        }

        public void DeleteT(params string[] lines)
        {
            foreach (var vital in vitalList)
            {
                bool isThereT = false;
                if (vital.Id == 10 || vital.Id == 11 || vital.Id == 12)
                {


                    string value = vital.VitalTest;
                    Match tMatch = Regex.Match(value, @"\d{2}\.\d");
                    string tValue = tMatch.Value;
                    Regex tRegex = new Regex($"T:? {Regex.Escape(tValue)}");


                    foreach (var line in lines)
                    {
                        Match tIsthere = tRegex.Match(line);
                        if (tIsthere.Success)
                        {
                            isThereT = true;
                        }

                    }
                    if (!isThereT)
                    {
                        vitalList.Remove(vital);
                        break;
                    }
                }
            }

        }
    }
}

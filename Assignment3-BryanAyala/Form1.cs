using System.Reflection.Emit;
using System.Text.RegularExpressions;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using System.Windows.Input;
using System.Globalization;

namespace Assignment3_BryanAyala
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            idBox.Enabled = false;
            patientName.Enabled = false;
            birthDate.Enabled = false;
            newProblem.Enabled = false;
            addProblemBttn.Enabled = false;
            noteRichBox.Enabled = false;
            addNoteBttn.Enabled = false;
            updateBttn.Enabled = false;
            deleteBttn.Enabled = false;
        }
        //General Variables:
        int noteID = 0;
        int fileCount = 0;
        string newPath;
        string name;
        DateTime birth;
        string notePad;
        string idPatient;
        string problemPatient;
        string vitalPatient;
        Vitals newVital;
        Vitals methodsVital = new Vitals();
        PatientRecord methodsPatient = new PatientRecord();
        PatientRecord newPatient;


        private void Form1_Load(object sender, EventArgs e)
        {
            newPath = "C:\\BryanAyala\\notesAssignmentBryanA";
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }

            string filePath = Path.Combine(newPath, $"Example Note (Note 1).txt");

            if (!File.Exists(filePath))
            {

                using (StreamWriter sw = File.CreateText(filePath))
                {
                    sw.WriteLine("1|Example Note|2/26/1996 12:00:00 AM|Overweight|Generla Appereance well developed, well nourished, no acute distress%%Skin: clear, good tugor, color WNL, no rashes,l lesions or ulcerations%%%%BP: 134/89%%%%Lying down BP: 130/85%%%%HR: 44%%%%HR: 101");

                }
            }
            var fileNames = Directory.GetFiles(newPath).OrderBy(f => int.Parse(Path.GetFileNameWithoutExtension(f).Split(new string[] { "(Note ", ")" }, StringSplitOptions.RemoveEmptyEntries)[1]));

            foreach (string fileName in fileNames)
            {
                noteBox.Items.Add(Path.GetFileNameWithoutExtension(fileName));

                newPatient = new PatientRecord(fileName, Path.GetFileNameWithoutExtension(fileName));

                methodsPatient.AddPatient(newPatient);



            }

            notificationLabel.ForeColor = Color.Red;

        }


        private void startBttn_Click(object sender, EventArgs e)
        {
            noteRichBox.Enabled = true;
            patientName.Enabled = true;
            birthDate.Enabled = true;
            newProblem.Enabled = true;
            addProblemBttn.Enabled = true;
            addNoteBttn.Enabled = true;
            noteBox.SelectedIndex = -1;

            fileCount = Directory.GetFiles(newPath).Length;
            noteID = fileCount + 1;
            idBox.Text = noteID.ToString();
            patientName.Text = "";
            birthDate.Value = DateTime.Now;
            newProblem.Text = "";
            noteRichBox.Clear();
            problemListBox.Items.Clear();
            vitalRichBox.Clear();




        }


        private void noteRichBox_TextChanged(object sender, EventArgs e)
        {

            {

                Regex bpRegex = new Regex(@"BP[\:]? (\d{2,3}/\d{2,3})");
                Regex hrRegex = new Regex(@"HR[\:]? (\d{2,3})");
                Regex rrRegex = new Regex(@"RR[\:]? (\d{1,2})");
                Regex tRegex = new Regex(@"T[\:]? (\d{2}\.\d)");

                int checking = 3;
                // Loop through each line 
                foreach (string line in noteRichBox.Lines)
                {

                    Match bpMatch = bpRegex.Match(line);
                    Match hrMatch = hrRegex.Match(line);
                    Match rrMatch = rrRegex.Match(line);
                    Match tMatch = tRegex.Match(line);
                    int id = 0;


                    // If the line matches the BP regex, analyze the value
                    if (bpMatch.Success)
                    {
                        string bpValue = bpMatch.Groups[1].Value;
                        string bpLabel = "BP: " + bpValue + " mmHg";
                        string[] bpParts = bpValue.Split('/');
                        int systolic = int.Parse(bpParts[0]);
                        int diastolic = int.Parse(bpParts[1]);

                        if (systolic >= 140 || diastolic >= 90)
                        {
                            bpLabel = bpLabel + " (High)";
                            id = 1;
                        }
                        else if (systolic <= 90 || diastolic <= 60)
                        {
                            bpLabel = bpLabel + " (Low)";
                            id = 2;
                        }
                        else
                        {
                            id = 3;
                        }

                        checking = methodsVital.CheckVitals(id, bpLabel);

                        if (checking == 0)
                        {
                            methodsVital.EditVital(id, bpLabel);
                        }
                        else if (checking == -1 && id != 0)
                        {
                            newVital = new Vitals(bpLabel, id);
                            methodsVital.AddVital(newVital);
                        }


                    }

                    // If the line matches the HR regex, analyze the value
                    if (hrMatch.Success)
                    {
                        int hrValue = int.Parse(hrMatch.Groups[1].Value);
                        string hrLabel = "HR: " + hrValue + " bpm";

                        if (hrValue >= 100)
                        {
                            hrLabel += " (High)";
                            id = 4;
                        }
                        else if (hrValue <= 60 && hrValue > 10)
                        {
                            hrLabel += " (Low)";
                            id = 5;
                        }
                        else if (hrValue > 60 && hrValue < 100)
                        {
                            id = 6;
                        }

                        checking = methodsVital.CheckVitals(id, hrLabel);

                        if (checking == 0)
                        {
                            methodsVital.EditVital(id, hrLabel);
                        }
                        else if (checking == -1 && id != 0)
                        {
                            newVital = new Vitals(hrLabel, id);
                            methodsVital.AddVital(newVital);
                        }

                    }

                    if (rrMatch.Success)
                    {
                        int rrValue = int.Parse(rrMatch.Groups[1].Value);
                        string rrLabel = "RR: " + rrValue + " breaths pm";

                        if (rrValue >= 17)
                        {
                            rrLabel += " (High)";
                            id = 7;
                        }
                        else if (rrValue <= 11 && rrValue > 1)
                        {
                            rrLabel += " (Low)";
                            id = 8;
                        }
                        else if (rrValue > 11 && rrValue < 17)
                        {
                            id = 9;
                        }

                        checking = methodsVital.CheckVitals(id, rrLabel);

                        if (checking == 0)
                        {
                            methodsVital.EditVital(id, rrLabel);
                        }
                        else if (checking == -1 && id != 0)
                        {
                            newVital = new Vitals(rrLabel, id);
                            methodsVital.AddVital(newVital);
                        }

                    }

                    if (tMatch.Success)
                    {
                        double tValue = Convert.ToDouble(tMatch.Groups[1].Value);
                        string tLabel = "T: " + tValue + " °C";

                        if (tValue >= 37.3)
                        {
                            tLabel += " (High)";
                            id = 10;
                        }
                        else if (tValue <= 36.4)
                        {
                            tLabel += " (Low)";
                            id = 11;
                        }
                        else if (tValue > 36.4 && tValue < 37.3)
                        {
                            id = 12;
                        }

                        checking = methodsVital.CheckVitals(id, tLabel);

                        if (checking == 0)
                        {
                            methodsVital.EditVital(id, tLabel);
                        }
                        else if (checking == -1 && id != 0)
                        {
                            newVital = new Vitals(tLabel, id);
                            methodsVital.AddVital(newVital);
                        }

                    }
                }

                string[] allLines = noteRichBox.Lines;
                methodsVital.DeleteBP(allLines);
                methodsVital.DeleteHR(allLines);
                methodsVital.DeleteRR(allLines);
                methodsVital.DeleteT(allLines);




                vitalRichBox.Text = "";
                vitalRichBox.Text = methodsVital.DisplayVitals();


            }
        }

        private void addProblemBttn_Click(object sender, EventArgs e)
        {
            string problem = newProblem.Text;
            if (problem.Length > 0)
            {
                problemListBox.Items.Add(problem);
                newProblem.Clear();
            }
            else
            {
                notificationLabel.Text += "Please fill problem input";
                newProblem.Focus();
            }
        }

        private void removeProblemBttn_Click(object sender, EventArgs e)
        {
            if (problemListBox.SelectedItem != null)
            {
                problemListBox.Items.Remove(problemListBox.SelectedItem);
            }
            else { notificationLabel.Text += "Please select any item to remove"; }
        }


        private void addNoteBttn_Click(object sender, EventArgs e)
        {
            idPatient = idBox.Text;
            name = patientName.Text;
            birth = birthDate.Value.Date;
            notePad = noteRichBox.Text;
            problemPatient = "";


            foreach (var item in problemListBox.Items)
            {
                problemPatient += item.ToString() + ";;";
            }
            notePad = notePad.Replace("\n", "%%");
            notePad = notePad.Replace(Environment.NewLine, "");

            if (name.Length > 0)
            {
                if (birth <= DateTime.Now.Date)
                {
                    if (problemPatient.Length == 0)
                    {
                        problemPatient = " ";

                    }
                    if (notePad.Length > 0)
                    {


                        string filePath = Path.Combine(newPath, $"{name} (Note {idPatient}).txt");

                        if (!File.Exists(filePath))
                        {

                            using (StreamWriter sw = File.CreateText(filePath))
                            {
                                sw.WriteLine($"{idPatient}|{name}|{birth}|{problemPatient}|{notePad}");

                            }

                            newPatient = new PatientRecord(filePath, $"{name} (Note {idPatient})");

                            methodsPatient.AddPatient(newPatient);
                        }
                        var fileNames = Directory.GetFiles(newPath).OrderBy(f => int.Parse(Path.GetFileNameWithoutExtension(f).Split(new string[] { "(Note ", ")" }, StringSplitOptions.RemoveEmptyEntries)[1]));
                        noteBox.Items.Clear();
                        foreach (string fileName in fileNames)
                        {
                            noteBox.Items.Add(Path.GetFileNameWithoutExtension(fileName));
                        }
                    }
                    else
                    {
                        notificationLabel.Text += "Please Enter the clinical note \n";
                        noteRichBox.Focus();
                    }




                }
                else
                {
                    notificationLabel.Text += "Please Enter a valid date of birth \n";
                    birthDate.Focus();
                }
            }
            else
            {
                notificationLabel.Text += "Please Enter the patient Name \n";
                patientName.Focus();
            }


            if (notificationLabel.Text == "")
            {
                idBox.Clear();
                patientName.Clear();
                birthDate.Value = DateTime.Now.Date;
                newProblem.Clear();
                problemListBox.Items.Clear();
                vitalRichBox.Clear();
                noteRichBox.Clear();

                idBox.Enabled = false;
                patientName.Enabled = false;
                birthDate.Enabled = false;
                newProblem.Enabled = false;
                addProblemBttn.Enabled = false;
                noteRichBox.Enabled = false;
                addNoteBttn.Enabled = false;
                updateBttn.Enabled = false;
                deleteBttn.Enabled = false;
            }
        }

        private void noteBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            notificationLabel.Text = "";
            problemListBox.Items.Clear();
            if (noteBox.SelectedIndex != -1)
            {
                string itemFile = noteBox.SelectedItem.ToString();



                string[] myElemtens = methodsPatient.GetFields(itemFile);

                //System.Windows.Forms.MessageBox.Show(methodsPatient.getData(itemFile));
                noteRichBox.Enabled = true;
                patientName.Enabled = true;
                birthDate.Enabled = true;
                newProblem.Enabled = true;
                addProblemBttn.Enabled = true;
                addNoteBttn.Enabled = false;
                updateBttn.Enabled = true;
                deleteBttn.Enabled = true;


                idBox.Text = myElemtens[0];
                patientName.Text = myElemtens[1];
                birthDate.Value = DateTime.ParseExact(myElemtens[2], "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                noteRichBox.Text = myElemtens[3];
                for (int i = 4; i < myElemtens.Length; i++)
                {
                    problemListBox.Items.Add(myElemtens[i]);
                }
            }
            else
            {
                notificationLabel.Text += "Please select one of the files to display";
            }
        }

        private void updateBttn_Click(object sender, EventArgs e)
        {
            idPatient = idBox.Text;
            name = patientName.Text;
            birth = birthDate.Value.Date;
            notePad = noteRichBox.Text;
            problemPatient = "";

            if (noteBox.SelectedIndex != -1)
            {
                string itemFile = noteBox.SelectedItem.ToString();

                foreach (var item in problemListBox.Items)
                {
                    problemPatient += item.ToString() + ";;";
                }
                notePad = notePad.Replace("\n", "%%");
                notePad = notePad.Replace(Environment.NewLine, "");

                if (name.Length > 0)
                {
                    if (birth <= DateTime.Now.Date)
                    {
                        if (problemPatient.Length == 0)
                        {
                            problemPatient = " ";

                        }
                        if (notePad.Length > 0)
                        {


                            string filePath = methodsPatient.getData(itemFile);

                            if (File.Exists(filePath))
                            {

                                using (StreamWriter sw = File.CreateText(filePath))
                                {
                                    sw.WriteLine($"{idPatient}|{name}|{birth}|{problemPatient}|{notePad}");

                                }


                            }

                        }
                        else
                        {
                            notificationLabel.Text += "Please Enter the clinical note \n";
                            noteRichBox.Focus();
                        }




                    }
                    else
                    {
                        notificationLabel.Text += "Please Enter a valid date of birth \n";
                        birthDate.Focus();
                    }
                }
                else
                {
                    notificationLabel.Text += "Please Enter the patient Name \n";
                    patientName.Focus();
                }


                if (notificationLabel.Text == "")
                {
                    idBox.Clear();
                    patientName.Clear();
                    birthDate.Value = DateTime.Now.Date;
                    newProblem.Clear();
                    problemListBox.Items.Clear();
                    vitalRichBox.Text = "";
                    noteRichBox.Clear();

                    idBox.Enabled = false;
                    patientName.Enabled = false;
                    birthDate.Enabled = false;
                    newProblem.Enabled = false;
                    addProblemBttn.Enabled = false;
                    noteRichBox.Enabled = false;
                    addNoteBttn.Enabled = false;
                    updateBttn.Enabled = false;
                    deleteBttn.Enabled = false;
                    noteBox.SelectedIndex = -1;
                }
            }
        }

        private void deleteBttn_Click(object sender, EventArgs e)
        {
            notificationLabel.Text = "";
            int items =noteBox.Items.Count;
            if(noteBox.SelectedIndex != 0)
            {
                string itemFile= noteBox.SelectedItem.ToString();

                string filePath = methodsPatient.getData(itemFile);

                if(filePath != null)
                {
                    File.Delete(filePath);
                    methodsPatient.deletePatient(itemFile);


 /*                   int noteNumber = 0;

                    Match match = Regex.Match(itemFile, @"Note (\d+)");
                    if (match.Success)
                    {
                        noteNumber = int.Parse(match.Groups[1].Value);
                    }

                    for(int i=noteNumber; i<items; i++)
                    {
                        string pName = noteBox.Items[i].ToString();
                        string pattern = @"(\d+)\)$";
                        Regex regEx = new Regex(pattern);
                        pName = regEx.Replace(pName, "");
                        string newFilePath = Path.Combine( newPath, pName + i + ").txt");
                        string oldFilePath = methodsPatient.getData( noteBox.Items[i].ToString());
                        if (oldFilePath != newFilePath)
                        {
                            File.Move(oldFilePath, newFilePath);

                            methodsPatient.changeData(oldFilePath, newFilePath, pName + i + ")");
                        }
                    }*/


                    var fileNames = Directory.GetFiles(newPath).OrderBy(f => int.Parse(Path.GetFileNameWithoutExtension(f).Split(new string[] { "(Note ", ")" }, StringSplitOptions.RemoveEmptyEntries)[1]));
                    noteBox.Items.Clear();
                    foreach (string fileName in fileNames)
                    {
                        noteBox.Items.Add(Path.GetFileNameWithoutExtension(fileName));
                    }



                    if (noteBox.Items.Count >= items)
                    {
                        notificationLabel.Text = "Somenthing was wrong, please Select the item again";
                        idBox.Clear();
                        patientName.Clear();
                        birthDate.Value = DateTime.Now.Date;
                        newProblem.Clear();
                        problemListBox.Items.Clear();
                        vitalRichBox.Text = "";
                        noteRichBox.Clear();

                        idBox.Enabled = false;
                        patientName.Enabled = false;
                        birthDate.Enabled = false;
                        newProblem.Enabled = false;
                        addProblemBttn.Enabled = false;
                        noteRichBox.Enabled = false;
                        addNoteBttn.Enabled = false;
                        updateBttn.Enabled = false;
                        deleteBttn.Enabled = false;
                        noteBox.SelectedIndex = -1;
                    }
                    else
                    {
                        idBox.Clear();
                        patientName.Clear();
                        birthDate.Value = DateTime.Now.Date;
                        newProblem.Clear();
                        problemListBox.Items.Clear();
                        vitalRichBox.Text = "";
                        noteRichBox.Clear();

                        idBox.Enabled = false;
                        patientName.Enabled = false;
                        birthDate.Enabled = false;
                        newProblem.Enabled = false;
                        addProblemBttn.Enabled = false;
                        noteRichBox.Enabled = false;
                        addNoteBttn.Enabled = false;
                        updateBttn.Enabled = false;
                        deleteBttn.Enabled = false;
                        noteBox.SelectedIndex = -1;
                    }

                }
            }
        }
    }
}
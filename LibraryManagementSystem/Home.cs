using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MetroFramework;
using MetroFramework.Forms;
using System.Speech.Synthesis;
using System.Speech;

namespace Library_management_system
{
    public partial class Home : Form
    {
        SpeechSynthesizer ss = new SpeechSynthesizer();

        public Home()
        {
            InitializeComponent();
            fillDataGrid1();
            FillDataGrid1();
            fillDataGrid2();
            FillDataGrid2();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            ss.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Teen);
            ss.Speak("hi admin");

            label14.Text = Convert.ToString(DateTime.Now);
            label11.Text = "Help Title";
            label13.Text = "Help Definition";
        }


        //========================================================
        //----------------- CLOSE, MINIMIZE ----------------------
        //========================================================

        //Application.Close Function
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;


            DialogResult result = MetroMessageBox.Show(this, "\nDo you really want to close this program ?", "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.OK)
            {
                MetroMessageBox.Show(this, "\nHave a nice day !", "Exit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                e.Cancel = true;
            }
        }

        //Close button Code
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Mininmize Button Code
        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        string gen;

        SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
        SqlConnection con2 = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Database2.mdf;Integrated Security=True");

        //========================================================
        //---------------- WORKING WITH DATA ---------------------
        //========================================================

        public void fillDataGrid1()
        {
            try
            {
                con1.Open();
                SqlDataAdapter z = new SqlDataAdapter(@"SELECT * FROM Members", con1);
                DataTable A = new DataTable();
                dataGridView1.DataSource = A;
                z.Fill(A);

            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            finally
            {
                con1.Close();
            }
        }

        public void FillDataGrid1()
        {
            try
            {
                con1.Open();
                SqlDataAdapter z = new SqlDataAdapter(@"SELECT * FROM Members", con1);
                DataTable A = new DataTable();
                dataGridView2.DataSource = A;
                z.Fill(A);

            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            finally
            {
                con1.Close();
            }
        }

        public void fillDataGrid2()
        {
            try
            {
                con2.Open();
                SqlDataAdapter e = new SqlDataAdapter(@"SELECT * FROM Books", con2);
                DataTable v = new DataTable();
                dataGridView3.DataSource = v;
                e.Fill(v);

            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            finally
            {
                con2.Close();
            }
        }

        public void FillDataGrid2()
        {
            try
            {
                con2.Open();
                SqlDataAdapter e = new SqlDataAdapter(@"SELECT * FROM Books", con2);
                DataTable v = new DataTable();
                dataGridView4.DataSource = v;
                e.Fill(v);

            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con2.Close();
            }
        }

        public void fillDataGrid3()
        {
            try
            {
                con2.Open();
                SqlDataAdapter e = new SqlDataAdapter(@"SELECT * FROM Books", con2);
                DataTable v = new DataTable();
                dataGridView5.DataSource = v;
                e.Fill(v);
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con2.Close();
            }
        }

        private void ClearData()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "Enter the Member Id Here";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
        }


        //========================================================
        //-------------------- MAIN FUNCTIONS --------------------
        //========================================================

        //Manage Member Section Main Functions
        private void manMembtn_Click_1(object sender, EventArgs e)
        {
            panel4.Visible = true;
            panel4.Location = new Point(panel4.Location.X, manMembtn.Location.Y);
            textBox5.Text = "Enter the Book Id Here";
            textBox4.Text = "Enter the Member Id Here";

            panel7.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
            dataGridView2.Visible = false;
            dataGridView4.Visible = false;
        }

        /*Add Button
         *Main Functions*/
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                string name = textBox1.Text;
                int age = Convert.ToInt32(textBox2.Text);
                string address = textBox3.Text;
                string gender;

                if (radioButton1.Checked)
                {
                    gender = "Male";
                }
                else
                {
                    gender = "Female";
                }

                //sql query
                string query_insert = "INSERT INTO Members(Member_Name,Age,Gender,Address) VALUES('" + name + "','" + age + "','" + gender + "','" + address + "')";

                SqlCommand cmd = new SqlCommand(query_insert, con1);
                con1.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "\n\nError Occured When Saving\n" + ex, "Saving", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                con1.Close();
                fillDataGrid1();
                FillDataGrid1();
                ClearData();
            }
        }

        /*Search Button 
         *Main Functions*/
        private void btnSrch_Click(object sender, EventArgs e)
        {
            try
            {
                con1.Open();

                int id = Convert.ToInt32(textBox4.Text);
                string query_search = "SELECT * FROM Members WHERE id = '" + id + "'";
                SqlCommand cmd = new SqlCommand(query_search, con1);
                SqlDataReader r = cmd.ExecuteReader();

                while (r.Read())
                {

                    textBox1.Text = r[1].ToString();
                    textBox2.Text = r[2].ToString();
                    gen = r[3].ToString();
                    textBox3.Text = r[4].ToString();
                }
                r.Close();
                con1.Close();

                if (gen == "Male")
                {
                    radioButton1.Checked = true;
                }
                else
                {
                    radioButton2.Checked = true;
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "\n\nError While Searching\n" + ex, "Searching", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*Delete Button 
         *Main Functions*/
        private void btnDlt_Click(object sender, EventArgs e)
        {
            try
            {
                con1.Open();

                int id = Convert.ToInt32(textBox4.Text);

                string query_delete = "DELETE FROM Members WHERE id ='" + id + "'";

                SqlCommand cmd = new SqlCommand(query_delete, con1);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "\n\nError While Deleting\n" + ex, "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con1.Close();
                fillDataGrid1();
                FillDataGrid1();
                ClearData();
            }
        }

        /*Update Button 
         *Main Functions*/
        private void btnUdt_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox1.Text;
                int age = Convert.ToInt32(textBox2.Text);
                string address = textBox3.Text;
                int id = Convert.ToInt32(textBox4.Text);
                string gender;

                if (radioButton1.Checked)
                {
                    gender = "Male";
                }
                else
                {
                    gender = "Female";
                }

                //sql query
                string query_update = "UPDATE Members SET Member_Name='" + name + "',Address='" + address + "',Gender='" + gender + "',Age='" + age + "' WHERE id='" + id + "'";

                SqlCommand cmd = new SqlCommand(query_update, con1);
                con1.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "\n\nError While Saving\n" + ex, "saving", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                con1.Close();
                fillDataGrid1();
                FillDataGrid1();
                ClearData();
            }
        }


        //Borrow / Issue Section Main Functions
        private void brwbk_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            panel4.Location = new Point(panel4.Location.X, brwbk.Location.Y);
            textBox5.Text = "Enter the Book Id Here";
            textBox4.Text = "Enter the Member Id Here";
            panel2.Visible = false;
            panel3.Visible = false;
            panel7.Visible = true;

        }

        /*Set Button 
         * Main Functions*/
        private void setbtn_Click(object sender, EventArgs e)
        {
            try
            {
                string date = dateTimePicker1.Value.ToShortDateString();

                if (dateTimePicker1.Value.Month == 12)
                {
                    label12.Text = "1";
                }
                else { label12.Text = Convert.ToString(dateTimePicker1.Value.Month + 1); 
                }
                
                label12.Text += "/"; 
                label12.Text += Convert.ToString(dateTimePicker1.Value.Day);
                label12.Text += "/"; 
                label12.Text += Convert.ToString(dateTimePicker1.Value.Year);
                label12.Text += " 12.00 P.M."; 

                int id = Convert.ToInt32(textBox8.Text);
                int memberId = Convert.ToInt32(textBox9.Text);

                //sql query
                string query_insert = "UPDATE Books SET Availability ='No', Issued_Date ='" + date + "' WHERE Id ='" + id + "'";
                string Query_insert = "UPDATE Members SET Issued_Books ='" + id + "' WHERE Id='" + memberId + "'";

                SqlCommand cmnd = new SqlCommand(Query_insert, con1);
                SqlCommand cmd = new SqlCommand(query_insert, con2);
                con1.Open();
                con2.Open();
                cmnd.ExecuteNonQuery();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "\n\nError Occured When Setting\n" + ex, "Setting", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con1.Close();
                con2.Close();
                fillDataGrid2();
                FillDataGrid2();
                fillDataGrid1();
                FillDataGrid1();
                fillDataGrid3();
                ClearData();
            }
        }


        //Member Table Section Main Functions
        private void memTbl_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            panel4.Location = new Point(panel4.Location.X, memTbl.Location.Y);
            textBox5.Text = "Enter the Book Id Here";
            textBox4.Text = "Enter the Member Id Here";

            panel7.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
            dataGridView2.Visible = true;
            dataGridView4.Visible = false;
        }


        //Manage Book Section Main Functions
        private void manBkbtn_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            panel4.Location = new Point(panel4.Location.X, manBkbtn.Location.Y);
            textBox5.Text = "Enter the Book Id Here";
            textBox4.Text = "Enter the Member Id Here";

            panel7.Visible = false;
            panel2.Visible = true;
            panel3.Visible = true;
            dataGridView2.Visible = false;
            dataGridView4.Visible = false;
        }

        /*Add Button 
         *Main Functions*/
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //SQL query
            try
            {
                string aval = "";

                if (radioButton3.Checked == true)
                {
                    aval += "Yes";
                }
                else if (radioButton4.Checked == true)
                {
                    aval += "No";
                }

                string name = textBox7.Text;
                string Author = textBox6.Text;

                //sql query
                string query_insert = "INSERT INTO Books(Book_name,Author,Availability) VALUES('" + name + "','" + Author + "','" + aval + "')";

                SqlCommand cmd = new SqlCommand(query_insert, con2);
                con2.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this ,"\n\nError Occured When Saving\n" + ex, "saving", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con2.Close();
                fillDataGrid2();
                FillDataGrid2();
                ClearData();
            }
        }

        /*Search Button 
         *Main Functions*/
        private void buttonSrch_Click(object sender, EventArgs e)
        {
            try
            {
                con2.Open();
                string id = textBox5.Text;
                string quert_search = "SELECT * FROM Books WHERE id = '" + id + "'";
                SqlCommand cmnd = new SqlCommand(quert_search, con2);
                SqlDataReader r = cmnd.ExecuteReader();
                while (r.Read())
                {
                    textBox7.Text = r[1].ToString();
                    textBox6.Text = r[2].ToString();
                    string ava = r[3].ToString();

                    if (ava == "Yes")
                    {
                        radioButton3.Checked = true;
                        radioButton4.Checked = false;
                    }
                    else if (ava == "No")
                    {
                        radioButton3.Checked = false;
                        radioButton4.Checked = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "\n\nError while Searching\n" + ex, "Searching", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con2.Close();
                textBox5.Text = "Enter the Book Id Here";
            }
        }

        /*Delete Button 
         *Main Functions*/
        private void buttonDlt_Click(object sender, EventArgs e)
        {
            try
            {
                con2.Open();
                int id = int.Parse(textBox5.Text);

                string query_delete = "DELETE FROM Books WHERE Id ='" + id + "'";

                SqlCommand cmd = new SqlCommand(query_delete, con2);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "\n\nError While Deleting\n" + ex, "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con2.Close();
                fillDataGrid2();
                FillDataGrid2();
                ClearData();
                textBox5.Text = "Enter the Book id Here";
            }
        }

        /*Update Button 
         *Main Functions*/
        private void buttonUdt_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox7.Text;
                string Author = textBox6.Text;
                int id = Convert.ToInt32(textBox5.Text);
                string val = "";

                if (radioButton3.Checked == true)
                {
                    val += "Yes";
                }
                else if (radioButton4.Checked == true)
                {
                    val += "No";
                }

                if (val == "Yes") {
                    string query_update1 = "UPDATE Books SET Book_name='" + name + "',Author='" + Author + "',Availability='" + val + "',Issued_Date='' WHERE Id='" + id + "'";
                    SqlCommand cmnd = new SqlCommand(query_update1, con2);
                    con2.Open();
                    cmnd.ExecuteNonQuery();
                    con2.Close();
                }

                //sql query
                string query_update = "UPDATE Books SET Book_name='" + name + "',Author='" + Author + "',Availability='" + val + "' WHERE Id='" + id + "'";

                SqlCommand cmd = new SqlCommand(query_update, con2);
                con2.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "\n\nError While Updating\n" + ex, "Saving", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            finally
            {
                con2.Close();
                fillDataGrid2();
                FillDataGrid2();
                fillDataGrid3();
                ClearData();
                textBox5.Text = "Enter the Book id Here";

            }
        }


        //Book Table Section Main Functions
        private void bkTblBtn_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            panel4.Location = new Point(panel4.Location.X, bkTblBtn.Location.Y);
            textBox5.Text = "Enter the Book Id Here";
            textBox4.Text = "Enter the Member Id Here";

            panel7.Visible = false;
            panel2.Visible = true;
            panel3.Visible = true;
            dataGridView2.Visible = false;
            dataGridView4.Visible = true;
        }


        //Help Section Main Functions
        private void button5_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start( Application.ExecutablePath + "Help/Help.html");
            textBox5.Text = "Enter the Book Id Here";
            textBox4.Text = "Enter the Member Id Here";
        }
        

        //========================================================
        //-------------------- EVENTS ----------------------------
        //========================================================

        private void textBox5_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
        }

        private void dataGridView3_Click(object sender, EventArgs e)
        {
            textBox5.Text = "Boook Id";
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            textBox5.Text = "Enter the Book Id Here";
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            textBox4.Text = "Member Id";
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            textBox4.Text = "Member Id";
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) {
                textBox8.Select();
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (textBox9.Text == "") {
                    textBox9.Select();
                }
                else if (textBox8.Text == "")
                {
                    textBox8.Select();
                }
                else {
                    setbtn.Select();
                }
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) {
                if (textBox7.Text == "")
                {
                    textBox7.Select();
                }
                else {
                    textBox6.Select();
                }
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (textBox6.Text == "")
                {
                    textBox6.Select();
                }
                else {
                    radioButton3.Checked = true;
                    buttonAdd.Select();
                }
            }
        }

        private void textBox9_Click(object sender, EventArgs e)
        {
            label11.Text = "Member Id";
            label13.Text = "Enter the Member Id which should be an integer. Hit Enter.";
        }

        private void textBox8_Click(object sender, EventArgs e)
        {
            label11.Text = "Book Id";
            label13.Text = "Enter the issuing book's Id which should be an integer. Press the 'Set' button.";
        }

        private void manMembtn_MouseHover(object sender, EventArgs e)
        {
            label11.Text = "Manage Member Section";
            label13.Text = "Press this to ADD, DELETE, SEARCH and UPDATE Members.";
        }

        private void manMembtn_MouseLeave(object sender, EventArgs e)
        {
            label11.Text = "";
            label13.Text = "";
        }

        private void memTbl_MouseHover(object sender, EventArgs e)
        {
            label11.Text = "Member Table Section";
            label13.Text = "Press this to view the deatils of Members.";
        }

        private void memTbl_MouseLeave(object sender, EventArgs e)
        {
            label11.Text = "";
            label13.Text = ""; 
        }

        private void manBkbtn_MouseHover(object sender, EventArgs e)
        {
            label11.Text = "Manage Book Section";
            label13.Text = "Press this to ADD, DELETE, SEARCH and UPDATE the detalis of books.";   
        }

        private void manBkbtn_MouseLeave(object sender, EventArgs e)
        {
            label11.Text = "";
            label13.Text = ""; 
        }

        private void brwbk_MouseHover(object sender, EventArgs e)
        {
            label11.Text = "Books Issueing / Borrowing Section";
            label13.Text = "Press this to ISSUE and BORROW books"; 
        }

        private void brwbk_MouseLeave(object sender, EventArgs e)
        {
            label11.Text = "";
            label13.Text = ""; 
        }

        private void bkTblBtn_MouseHover(object sender, EventArgs e)
        {
            label11.Text = "Book Table Section";
            label13.Text = "Press this to view the details of Books"; 
        }

        private void bkTblBtn_MouseLeave(object sender, EventArgs e)
        {
            label11.Text = "";
            label13.Text = ""; 
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            label11.Text = "Help Section";
            label13.Text = "Press this for more Information of this application"; 
        }

        private void setbtn_MouseHover(object sender, EventArgs e)
        {
            label11.Text = "Set button";

            if ((textBox9.Text == "") || (textBox8.Text == ""))
            {
                label13.Text = "Enter the details First";
            }
            else {
                label13.Text = "Press this to set the details filled";
            }
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            label11.Text = "";
            label13.Text = ""; 
        }

        private void setbtn_MouseLeave(object sender, EventArgs e)
        {
            label11.Text = "";
            label13.Text = ""; 
        }

        private void textBox7_Click(object sender, EventArgs e)
        {
            label11.Text = "Book Name";
            label13.Text = "Enter the book name. Then Hit Enter"; 
        }

        private void textBox6_Click(object sender, EventArgs e)
        {
            label11.Text = "Author Name";
            label13.Text = "Enter the Author name. Then Hit Enter. If you are adding a book select radio button 'Yes'"; 
        }

        private void buttonSrch_MouseHover(object sender, EventArgs e)
        {
            label11.Text = "Search button";
            label13.Text = "Enter the Book Id and Press this"; 
        }

        private void buttonSrch_MouseLeave(object sender, EventArgs e)
        {
            label11.Text = "";
            label13.Text = ""; 
        }

        private void buttonDlt_MouseHover(object sender, EventArgs e)
        {
            label11.Text = "Delete button";
            label13.Text = "Enter the Book Id and Press this"; 
        }

        private void buttonDlt_MouseLeave(object sender, EventArgs e)
        {
            label11.Text = "";
            label13.Text = ""; 
        }

        private void buttonUdt_MouseHover(object sender, EventArgs e)
        {
            label11.Text = "Update button";

            if ((textBox7.Text == "") || (textBox6.Text == "") || (textBox5.Text == ""))
            {
                label13.Text = "Enter the details First";
            }
            else {
                label13.Text = "Press this to update the details filled";
            }
        }

        private void buttonAdd_MouseHover(object sender, EventArgs e)
        {
            label11.Text = "Add button";
            label13.Text = "Fill the details. And press this."; 
        }

        private void buttonAdd_MouseLeave(object sender, EventArgs e)
        {
            label11.Text = "";
            label13.Text = ""; 
        }

        private void buttonUdt_MouseLeave(object sender, EventArgs e)
        {
            label11.Text = "";
            label13.Text = ""; 
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) {
                if (textBox1.Text == "")
                {
                    textBox1.Select();
                }
                else {
                    textBox2.Select();
                    label11.Text = "Age";
                    label13.Text = "Enter the member's age which should be an integer. Press Enter";
                }
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            label11.Text = "Book Name";
            label13.Text = "Enter the book name. And press Enter"; 
            
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) {
                if (textBox2.Text == "")
                {
                    textBox2.Select();
                }
                else {
                    radioButton1.Select();
                    label11.Text = "";
                    label13.Text = ""; 
                }
            }
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            label11.Text = "Address";
            label13.Text = "Enter the address. And press Add"; 
        }

        private void btnAdd_MouseHover(object sender, EventArgs e)
        {
            label11.Text = "Add button";
            label13.Text = "Fill the details and Press this"; 
        }

        private void btnAdd_MouseLeave(object sender, EventArgs e)
        {
            label11.Text = "";
            label13.Text = ""; 
        }

        private void btnSrch_MouseHover(object sender, EventArgs e)
        {
            label11.Text = "Search button";
            label13.Text = "Enter the member id. And Press this"; 
        }

        private void btnSrch_MouseLeave(object sender, EventArgs e)
        {
            label11.Text = "";
            label13.Text = ""; 
        }

        private void btnDlt_MouseLeave(object sender, EventArgs e)
        {
            label11.Text = "";
            label13.Text = ""; 
        }

        private void btnUdt_MouseLeave(object sender, EventArgs e)
        {
            label11.Text = "";
            label13.Text = ""; 
        }

        private void btnUdt_MouseHover(object sender, EventArgs e)
        {
            label11.Text = "Update button";

            if ((textBox1.Text == "") || (textBox2.Text == "") || (textBox3.Text == ""))
            {
                label13.Text = "Fill the details First";
            }
            else {
                label13.Text = "Press this to update the details fileed";
            }
        }

        private void btnDlt_MouseHover(object sender, EventArgs e)
        {
            label11.Text = "Delete button";
            label13.Text = "Enter the member id. And Press this"; 
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            label11.Text = "Age";
            label13.Text = "Enter the age which should be an integer. And Press Enter";
        }

        private void radioButton1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                textBox3.Select();
                label11.Text = "Address";
                label13.Text = "Enter the address. And press Add";
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) {
                btnAdd.Select();
            }
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            label11.Text = "Close Button";
            label13.Text = "Click on this to Close the application.";
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            label11.Text = "";
            label13.Text = "";
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            label11.Text = "Minimize Button";
            label13.Text = "Click on this to Minimize the application.";
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            label11.Text = "";
            label13.Text = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label14.Text = Convert.ToString(DateTime.Now);
        }
    }
}
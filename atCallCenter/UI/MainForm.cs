using atCallCenter.Data;
using atCallCenter.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace atCallCenter.UI
{
    public partial class MainForm : Form
    {
        //list to hold the call records
        private List<CallRecord> _callRecords;

        public MainForm()
        {
            InitializeComponent();
        }

        //form onload method
        private void MainForm_Load(object sender, EventArgs e)
        {
            //set up the repository combo box
            IntializeComboBoxRepo();
            //populate the data grid with the first entry in the repo combo box
            PopulateGrid(CallRecordFactory.GetCallRecordRepo(comboBoxChooseRepo.SelectedItem.ToString()));
            //show only the records from the first phone number in the combo box
            InitializeComboBoxFromPhoneNumber();
        }

        //method to set up the repository combo box
        private void IntializeComboBoxRepo()
        {
            //create a new binding source
            BindingSource bs = new BindingSource();
            //set the data source to be the name of each repository type
            bs.DataSource = from var in Assembly.GetExecutingAssembly().GetTypes()
                            where typeof(ICallData).IsAssignableFrom(var) &&
                                var.Name != "ICallData"
                            select var.Name;
            
            comboBoxChooseRepo.DataSource = bs;
        }

        //method to change the data grid if the repository combo box is changed
        private void comboBoxChooseRepo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //populate the data grid based on the newly selected combo box item
            PopulateGrid(CallRecordFactory.GetCallRecordRepo(comboBoxChooseRepo.SelectedItem.ToString()));

            //when it's changed, we need to load the proper phone numbers for the other combo box
            InitializeComboBoxFromPhoneNumber();
        }

        //method to populate the data grid with call records
        private void PopulateGrid(ICallData callData)
        {
            //create a list of the call records
            _callRecords = callData.GetCalls().ToList();

            //remove any invalid records when the page loads
            _callRecords = RemoveInvalidRecords(_callRecords);

            //create a new binding source and set the data source to _callRecords
            BindingSource bs = new BindingSource();
            bs.DataSource = _callRecords;
            //attach the binding source info to the data grid
            dataGridViewRecords.DataSource = bs;

            //hide the column with the Rate object
            dataGridViewRecords.Columns[7].Visible = false;

            //show the count in the label (number of entries)
            labelCount.Text = _callRecords.Count.ToString();
            Validate();
        }

        //method to set up the fromPhoneNumber combo box
        private void InitializeComboBoxFromPhoneNumber() 
        {
            //remove any invalid records
            _callRecords = RemoveInvalidRecords(_callRecords);

            //create a new binding source
            BindingSource bs = new BindingSource();
            bs.DataSource = from record in _callRecords //for each record in _callRecords
                            //group the records by their CallFromNumber
                            group record by record.CallFromNumber
                            into g
                            //select one of each unique fromPhoneNumber
                            select g.First().CallFromNumber;
            
            //set the combo box data source to the binding source
            comboBoxFromPhoneNumber.DataSource = bs;
        }

        //method for when the selected item in the fromPhoneNumber combo box changes
        private void comboBoxFromPhoneNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            //re-populate the data grid with entries with a different fromPhoneNumber using the selected repository
            PopulateGridByPhoneNumber(CallRecordFactory.GetCallRecordRepo(comboBoxChooseRepo.SelectedItem.ToString()));
        }

        //method to populate the data grid by the from phone number
        private void PopulateGridByPhoneNumber(ICallData callData)
        {
            //get the records
            _callRecords = callData.GetCalls().ToList();

            //remove any invalid records
            _callRecords = RemoveInvalidRecords(_callRecords);

            //create a new binding source and set the data source to _callRecords
            BindingSource bs = new BindingSource();
            bs.DataSource = from record in _callRecords
                            select record;

            //create a binding list using _callRecords
            BindingList<CallRecord> list = new BindingList<CallRecord>(_callRecords);
            //filter the list by the fromPhoneNumber combo box
            var filter = list.Where(rec => rec.CallFromNumber == comboBoxFromPhoneNumber.SelectedItem.ToString()).ToList();
            //if the "answered only" box isn't selected, show all the records from the phone number
            if (!checkBoxAnsweredCalls.Checked)
            {
                dataGridViewRecords.DataSource = filter;
                labelCount.Text = filter.Count.ToString(); //update the count
                //hide the column with the Rate object
                dataGridViewRecords.Columns[7].Visible = false;
            }
            //otherwise only show records from the phone number that have "Y" for callCompletedStatus
            else
            {
                ShowAnsweredOnly(filter);
            }

            //set the list to contain only the filtered records
            _callRecords = filter;
        }

        //method to remove any records from the _callRecords list that threw an exception for invalid data
        public List<CallRecord> RemoveInvalidRecords(List<CallRecord> callRecords)
        {
            //this probably could have been done better...
            //iterate through each record
            for (int i = 0; i < callRecords.Count; i++)
            {
                //if any of its entries is null, remove it from the list
                if (callRecords[i].CallType == null || callRecords[i].CallDate == null
                    || callRecords[i].CallTime == null || callRecords[i].CallDuration == null
                    || callRecords[i].CallFromNumber == null || callRecords[i].CallToNumber == null
                    || callRecords[i].CallCompletedStatus == null || callRecords[i].Cost == null)
                {
                    callRecords.Remove(callRecords[i]);
                    i--; //decrement i so we don't skip a record after deleting one
                }
            }
            //return the updated list
            return callRecords;
        }

        //method to change the data grid if the check box for answered calls only is checked or not
        private void checkBoxAnsweredCalls_CheckedChanged(object sender, EventArgs e)
        {
            //show only answered calls
            if (checkBoxAnsweredCalls.Checked)
            {
                ShowAnsweredOnly(_callRecords);
            }
            //otherwise re-populate the grid by the chosen phone number
            else
            {
                PopulateGridByPhoneNumber(CallRecordFactory.GetCallRecordRepo(comboBoxChooseRepo.SelectedItem.ToString()));
            }
        }

        //method to show only answered calls if the check box is checked
        private void ShowAnsweredOnly(List<CallRecord> list)
        {
            //create a new binding source
            BindingSource bs = new BindingSource();
            //set the data source to each record where the CallCompletedStatus == "Y"
            var dataSource = from record in list
                             where record.CallCompletedStatus.Equals("Y")
                             select record;
            bs.DataSource = dataSource;

            //linqs return an IEnumerable
            //check if there's anything in it
            if (!dataSource.Any())
            {
                //if not, set the count text to 0
                labelCount.Text = "0";
                //and don't show anything in the data grid
                dataGridViewRecords.DataSource = null;
            }
            else
            {
                //otherwise set the count text to the number of records
                labelCount.Text = bs.Count.ToString();
                //and set the binding source to the data grid
                dataGridViewRecords.DataSource = bs;
                //hide the column with the Rate object
                dataGridViewRecords.Columns[7].Visible = false;
            }
        }

        //onclick handler to display top records
        //sort top records by cost
        //gets the number of records to display from the textBoxDisplayTopRecords.Text
        private void buttonDisplayTopRecords_Click(object sender, EventArgs e)
        {
            int num;
            if (int.TryParse(textBoxDisplayTopRecords.Text.ToString(), out num))
            {
                //create a new binding source
                BindingSource bs = new BindingSource();
                //if the answered only check box is not checked...
                if (!checkBoxAnsweredCalls.Checked)
                {
                    //set the data source
                    var dataSource = (from record in _callRecords //for each record in _callRecords
                                     //if the comboBox phone number matches its fromPhoneNumber
                                     where record.CallFromNumber.Equals(comboBoxFromPhoneNumber.SelectedItem.ToString())
                                     //order records in ascending order
                                     orderby record.Cost ascending 
                                     //and select these kinds of records until we have the amount entered in the text box
                                     select record).Take(Int32.Parse(textBoxDisplayTopRecords.Text));

                    //check if dataSource returns an empty IEnumerable
                    IsDataSourceEmpty(dataSource, bs);
                }

                //otherwise display top calls that were answered only
                else if (checkBoxAnsweredCalls.Checked) 
                {
                    //get all the calls in _callRecords that have a callCompletedStatus of "Y"
                    var dataSource = (from record in _callRecords
                                      where record.CallCompletedStatus == "Y"
                                      orderby record.Cost ascending
                                      select record).Take(Int32.Parse(textBoxDisplayTopRecords.Text));
                    //then set the bs.DataSource to all of the records from the previous linq
                    //but take out any where the phone number in the combo box doesn't match the records phone number
                    var dataSource2 = dataSource.Where(r => r.CallFromNumber == comboBoxFromPhoneNumber.SelectedItem.ToString());

                    //check if dataSource returns an empty IEnumerable
                    IsDataSourceEmpty(dataSource, bs);
                }
            }
            //if nothing was entered in the text box or the entry was invalid, display an error message
            else
            {
                MessageBox.Show("Invalid entry. Enter an integer to display the top records");
            }
        }

        public void IsDataSourceEmpty(IEnumerable<CallRecord> dataSource, BindingSource bs)
        {
            //check if the data source is empty
            if (!dataSource.Any())
            {
                //if it is, display a message
                MessageBox.Show("No records to display");
            }
            else
            {
                //otherwise set the dataSource to the binding source 
                //and create the top records form using the binding source
                bs.DataSource = dataSource;
                TopRecordsForm topRecordsForm = new TopRecordsForm(bs);
                topRecordsForm.ShowDialog();
            }
        }
    }
}

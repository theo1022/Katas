using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scheduler.Exceptions;
using Scheduler.Models;

namespace Scheduler
{
    public partial class CaseWorkerVisualSchedule : UserControl
    {
        private readonly CaseWorker _caseWorker;
        private readonly Action _meetingAddedHandler;//3. Delsvar 6 + 7, en variabel skapas med hjälp av action för att hålla metoden
        public CaseWorkerVisualSchedule(CaseWorker caseWorker, Action meetingAddedHandler)//4. Delsvar 6 + 7, Andra parametern kallar på metoden från mainform
        {
            _caseWorker = caseWorker;
            _meetingAddedHandler = meetingAddedHandler;//5. Delsvar 6 + 7, metoden läggs som värde till den lokala variabeln
            InitializeComponent();

            label_CaseWorkerName.Text = _caseWorker.Name;
            dateTimePicker.Format = DateTimePickerFormat.Custom;

            button_Add.Click += Button_Add_Click;
            button_ChangeDate.Click += Button_ChangeDate_Click;

            RefreshDisplayedMeetings();
        }

        private void Button_ChangeDate_Click(object sender, EventArgs e)
        {
            try//Svar del 4
            {
                int index = listBox_Meetings.SelectedIndex;
                _caseWorker.ChangeMeeting(index, dateTimePicker.Value);
                RefreshDisplayedMeetings();
            }
            catch (MeetingOverlapException exception)
            {
                MessageBox.Show(exception.Message, "Overlap", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Button_Add_Click(object sender, EventArgs e)
        {
            try//Svar del 4
            {
                _caseWorker.NewDateAdded(dateTimePicker.Value);
                RefreshDisplayedMeetings();
                _meetingAddedHandler();//Svar 6 + 7, metoden körs från referens variabeln
            }
            catch (MeetingOverlapException exception)
            {
                MessageBox.Show(exception.Message, "Overlap", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void RefreshDisplayedMeetings()
        {
            List<string> content = new List<string>();

            foreach (Meeting meeting in _caseWorker.Meetings)
            {
                content.Add(meeting.ToString());
            }

            listBox_Meetings.DataSource = content;
        }
    }
}

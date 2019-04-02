using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Syncfusion.SfSchedule.XForms;
using Xamarin.Forms;

namespace CustomInlineAppointmentView
{
    public class ViewModel : INotifyPropertyChanged
    {
        private ScheduleAppointmentCollection scheduleAppointments;
        ObservableCollection<string> subjectCollection;
        ObservableCollection<Color> colorCollection;
        public ViewModel()
        {
            scheduleAppointments = new ScheduleAppointmentCollection();
            this.AddAppointmentDetails();
            this.AddAppointments();
        }

        public ScheduleAppointmentCollection ScheduleAppointments
        {
            get
            {
                return scheduleAppointments;
            }
            set
            {
                scheduleAppointments = value;
            }
        }

        private void AddAppointmentDetails()
        {
            subjectCollection = new ObservableCollection<string>();
            subjectCollection.Add("Conference");
            subjectCollection.Add("Checkup");
            subjectCollection.Add("Dale's Birthday");
            subjectCollection.Add("System Chekup");

            colorCollection = new ObservableCollection<Color>();
            colorCollection.Add(Color.FromHex("#FF339933"));
            colorCollection.Add(Color.FromHex("#FF00ABA9"));
            colorCollection.Add(Color.FromHex("#FFE671B8"));
            colorCollection.Add(Color.FromHex("#FF1BA1E2"));
            colorCollection.Add(Color.FromHex("#FFD80073"));
            colorCollection.Add(Color.FromHex("#FFA2C139"));
            colorCollection.Add(Color.FromHex("#FFA2C139"));
            colorCollection.Add(Color.FromHex("#FFD80073"));
            colorCollection.Add(Color.FromHex("#FF339933"));
            colorCollection.Add(Color.FromHex("#FFE671B8"));
            colorCollection.Add(Color.FromHex("#FF00ABA9"));
        }

        private void AddAppointments()
        {
            var today = DateTime.Now.Date;
            var random = new Random();
            for (int month = -1; month <= 1; month++)
            {
                for (int i = -3; i <= 3; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        var appointment = new ScheduleAppointment();
                        appointment.Subject = subjectCollection[random.Next(3)];
                        appointment.StartTime = today.AddMonths(month).AddDays(random.Next(1, 28)).AddHours(random.Next(9, 18));
                        appointment.EndTime = appointment.StartTime.AddHours(2);
                        appointment.Color = colorCollection[random.Next(11)];
                        appointment.IsAllDay = false;
                        this.ScheduleAppointments.Add(appointment);
                    }
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}

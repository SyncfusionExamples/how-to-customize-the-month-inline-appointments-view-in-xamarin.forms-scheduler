using System;
using Syncfusion.SfSchedule.XForms;
using Xamarin.Forms;

namespace CustomInlineAppointmentView
{
    public class ScheduleBehavior:Behavior<SfSchedule>
    {
        private SfSchedule sfSchedule;
        public ScheduleBehavior()
        {
        }
        protected override void OnAttachedTo(SfSchedule bindable)
        {
            sfSchedule = (bindable as SfSchedule);
            sfSchedule.OnMonthInlineAppointmentLoadedEvent += SfSchedule_OnMonthInlineAppointmentLoadedEvent;

            base.OnAttachedTo(bindable);
        }
        protected override void OnDetachingFrom(SfSchedule bindable)
        {
            sfSchedule.OnMonthInlineAppointmentLoadedEvent -= SfSchedule_OnMonthInlineAppointmentLoadedEvent;
            base.OnDetachingFrom(bindable);
        }

        void SfSchedule_OnMonthInlineAppointmentLoadedEvent(object sender, MonthInlineAppointmentLoadedEventArgs e)
        {
            var button = new Button() { BackgroundColor = Color.Blue };
            if ((e.appointment as ScheduleAppointment).Subject == "Dale's Birthday")
            {
                button.Image = "cake_schedule";
            }
            else if((e.appointment as ScheduleAppointment).Subject == "Conference")
            {
                button.Image = "conference_schedule";
            }
            else if ((e.appointment as ScheduleAppointment).Subject == "Checkup")
            {
                button.Image = "stethoscope_schedule";
            }
            if ((e.appointment as ScheduleAppointment).Subject == "System Chekup")
            {
                button.Image = "troubleshoot_schedule";
            }
            button.Text = (e.appointment as ScheduleAppointment).Subject;
            button.TextColor = Color.White;
            button.BackgroundColor = (e.appointment as ScheduleAppointment).Color;
            e.view = button;
        }
    }
}

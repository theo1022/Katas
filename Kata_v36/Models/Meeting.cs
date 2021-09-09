using System;

namespace Scheduler.Models
{
    public class Meeting
    {
        public DateTime Start;
        public TimeSpan Duration;
        public Applicant Applicant;

        public Meeting(DateTime start)
        {
            Start = start;
            Duration = TimeSpan.FromMinutes(30);//Svar del 1 (Tack Björn ;D)
            Applicant = null;
        }
        public Meeting(DateTime start, TimeSpan duration)
        {
            Start = start;
            Duration = duration;
            Applicant = null;
        }

        public bool Overlap(Meeting meeting)
        {
            bool endIsBefore = (Start + Duration) < meeting.Start;
            bool startIsAfter = (meeting.Start + meeting.Duration) < Start;

            return !(endIsBefore || startIsAfter);
        }

        public override string ToString()//Svar del 2
        {
            string date = Start.ToString("d'/'M'/'yy");
            string start = Start.ToString("HH:mm");
            string end = (Start + Duration).ToString("HH:mm");
            string info = date + " " + start + " - " + end;
            

            if (Applicant != null)
                info += " with: " + Applicant.Name;

            return info;
        }
    }
}

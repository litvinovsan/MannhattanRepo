using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace PBase
{
   public static class Log
   {
      static EventLog myLog;
      static Log()
      {
         if (!EventLog.SourceExists("MySource"))
         {
            EventLog.CreateEventSource("MySource", "MyNewLog");
         }

         myLog = new EventLog();
         myLog.Source = "MySource";

         myLog.WriteEntry("Start logging");
      }

      public static void WriteToLog(string message)
      {
         myLog.WriteEntry(message);
      }

      public static List<Tuple<string, EventLogEntry>> ReadLog(int numLastRecords)
      {
         List<Tuple<string, EventLogEntry>> result = new List<Tuple<string, EventLogEntry>>();

         int LastLogToShow = myLog.Entries.Count;
         if (LastLogToShow < 0) MessageBox.Show("Лог Пустой");
         else
         {
            int j = numLastRecords < LastLogToShow ? numLastRecords : LastLogToShow;
            for (int i = LastLogToShow - 1; i >= LastLogToShow - j; i--)
            {
               EventLogEntry currentEntry = myLog.Entries[i];
               result.Add(new Tuple<string, EventLogEntry>(currentEntry.Message, currentEntry));
            }
         }
         // Event ID   currentEntry.InstanceId
         // Entry Type 
         myLog.Close();

         return result;
      }

      public static void ClearLog()
      {
         myLog.Clear();
         myLog.Close();
      }
   }
}

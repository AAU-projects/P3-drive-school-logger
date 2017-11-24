using System.Collections.Generic;
using System.Data;
using System.Linq;
using DriveLogCode.DataAccess;

namespace DriveLogCode.Objects
{
    public static class Session
    {
        public static User LoggedInUser;
        public static List<Lesson> LessonsUser;
        public static string TypeFirstAid = "FirstAid";
        public static string TypeDoctorsNote = "DoctorsNote";

        public static Lesson LastTheoraticalLesson;
        public static Lesson LastPracticalLesson;

        public static void LoadUserFromDataTable(DataTable userTable)
        {
            LoggedInUser = new User(userTable);
            LessonsUser = DatabaseParser.GetScheduledAndCompletedLessonsByUserIdList(LoggedInUser.Id);

            if (!LoggedInUser.Sysmin)
                GetProgress();
        }

        private static void GetProgress()
        {
            if (LessonsUser.Count != 0)
            {
                LastTheoraticalLesson = LessonsUser
                    .Where(x => x.LessonTemplate.Type == "Theoretical")
                    .OrderByDescending(x => x.TemplateID)
                    .ThenByDescending(x => x.Progress)
                    .FirstOrDefault();

                LastPracticalLesson = LessonsUser
                    .Where(x => x.LessonTemplate.Type == "Practical")
                    .OrderByDescending(x => x.TemplateID)
                    .ThenByDescending(x => x.Progress)
                    .FirstOrDefault();
            }
        }
    }
}

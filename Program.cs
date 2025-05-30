using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COURSACH_APP_WITH_SQL
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
          //  Application.Run(new reportForm());
              Application.Run(new LoginForm());
            // Application.Run(new guestForm());
            //   Application.Run(new clientForm("1"));
            //  Application.Run(new BookingRequestFormClient('t', "1", "1"));
           //   Application.Run(new adminForm());
         //    Application.Run(new managerForm());
            // Application.Run(new ReviewForm("administrator","add"));
            //  Application.Run(new BookingRequestForm("administrator", "edit", "1", 1, "3", "27.10.2024", null, "хихик", 5));
            //  Application.Run(new ReviewForm("client", "add", "1"));
            // Application.Run(new ReviewForm("client", "edit", "1", 1, "3", "27.10.2024", null, "хихик", 5));

            //(string role, string mode, char type, int id=0, string client_id="", string tour_service_id="", string date="", string date_start="", string promocode="")
            //Application.Run(new BookingRequestForm("administrator", "edit", 't', 1,"2","3", "10.10.2004", "12.12.2024"));
            // Application.Run(new BookingRequestForm("manager", "edit", 't', 1, "2", "3", "10.10.2004", "12.12.2024","","В обработке","АХАХ"));
            //   Application.Run(new BookingRequestForm("administrator", "add", 's'));
            // Application.Run(new BookingRequestForm("manager", "add", 's'));
            //Application.Run(new BookingRequestForm("client", "add", 's',1,"2","3"));
            // Application.Run(new tableClientForm("administrator", "add"));
            //   Application.Run(new tableClientForm("manager", "add"));
            //    Application.Run(new tableClientForm("administrator", "edit", 15, "v", "vfvf", "v", "+8764565645", "4564 645643", "ty@e.e"));
            // Application.Run(new tableClientForm("manager", "edit", 15, "v", "v", "v", "+8764565645", "4564 645643", "ty@e.e"));
            // Application.Run(new tableClientForm("manager", "add", 1, "Иванов","Иван","Иванович","+72013526645","0123 456328","ivan@example.com"));
            // Application.Run(new tourForm("administrator", "add"));
            //Application.Run(new tourForm("manager", "add"));
            // Application.Run(new tourForm("administrator", "edit", 15, "Пробный тур", "Пеший", "20000,00", 5, "Ну тур как тур", "Недоступен"));
            //  Application.Run(new tourForm("manager", "edit", 14, "Пробный тур был - джиппинг", "Пеший", "20000,00", 5, "Ну тур как тур", "Недоступен"));
            //  Application.Run(new photoForm("administrator", "add"));
            //  Application.Run(new photoForm("manager", "add"));
            //Application.Run(new photoForm("administrator", "edit",1,"1","path","блаблабла"));
            //    Application.Run(new photoForm("manager", "edit",1,"1","path","блаблабла"));
        }
    }
}
